using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ConvertModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]

        public double Result { get; set; }
        [StringLength(3)]
        public string From { get; set; }
        [StringLength(3)]
        public string Into { get; set; }

    }
}
//{
//"date":"2019-12-12",
//"result": "12",
//"from":"wat",
//"into":"bob"
//}

//[
//{ "op": "replace", "path": "/From", "value": "NEW" }
//]
