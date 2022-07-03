using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersInformationSystem.Core.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        [StringLength(60)]
        public string DepartmentName { get; set; }
        public List<Project> ListProjects { get; set; }
        public List<Developer> ListDevelopers { get; set; }


        public override string ToString()
        {
            return $"{DepartmentName}";
        }
    }
}
