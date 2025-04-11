using Medical_Insurence.Data;
using Medical_Insurence.Models;
using Medical_Insurence.Repositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Insurence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly MedDbContext _context;
        private readonly ReportRepository _repository;

        public ReportController(MedDbContext context, ReportRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        //Get total number of services by type
        [HttpGet("QtdTypeAtend")]
        public async Task<IActionResult> QtdTypeAtend()
        {
            var qtd = await _repository.QuantityAtendType();

            return Ok(qtd);
        }

        //Get Average number of services per active beneficiary
        [HttpGet("AvgAtendBenef")]
        public async Task<ActionResult<IEnumerable<Beneficiary>>> AvgAtendBenef()
        {
            var quantityAtend = await _repository.AverageAtendBenef();

            return Ok(quantityAtend);
        }

        //Get number of beneficiaries without assistance in the last 12 months
        [HttpGet("BenefNotAtend")]
        public async Task<IActionResult> BenefNotAtend()
        {
            var qtd_benef = await _repository.BeneficiaryNotAtend();

            return Ok(qtd_benef);
        }
    }
}
