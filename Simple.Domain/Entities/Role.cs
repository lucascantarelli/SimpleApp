using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string? Description { get; set; }
    }
}