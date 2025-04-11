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
        [HttpGet("FirstLogical")]
        public async Task<ActionResult<IEnumerable<Beneficiary>>> FirstLQ()
        {
            var twelveMonthsBenef = await _repository.FirstLogicalQuestion();

            return Ok(twelveMonthsBenef);
        }

        //Get the types of queries according to the beneficiaries.
        [HttpGet("SecondLogical")]
        public async Task<ActionResult<IEnumerable<Beneficiary>>> SecondLQ()
        {
            var typesCares = await _repository.SecondLogicalQuestion();

            return Ok(typesCares);
        }

        //Get the top five beneficiaries with the most queries
        [HttpGet("ThirdLogical")]
        public async Task<ActionResult<IEnumerable<Beneficiary>>> ThirdLQ()
        {
            var mostQueries = await _repository.ThirdLogicalQuestion();

            return Ok(mostQueries);
        }
    }
}
