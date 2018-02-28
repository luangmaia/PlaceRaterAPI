﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaceRaterAPI.Repositories;

namespace PlaceRaterAPI.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlaceRaterContext _context;

        public UnitOfWork(PlaceRaterContext context)
        {
            _context = context;
            Places = new PlaceRepository(_context);
        }
        public IPlaceRepository Places { get; private set;}

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
