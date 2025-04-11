using Medical_Insurence.Data;
using Medical_Insurence.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Insurence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private readonly MedDbContext _context;

        public BeneficiaryController(MedDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddBeneficiary(Beneficiary entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return Ok(entity);
        }


    }
}
