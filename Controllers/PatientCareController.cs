using Medical_Insurence.Data;
using Medical_Insurence.Models;
using Medical_Insurence.Repositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medical_Insurence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCareController : ControllerBase
    {
        private readonly MedDbContext _context;
        private readonly PatientCareRepository _repository;

        public PatientCareController(MedDbContext context, PatientCareRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpPost("AddPatientCare")]
        public async Task<IActionResult> AddPatientCare(PatientCare entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return Ok(entity);
        }
    }
}
