using System.ComponentModel.DataAnnotations;

namespace CompanyServices
{
    public class CompanyDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Exchange { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string StockTicker { get; set; }
        [RegularExpression(@"^([a-z]{2})?\d+$")]
        [StringLength(50, MinimumLength = 5)]
        [Required]
        public string Isin { get; set; }
        [StringLength(100 )]
        public string  Website { get; set; }
    }
}
