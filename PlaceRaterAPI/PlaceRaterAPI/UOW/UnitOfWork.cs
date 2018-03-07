using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaceRaterAPI.Repositories;
using PlaceRaterAPI.Repositories.Interfaces;

namespace PlaceRaterAPI.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlaceRaterContext _context;

        public UnitOfWork(PlaceRaterContext context)
        {
            _context = context;
            Places = new PlaceRepository(_context);
            Rates = new RateRepository(_context);
            Categories = new CategoryRepository(_context);
            Users = new UserRepository(_context);
        }
        public IPlaceRepository Places { get; private set;}
        public IRateRepository Rates { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IUserRepository Users { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
