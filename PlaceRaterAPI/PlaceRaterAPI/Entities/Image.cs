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
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Place")]
        public string Name { get; set; }
        [Key]
        [Column(Order = 3)]
        [ForeignKey("Place")]
        public string City { get; set; }
        [Key]
        [Column(Order = 4)]
        [ForeignKey("Place")]
        public string State { get; set; }

        public Place Place { get; set; }
    }
}
