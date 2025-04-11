using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medical_Insurence.Models
{
    public class PatientCare
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//autoincremente in MySql
        public int Id { get; set; }
        public int BenefId { get; set; }
        public string BenefIdCard {  get; set; }
        public string? TypeCare { get; set; }
        public DateTime Date {  get; set; } = DateTime.Now;
    }
}
