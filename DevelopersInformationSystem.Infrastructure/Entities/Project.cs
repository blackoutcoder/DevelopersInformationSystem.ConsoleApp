using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevelopersInformationSystem.Infrastructure.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        [StringLength(60)]
        public string ProjectName { get; set; }
        public List<Developer> ListDevelopers { get; set; }
        public List<Department> ListDepartments { get; set; }

        public override string ToString()
        {
            return $"{ProjectName}";
        }
    }
}
