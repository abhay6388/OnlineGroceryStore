using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace project6.Models
{
    public class register
    {
        [Key]
        public int Id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }

        public string? password { get; set; }

        public string? mobile { get; set; }

        public string? address { get; set; }
        public string? dateofbirth {  get; set; }

        public bool? deletestatus { get; set; }
        
    }
}
