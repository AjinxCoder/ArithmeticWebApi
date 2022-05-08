using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArithmeticWebApi.Models
{
    [Table("Arithmetic", Schema = "dbo")]
    public class Arithmetic
    {
        public int Id { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal FirstNumber { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal SecondNumber { get; set; }
        public string Operator { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal Result { get; set; }
        public DateTime CalculatedOn { get; set; } = DateTime.Now;
    }
}
