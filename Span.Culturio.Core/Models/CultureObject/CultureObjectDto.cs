﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Span.Culturio.Core.Models.CultureObject {
    public class CultureObjectDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public int ZipCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int AdminUserId { get; set; }

    }
}
