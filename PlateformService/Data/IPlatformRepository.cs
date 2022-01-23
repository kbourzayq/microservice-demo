using System;
using System.Collections.Generic;
using PlateformService.Models;

namespace PlateformService.Data
{
    public interface IPlatformRepository
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAll();
        Platform GetById(Guid id);
        void Create(Platform platform);
    }
}