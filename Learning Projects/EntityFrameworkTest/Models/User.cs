using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Models
{
    public class User
    {   [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        
        public virtual List<OfficeCar> AvailableCars { get; set; }

        public virtual List<Device> Devices { get; set; }
    }
}
