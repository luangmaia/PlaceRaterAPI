using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PlaceRaterAPI.Repositories.Interfaces;

namespace PlaceRaterAPI.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(PlaceRaterContext context) : base(context)
        {
        }
    }
}
