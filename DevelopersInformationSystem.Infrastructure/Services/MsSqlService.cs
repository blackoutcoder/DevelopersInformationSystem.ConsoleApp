
using DevelopersInformationSystem.Infrastructure.Data;
using DevelopersInformationSystem.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersInformationSystem.Infrastructure.Services
{
    public class MsSqlService
    {
        private readonly static DevInfoContext _dbContext = new DevInfoContext();
        public Project GetOrCreateProject(string nameOfProject)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.ProjectName == nameOfProject);
            if (project == null)
            {
                project = new Project { Id = Guid.NewGuid(), ProjectName = nameOfProject };
                _dbContext.Projects.Add(project);
                _dbContext.SaveChanges();
            }
            return project;
        }
        public Developer GetOrCreateDeveloper(string name, string lastName, Department department)
        {
            var developer = _dbContext.Developers.Where(x => x.Name == name && x.LastName == lastName).SingleOrDefault();
            if (developer == null)
            {
                developer = new Developer
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    LastName = lastName,
                    Department = department,
                    ListProjects = new List<Project>()
                };
                _dbContext.Developers.Add(developer);
                _dbContext.SaveChanges();
            }
            return developer;
        }
        public Developer GetOrCreateDeveloper(Developer developer, Department department)
        {
            var newDeveloper = new Developer
            {
                Id = developer.Id,
                Name = developer.Name,
                LastName = developer.LastName,
                Department = department,
                ListProjects = new List<Project>()
            };
            _dbContext.Developers.Add(newDeveloper);
            _dbContext.SaveChanges();
            return newDeveloper;
        }
        public Department GetOrCreatDepartment(string departmentName)
        {
            var department = _dbContext.Departments.SingleOrDefault(x => x.DepartmentName == departmentName);
            if (department == null)
            {
                department = new Department { Id = Guid.NewGuid(), DepartmentName = departmentName };
                _dbContext.Departments.Add(department);
                _dbContext.SaveChanges();
            }
            return department;
        }
        public List<Department> GetDepartmentsList()
        {
            return _dbContext.Departments.ToList();
        }
        public List<Department> GetDepartmentsListWhithProject()
        {
            return _dbContext.Departments.Include(proj => proj.ListProjects).ToList();
        }
        public List<Developer> GetDevelopersListByDepartment(Department department)
        {
            return _dbContext.Developers.Where(x => x.Department == department).ToList();
        }
        public List<Department> GetDepartmentListByProject(Project project)
        {
            return _dbContext.Departments.Where(x => x.ListProjects.Contains(project)).ToList();
        }
        public List<Developer> GetDevelopersListWhithProject()
        {
            return _dbContext.Developers.Include(stud => stud.ListProjects).ToList();
        }
        public bool CheackIfDepartmentExist(string departmentName)
        {
            return _dbContext.Departments.Any(x => x.DepartmentName == departmentName);
        }
        public bool CheackIfDeveloperExist(string name, string lastName)
        {
            return _dbContext.Developers.Any(x => x.Name == name && x.LastName == lastName);
        }
        public bool CheackIfProjectExist(string projectName)
        {
            return _dbContext.Projects.Any(x => x.ProjectName == projectName);
        }
        public List<Project> GetAllProjects()
        {
            return _dbContext.Projects.ToList();
        }
        public List<Project> GetAllProjectsByDepartment(Department department)
        {
            return _dbContext.Projects.Include(proj => proj.ListDepartments).Where(x => x.ListDepartments.Contains(department)).ToList();
        }
        public List<Project> GetAllProjectsByDeveloper(Developer developer)
        {
            return _dbContext.Projects.Include(proj => proj.ListDevelopers).Where(x => x.ListDevelopers.Contains(developer)).ToList();
        }
        public void AssingProjectToDepartment(Department department, Project project)
        {
            var existingDepartment = _dbContext.Departments.Where(x => x.DepartmentName == department.DepartmentName).Include(depart => depart.ListProjects).SingleOrDefault();
            if (existingDepartment != null)
            {
                var existingProject = existingDepartment.ListProjects
                    .Where(c => c.Id == project.Id)
                    .SingleOrDefault();

                if (existingProject == null)
                {
                    existingDepartment.ListProjects.Add(project);
                    _dbContext.SaveChanges();
                }
            }
        }
        public void AssingProjectToDeveloper(Developer developer, Project project)
        {
            var existingDeveloper = _dbContext.Developers.Where(x => x.Name == developer.Name && x.LastName == developer.LastName)
                                                    .Include(stud => stud.ListProjects).SingleOrDefault();
            if (existingDeveloper != null)
            {
                var existingProject = existingDeveloper.ListProjects
                    .Where(c => c.Id == project.Id)
                    .SingleOrDefault();

                if (existingProject == null)
                {
                    existingDeveloper.ListProjects.Add(project);
                    _dbContext.SaveChanges();
                }
            }
        }
        public void AssingDepartmentToProject(Project project, Department department)
        {
            var existingProject = _dbContext.Projects.Where(x => x.ProjectName == project.ProjectName)
                                                     .Include(proj => proj.ListDepartments).SingleOrDefault();
            if (existingProject != null)
            {
                var existingDepartment = existingProject.ListDepartments
                    .Where(c => c.Id == department.Id)
                    .SingleOrDefault();
                if (existingDepartment == null)
                {
                    existingProject.ListDepartments.Add(department);
                    _dbContext.SaveChanges();
                }
            }
        }
        public List<Developer> GetAllDevelopersOfDepartment(string depertmentName)
        {
            return _dbContext.Developers.Include(depart => depart.Department).Where(x => x.Department.DepartmentName == depertmentName).ToList();
        }
        public void RemoveDevelopers(Developer developer)
        {
            var deletedeveloper = _dbContext.Developers.Where(x => x.Equals(developer)).Include(dev => dev.ListProjects).SingleOrDefault();
            _dbContext.Developers.Remove(deletedeveloper);
            _dbContext.SaveChanges();
        }
    }
}
