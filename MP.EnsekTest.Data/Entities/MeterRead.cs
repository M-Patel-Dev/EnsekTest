using System.ComponentModel.DataAnnotations;

namespace MP.EnsekTest.Data.Entities
{
    public class MeterRead
    {
        [Key]
        public int AccountId { get; set; }

        [Key]
        public DateTime ReadingDateTime { get; set; }

        public string ReadValue { get; set; }

        public Account Account { get; set; }
    }
}
