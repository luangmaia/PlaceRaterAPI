using PlaceRaterAPI.Repositories;
using PlaceRaterAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRaterAPI.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IPlaceRepository Places { get; }
        IRateRepository Rates { get; }
        ICategoryRepository Categories { get; }
        IUserRepository Users { get; }
        int Complete();
    }
}
