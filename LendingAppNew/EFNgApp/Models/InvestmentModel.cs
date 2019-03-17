using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFNgApp.Models
{
    public partial class InvestmentModel
    {
        public int id { get; set; }
        public int projectId { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
    }
}
