namespace Medical_Insurence.Models
{
    public class PatientCare
    {
        public int Id { get; set; }
        public int IdBeneficiary { get; set; }
        public DateTime DateCare { get; set; } = DateTime.Now;
        public string? TypeCare { get; set; }
    }
}
