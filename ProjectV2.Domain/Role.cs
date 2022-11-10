using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Domain
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
