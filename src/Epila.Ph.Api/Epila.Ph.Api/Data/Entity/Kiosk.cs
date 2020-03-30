using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epila.Ph.Api.Data.Entity
{
    public class Kiosk : BaseEntity
    {
        public int  Id { get; set; }
        public string KioskName { get; set; }
        public string KioskDescription { get; set; }
    }
}
