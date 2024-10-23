using System.ComponentModel.DataAnnotations;

namespace project6.Models
{
    public class AdminLogin
    {
        [Key]
        public int id { get; set; }
        public string? email{ get; set; }
        public string? password{ get; set; }

    }
}
