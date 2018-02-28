using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRaterAPI
{
    public class Rate
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string Login { get; set; }
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

        [Required]
        public int Stars { get; set; }
        [Required]
        public int Price { get; set; }
        public string Comment { get; set; }

        public User User { get; set; }
        public Place Place { get; set; }
    }
}
