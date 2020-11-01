using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Models
{
    public class Device
    {   [Key]
        public Guid DeviceId { get; set; }
        [ForeignKey("Id")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
