using System;

namespace PlateformService.Models
{
    public class Platform
    {       
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Cost { get; set; }
    }
}