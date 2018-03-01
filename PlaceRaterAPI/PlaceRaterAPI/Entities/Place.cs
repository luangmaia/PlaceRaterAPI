using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRaterAPI
{
    public class Place
    {
        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Key]
        [Column(Order = 2)]
        public string City { get; set; }
        [Key]
        [Column(Order = 3)]
        public string State { get; set; }

        public ICollection<Category> Categories { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
