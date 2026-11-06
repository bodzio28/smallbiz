using System;
using System.Collections.Generic;
using System.Text;

namespace Smallbiz.Domain.Entities
{
    public class CompanyUser
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        public string UserId { get; set; } = "";

    }
}
