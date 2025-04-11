namespace Medical_Insurence.Models
{
    public class Beneficiary
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Status { get; set; }
    }
}
