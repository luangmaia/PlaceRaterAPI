using PlaceRaterAPI;
using PlaceRaterAPI.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlaceRater.BLLs
{
    public class CategoriesBLL
    {
        public IEnumerable<Category> GetAllCategories()
        {
            IEnumerable<Category> categories = new List<Category>();

            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                categories = unitOfWork.Categories.GetAll();
            }

            return categories;
        }
    }
}
