using MySqlConnector;
using System.Data;
using Dapper;

public class BeneficiaryRepository
{
    private readonly IDbConnection _connection;

    public BeneficiaryRepository(IConfiguration config)
    {
        _connection = new MySqlConnection(config.GetConnectionString("DefaultConnection"));
    }

    public async Task<IEnumerable<string>> FirstLogicalQuestion()
    {
        var sql = @$"select b.name

                       from medicalinsurence.beneficiaries b
                      inner join medicalinsurence.patientcares p
                         on p.IdBeneficiary = b.Id

                      where b.status = 1
                        and p.DateCare >= :TwelveMonths

                      group by b.id, b.name
                     having count(p.Id) >= 3;
        ";

        var parameters = new { 
            TwelveMonths = DateTime.Now.AddMonths(-12) 
        };

        var result = await _connection.QueryAsync<string>(sql, parameters);

        return result;
    }

    public async Task<IEnumerable<string>> SecondLogicalQuestion()
    {
        var sql = $@"select b.name,
	                        p.TypeCare,
	                        count(p.Id) as quantity
 
                       from medicalinsurence.beneficiaries b
   
                      inner join medicalinsurence.patientcares p
                        on p.IdBeneficiary = b.Id
 
                      group by p.TypeCare, b.Name
   
                      order by b.Name;";

        var result = await _connection.QueryAsync<string>(sql);

        return result;
    }

    public async Task<IEnumerable<string>> ThirdLogicalQuestion()
    {
        var sql = $@"select info.name,
	                        info.qtd
                     from (select b.name,
	                        count(p.id) as quantity
        
                       from medicalinsurence.patientcares p
   
                       inner join medicalinsurence.beneficiaries b
                          on b.id = p.IdBeneficiary
      
                      group by b.name) info
  
                      order by info.qtd
  
                     LIMIT 5;";

        var result = await _connection.QueryAsync<string>(sql);

        return result;
    }
}
