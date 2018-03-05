using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRaterAPI.Repositories.Interfaces
{
    public interface IRateRepository : IRepository<Rate>
    {
        IEnumerable<Rate> GetRatesByPlace(Place place);
        double GetPlaceAvgStars(Place place);
        double GetPlaceAvgPrice(Place place);
        int GetPlaceQtde(Place place);
    }
}
