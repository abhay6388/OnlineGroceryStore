
using System.ComponentModel.DataAnnotations;

namespace project6.Models
{
    public class SingleOrder
    {
        [Key]
        public int id { get; set; }

        public string? name { get; set; }

        public string? mobile { get; set; }

        public string? email { get; set; }

        public string? pincode { get; set; }

        public string? address { get; set; }

        public string? productname { get; set; }


        public string? productcid { get; set; }

        public string? mode { get; set; }

        public string? paymentstatus { get; set; }

         public string? amount { get; set; }

        public string? transactionid { get; set; }

    }
}
