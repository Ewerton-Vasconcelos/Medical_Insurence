using MySqlConnector;
using System.Data;
using Dapper;
using Medical_Insurence.Models;

public class BeneficiaryRepository
{
    private readonly IDbConnection _connection;

    public BeneficiaryRepository(IConfiguration config)
    {
        _connection = new MySqlConnection(config.GetConnectionString("DefaultConnection"));
    }

    public async Task<IEnumerable<string>> FirstSqlQuestion()
    {
        var sql = @$"select b.name

                       from medicalinsurence.beneficiaries b
                      inner join medicalinsurence.patientcares p
                         on p.BenefId = b.Id

                      where b.status = 1
                        and p.Date >= @TwelveMonths

                      group by b.id, b.name
                     having count(p.Id) >= 3;
        ";

        var parameters = new { 
            TwelveMonths = DateTime.Now.AddMonths(-12) 
        };

        var result = await _connection.QueryAsync<string>(sql, parameters);

        return result;
    }

    public async Task<IEnumerable<string>> SecondSqlQuestion()
    {
        var sql = $@"select b.name,
	                        p.TypeCare,
	                        count(p.Id) as quantity
 
                       from medicalinsurence.beneficiaries b
   
                      inner join medicalinsurence.patientcares p
                        on p.BenefId = b.Id
 
                      group by p.TypeCare, b.Name
   
                      order by b.Name;";

        var result = await _connection.QueryAsync<string>(sql);

        return result;
    }

    public async Task<IEnumerable<string>> ThirdSqlQuestion()
    {
        var sql = $@"select info.name,
	                        info.qtd
                     from (select b.name,
	                        count(p.id) as quantity
        
                       from medicalinsurence.patientcares p
   
                       inner join medicalinsurence.beneficiaries b
                          on b.id = p.BenefId
      
                      group by b.name) info
  
                      order by info.qtd
  
                     LIMIT 5;";

        var result = await _connection.QueryAsync<string>(sql);

        return result;
    }

    public async Task<int> AvgAgeBenef()
    {
        var sql = $@"select round(avg(info.Age)) as average

                       from(select round(datediff(sysdate(), b.DateOfBirth)/365) as Age

                              from medicalinsurence.beneficiaries b

                             where b.status = 1) info;";

        var result = await _connection.QuerySingleAsync<int>(sql);

        return result;
    }

    public async Task<IEnumerable<Beneficiary>> NotAtendEighteen()
    {
        var sql = $@"SELECT b.Id,
                            b.Name,
                            b.Status

                       FROM medicalinsurence.beneficiaries b

                       LEFT JOIN medicalinsurence.patientcares p
                         ON p.BenefId = b.Id
                        AND p.Date >= DATE_SUB(CURDATE(), INTERVAL 18 MONTH)

                      WHERE p.Id IS NULL;";

        var result = await _connection.QueryAsync<Beneficiary>(sql);

        return result;
    }
}
