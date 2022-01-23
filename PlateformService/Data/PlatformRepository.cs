using System;
using System.Collections.Generic;
using System.Linq;
using PlateformService.Models;

namespace PlateformService.Data
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext _context;
        public PlatformRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Platform platform)
        {
            if(platform is null) throw new ArgumentNullException(nameof(platform));
            _context.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAll()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetById(Guid id)
        {
            return _context.Platforms.FirstOrDefault(p=>p.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges()>=0;
        }
    }
}