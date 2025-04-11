using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medical_Insurence.Models
{
    public class Beneficiary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//autoincremente in MySql
        public int Id { get; set; }
        public string? Name { get; set; }
        public string IdCard { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public bool? Status { get; set; }
    }
}
