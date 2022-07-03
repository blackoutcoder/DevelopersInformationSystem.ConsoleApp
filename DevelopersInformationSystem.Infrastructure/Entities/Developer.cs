using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevelopersInformationSystem.Infrastructure.Entities
{
    public class Developer
    {
        public Guid Id { get; set; }
        [StringLength(60)]
        public string Name { get; set; }
        [StringLength(60)]
        public string LastName { get; set; }
        public Department Department { get; set; }
        public List<Project> ListProjects { get; set; }

        public override string ToString()
        {
            return $"{Name} {LastName}";
        }
    }
}
