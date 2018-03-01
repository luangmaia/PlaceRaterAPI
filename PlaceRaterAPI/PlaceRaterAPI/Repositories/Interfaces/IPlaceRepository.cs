using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRaterAPI.Repositories
{
    public interface IPlaceRepository : IRepository<Place>
    {
        IEnumerable<Place> GetTopPopulares(int count);
        IEnumerable<Place> GetTopAvaliados(int count);
        IEnumerable<Place> GetTopCustoBeneficio(int count);
        IEnumerable<Place> SearchByName(string name);
        IEnumerable<Place> SearchByCity(string city);
    }
}
