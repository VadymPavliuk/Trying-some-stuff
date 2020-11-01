using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Models
{
    public class OfficeCar
    {   [Key]
        public int CarId { get; set; }
        public string Model { get; set; }
        [ForeignKey("Id")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
