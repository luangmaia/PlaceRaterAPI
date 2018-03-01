using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRaterAPI
{
    public class Image
    {
        [Key]
        [Column(Order = 1)]
        public string Url { get; set; }
    }
}
