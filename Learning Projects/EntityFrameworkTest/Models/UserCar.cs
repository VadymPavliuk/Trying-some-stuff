using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Models
{
    public class UserCar
    {
        [Key]
        public Guid UserId { get; set; }
        public int CarId { get; set; }
        public string Model { get; set; }
        [ForeignKey("UserId")]
        public virtual List<UserDevice> UserDevices { get; set; }
    }
}
