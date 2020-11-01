using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Models
{
    public class UserDevice
    {
        [Key]
        public Guid UserId { get; set; }
        public Guid DeviceId { get; set; }
        public UserCar UserCar { get; set; }
    }
}
