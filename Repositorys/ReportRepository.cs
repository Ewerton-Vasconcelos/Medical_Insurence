using Dapper;
using Medical_Insurence.Models;
using MySqlConnector;
using System.Data;

namespace Medical_Insurence.Repositorys
{
    public class ReportRepository
    {
        private readonly IDbConnection _connection;

        public ReportRepository(IConfiguration config)
        {
            _connection = new MySqlConnection(config.GetConnectionString("DefaultConnection"));
        }

        public async Task<IEnumerable<ReportQuantityAtendType>> QuantityAtendType()
        {
            var sql = $@"select info.TypeCare,
	                            info.Quantity

                         from(select p.TypeCare,
  	                                 count(p.Id) as Quantity
 
                                from medicalinsurence.patientcares p

                               group by p.TypeCare)info;";

            var result = await _connection.QueryAsync<ReportQuantityAtendType>(sql);

            return result;
        }

        public async Task<IEnumerable<ReportAverageAtendBenef>> AverageAtendBenef()
        {
            var sql = $@"select info.Nm_Beneficiary,
	                            info.Qtd_Atend
                          from(select b.Name as nm_beneficiary,
		                              round(avg(p.Id)) as Qtd_Atend

                                 from medicalinsurence.patientcares p

                                inner join medicalinsurence.beneficiaries b
                                   on b.Id = p.BenefId

                                where b.status = 1

                                group by b.Name)info;";

            var result = await _connection.QueryAsync<ReportAverageAtendBenef>(sql);

            return result;
        }

        public async Task<ReportBeneficiaryNotAtend> BeneficiaryNotAtend()
        {
            var sql = $@"select info.QtdBenefNotAtend 

                           from(select count(b.Id) as QtdBenefNotAtend

                                  from medicalinsurence.beneficiaries b

                                  left join medicalinsurence.patientcares p
	                                on p.BenefId = b.Id
	                               and p.Date >= DATE_SUB(CURDATE(), INTERVAL 12 MONTH)

                                 where p.Id IS NULL)info;";

            var result = await _connection.QuerySingleAsync<ReportBeneficiaryNotAtend>(sql);

            return result;
        }
    }
}
