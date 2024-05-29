using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolioapi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developers { get; set; }
        public int Year { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ProjectLink { get; set; }
        public string Pictures { get; set; }
        public ICollection<ProjectPTag> Tags { get; set; }
    }
}
