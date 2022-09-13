using System.ComponentModel.DataAnnotations;

namespace MP.EnsekTest.Data.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<MeterRead> MeterReads { get; set; }
    }
}
