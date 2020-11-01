﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Models
{
    public class WorkPlace
    {   [Key]
        public Guid OfficeId { get; set; }
        public Guid UserId { get; set; }
        public string RoomNumber { get; set; }
    }
}