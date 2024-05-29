using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolioapi.Models
{
    public class ProjectPTag
    {
        public int ProjectId { get; set; }
        public int PTagId { get; set; }
        public Project Project { get; set; }
        public PTag PTag { get; set; }
    }
}
