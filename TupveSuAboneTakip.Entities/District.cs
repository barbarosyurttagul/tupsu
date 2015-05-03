using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TupveSuAboneTakip.Entities
{
    public class District
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }

        public override string ToString()
        {
            return this.DistrictName;
        }
    }
}
