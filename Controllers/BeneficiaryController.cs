using Medical_Insurence.Data;
using Medical_Insurence.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medical_Insurence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private readonly MedDbContext _context;
        private readonly BeneficiaryRepository _repository;

        public BeneficiaryController(MedDbContext context, BeneficiaryRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        //Add a beneficiary in the data base.
        [HttpPost("AddBeneficiary")]
        public async Task<IActionResult> AddBeneficiary(Beneficiary entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return Ok(entity);
        }

        //Get all beneficiaries of Beneficiaries Table.
        [HttpGet("AllBeneficiaries")]
        public async Task<ActionResult<IEnumerable<Beneficiary>>> AllBeneficiaries()
        {
            var beneficiaries = await _context.Beneficiaries.ToListAsync();

            return Ok(beneficiaries);
        }

        //Get the beneficiaries of last twelve months.
        [HttpGet("FirstSql")]
        public async Task<ActionResult<IEnumerable<Beneficiary>>> FirstSQ()
        {
            var twelveMonthsBenef = await _repository.FirstSqlQuestion();

            return Ok(twelveMonthsBenef);
        }

        //Get the types of queries according to the beneficiaries.
        [HttpGet("SecondSql")]
        public async Task<ActionResult<IEnumerable<Beneficiary>>> SecondSQ()
        {
            var typesCares = await _repository.SecondSqlQuestion();

            return Ok(typesCares);
        }

        //Get the top five beneficiaries with the most queries
        [HttpGet("ThirdSql")]
        public async Task<ActionResult<IEnumerable<Beneficiary>>> ThirdSQ()
        {
            var mostQueries = await _repository.ThirdSqlQuestion();

            return Ok(mostQueries);
        }

        //Get average of the beneficiaries.
        [HttpGet("AverageAgeBenef")]
        public async Task<ActionResult> AverageAgeBeneficiaries()
        {
            var AvgAge = await _repository.AvgAgeBenef();

            return Ok(AvgAge);
        }

        //Get beneficiaries not atend eighteen months ago.
        [HttpGet("NotAtendEighteen")]
        public async Task<ActionResult<IEnumerable<Beneficiary>>> NotAtend()
        {
            var beneficiaries = await _repository.NotAtendEighteen();

            return Ok(beneficiaries);
        }
    }
}
