﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIT.Models
{
    public class BaseRespuesta
    {
        public bool Ok { get; set; }
        public string Mensaje { get; set; }
        public Guid Id { get; set; }
    }
}
