using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRaterAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new PlaceRaterContext())
            {
                var category = ctx.Categories.FirstOrDefault<Category>();

                Console.WriteLine(category.Name);
                Console.WriteLine(category.Id);
                Console.Read();
            }
        }
    }
}
