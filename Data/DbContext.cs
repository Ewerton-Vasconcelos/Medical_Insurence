using Medical_Insurence.Models;
using Microsoft.EntityFrameworkCore;

namespace Medical_Insurence.Data
{
    public class MedDbContext : DbContext
    {
        public MedDbContext(DbContextOptions<MedDbContext> options) : base(options)
        {
        }

        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<PatientCare> PatientCares { get; set; }
    }
}
