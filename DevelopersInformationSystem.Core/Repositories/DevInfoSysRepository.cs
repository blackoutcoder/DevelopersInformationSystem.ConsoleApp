using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevelopersInformationSystem.Core.Repositories
{
    public class DevInfoSysRepository
    {
        public readonly static MsSqlService _msSqlService = new();
        public bool MainWindow()
        {
            MessageService.DiplayMainWindow();
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    CreateDepartment();
                    return false;
                case "2":
                    AddProjectsAndDevelopersToDepartment();
                    return false;
                case "3":
                    AddDepartmentToProject();
                    return false;
                case "4":
                    CreateDeveloperAndAddToDepartment();
                    return false;
                case "5":
                    MoveDevelopersToAnothertherDepartment();
                    return false;
                case "6":
                    DisplayDepartmentDevelopers();
                    return false;
                case "7":
                    DisplayDepartmentProjects();
                    return false;
                case "8":
                    DisplayDeveloperProjects();
                    return false;
                case "9":
                    return true;
                default:
                    MessageService.WrongInputMsg();
                    return false;
            }
        }
        public void CreateDepartment()
        {
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*************************************************************************************************");
                Console.WriteLine("*                                   Enter new department name                                   *");
                Console.WriteLine("*************************************************************************************************");
                var departmentName = Console.ReadLine();
                if (_msSqlService.CheackIfDepartmentExist(departmentName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"The department '{departmentName}' already exist");
                    MessageService.ContinueMsg();
                    continue;
                }
                var department = _msSqlService.GetOrCreatDepartment(departmentName);
                AddProjectsToDepartment(department);
                AddDevelopersToDepartment(department);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Department with projects and developers created!");
                MessageService.ContinueMsg();
                exit = true;
            }
        }
        public void AddProjectsAndDevelopersToDepartment()
        {
            var exit = false;
            while (!exit)
            {
                var listDepatments = _msSqlService.GetDepartmentsList();
                MessageService.DepartmentSelectionWindow(listDepatments);
                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    if (command > 0 && command <= listDepatments.Count)
                    {
                        var department = listDepatments.ElementAt(command - 1);
                        AddProjectsToDepartment(department);
                        AddDevelopersToDepartment(department);
                        continue;
                    }
                    else if (command == listDepatments.Count + 1) exit = true;
                    else MessageService.WrongInputMsg();
                }
                else MessageService.WrongInputMsg();
            }
        }
        public void CreateDeveloperAndAddToDepartment()
        {
            var exit = false;
            while (!exit)
            {
                var listDepatments = _msSqlService.GetDepartmentsList();
                MessageService.DepartmentSelectionWindow(listDepatments);
                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    if (command > 0 && command <= listDepatments.Count)
                    {
                        var department = listDepatments.ElementAt(command - 1);
                        CreateDeveloper(department);
                        exit = true;
                    }
                    else if (command == listDepatments.Count + 1) exit = true;
                    else MessageService.WrongInputMsg();
                }
                else MessageService.WrongInputMsg();
            }
        }
        public void MoveDevelopersToAnothertherDepartment()
        {
            var exit = false;
            var moveDeveloper = new Developer();
            while (!exit)
            {
                var listDepatments = _msSqlService.GetDepartmentsList();
                MessageService.DepartmentSelectionWindow(listDepatments);
                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    if (command > 0 && command <= listDepatments.Count)
                    {
                        while (!exit)
                        {
                            var department = listDepatments.ElementAt(command - 1);
                            var listDevelopers = _msSqlService.GetAllDevelopersOfDepartment(department.DepartmentName);
                            MessageService.DeveloperTransferSelectionWindow(listDevelopers);
                            if (int.TryParse(Console.ReadLine(), out int secondCommand))
                            {
                                if (secondCommand > 0 && secondCommand <= listDevelopers.Count)
                                {
                                    var developer = listDevelopers.ElementAt(secondCommand - 1);
                                    moveDeveloper.Name = developer.Name;
                                    moveDeveloper.LastName = developer.LastName;
                                    moveDeveloper.Id = developer.Id;
                                    _msSqlService.RemoveDevelopers(developer);
                                    while (!exit)
                                    {
                                        var listDepartment = _msSqlService.GetDepartmentsList();
                                        MessageService.DepartmentSelectionWindow(listDepartment);
                                        if (int.TryParse(Console.ReadLine(), out int ThirdCommand))
                                        {
                                            if (ThirdCommand > 0 && ThirdCommand <= listDepartment.Count)
                                            {
                                                var newdepartment = listDepartment.ElementAt(ThirdCommand - 1);
                                                MoveDeveloper(newdepartment, moveDeveloper);
                                                exit = true;
                                            }
                                            else if (ThirdCommand == listDepartment.Count + 1) exit = true;
                                            else MessageService.WrongInputMsg();
                                        }
                                        else MessageService.WrongInputMsg();
                                    }
                                }
                                else if (secondCommand == listDevelopers.Count + 1) exit = true;
                                else MessageService.WrongInputMsg();
                            }
                            else MessageService.WrongInputMsg();
                        }
                    }
                    else if (command == listDepatments.Count + 1) exit = true;
                    else MessageService.WrongInputMsg();
                }
                else MessageService.WrongInputMsg();
            }
        }
        public void AddProjectsToDepartment(Department department)
        {
            var exit = false;
            while (!exit)
            {
                var listProjects = _msSqlService.GetAllProjectsByDepartment(department);
                var dbListProjects = _msSqlService.GetAllProjects();
                MessageService.ProjectSelectionWindow(dbListProjects, listProjects);
                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    if (command > 0 && command <= dbListProjects.Count)
                    {
                        var project = dbListProjects.ElementAt(command - 1);
                        _msSqlService.AssingProjectToDepartment(department, project);
                        continue;
                    }
                    else if (command == dbListProjects.Count + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enter new project name");

                        var project = _msSqlService.GetOrCreateProject(Console.ReadLine());
                        _msSqlService.AssingProjectToDepartment(department, project);
                    }
                    else if (command == dbListProjects.Count + 2) exit = true;
                    else MessageService.WrongInputMsg();
                }
                else MessageService.WrongInputMsg();
            }
        }
        public void AddDepartmentToProject()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("*                                     Enter new project name                                    *");
            Console.WriteLine("*************************************************************************************************");
            var ProjectName = Console.ReadLine();
            if (_msSqlService.CheackIfProjectExist(ProjectName))
            {
                Console.WriteLine($"The project '{ProjectName}' already exist");
                MessageService.ContinueMsg();
                AddDepartmentToProject();
            }
            var exit = false;
            while (!exit)
            {
                var dbListDepartment = _msSqlService.GetDepartmentsList();
                var project = _msSqlService.GetOrCreateProject(ProjectName);
                var listDepartments = _msSqlService.GetDepartmentListByProject(project);
                MessageService.DepartmentForProjectSelectionWindow(dbListDepartment, listDepartments);
                //???????????????????????????????????????????????????????????????????????????????????
                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    if (command > 0 && command <= dbListDepartment.Count)
                    {
                        var department = dbListDepartment.ElementAt(command - 1);
                        _msSqlService.AssingDepartmentToProject(project, department);
                        continue;
                    }
                    else if (command == dbListDepartment.Count + 1) exit = true;
                    else MessageService.WrongInputMsg();
                }
                else MessageService.WrongInputMsg();
            }
        }
        public void AddDevelopersToDepartment(Department department)
        {
            var exit = false;
            while (!exit)
            {
                var departmentDevelopersList = _msSqlService.GetAllDevelopersOfDepartment(department.DepartmentName);
                MessageService.DeveloperSelectionWindow(departmentDevelopersList);
                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    if (command > 0 && command <= departmentDevelopersList.Count)
                    {
                        var developer = departmentDevelopersList.ElementAt(command - 1);
                        AddProjectToDeveloper(department, developer);
                        continue;
                    }
                    else if (command == departmentDevelopersList.Count + 1)
                    {
                        CreateDeveloper(department);
                    }
                    else if (command == departmentDevelopersList.Count + 2) exit = true;
                    else MessageService.WrongInputMsg();
                }
                else MessageService.WrongInputMsg();
            }
        }
        public void CreateDeveloper(Department department)
        {
            var skip = false;
            Console.WriteLine("Enter new developer Name");
            var developerName = Console.ReadLine();
            Console.WriteLine("Enter new developer Last Name");
            var developerLastName = Console.ReadLine();
            if (_msSqlService.CheackIfDeveloperExist(developerName, developerLastName))
            {
                Console.WriteLine($"The developer {developerName} {developerLastName} exist in the system");
                MessageService.ContinueMsg();
                CreateDeveloper(department);
                skip = true;
            }
            if (!skip)
            {
                var newDeveloper = _msSqlService.GetOrCreateDeveloper(developerName, developerLastName, department);
                AddProjectToDeveloper(department, newDeveloper);
            }
        }
        public void MoveDeveloper(Department department, Developer developer)
        {
            var newDeveloper = _msSqlService.GetOrCreateDeveloper(developer, department);
            AddProjectToDeveloper(department, newDeveloper);
        }
        public void AddProjectToDeveloper(Department department, Developer developer)
        {
            var exit = false;
            while (!exit)
            {
                var departmentListProjects = _msSqlService.GetAllProjectsByDepartment(department);
                var developerListProjects = _msSqlService.GetAllProjectsByDeveloper(developer);
                MessageService.DeveloperProjectSelectionWindow(departmentListProjects, developerListProjects);
                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    if (command > 0 && command <= departmentListProjects.Count)
                    {
                        var project = departmentListProjects.ElementAt(command - 1);
                        _msSqlService.AssingProjectToDeveloper(developer, project);
                        continue;
                    }
                    else if (command == departmentListProjects.Count + 1) break;
                    else MessageService.WrongInputMsg();
                }
                else MessageService.WrongInputMsg();
            }
        }
        public void DisplayDepartmentDevelopers()
        {
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*                              Select department to view developers                             *");
                Console.WriteLine("*************************************************************************************************");
                var listDepatments = _msSqlService.GetDepartmentsList();
                foreach (var department in listDepatments)
                {
                    Console.WriteLine($"{listDepatments.IndexOf(department) + 1} - {department}");
                }
                MessageService.BackToPreviouslyWindowMsg(listDepatments.Count + 1);
                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    if (command > 0 && command <= listDepatments.Count)
                    {
                        var department = listDepatments.ElementAt(command - 1);
                        Console.Clear();
                        Console.WriteLine($"List of develoopers in {department} department");
                        var listDevelopers = _msSqlService.GetDevelopersListByDepartment(department);
                        foreach (var developer in listDevelopers)
                        {
                            Console.WriteLine($"{listDevelopers.IndexOf(developer) + 1} - {developer}");
                        }
                        MessageService.ContinueMsg();
                    }
                    else if (command == listDepatments.Count + 1) exit = true;
                    else MessageService.WrongInputMsg();
                }
                else MessageService.WrongInputMsg();
            }
        }
        public void DisplayDepartmentProjects()
        {
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*                               Select department to view projects                              *");
                Console.WriteLine("*************************************************************************************************");
                var listDepatments = _msSqlService.GetDepartmentsListWhithProject();
                foreach (var department in listDepatments)
                {
                    Console.WriteLine($"{listDepatments.IndexOf(department) + 1} - {department}");
                }
                MessageService.BackToPreviouslyWindowMsg(listDepatments.Count + 1);
                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    if (command > 0 && command <= listDepatments.Count)
                    {
                        var department = listDepatments.ElementAt(command - 1);
                        Console.Clear();
                        Console.WriteLine($"List of projects in {department} department");
                        foreach (var project in department.ListProjects)
                        {
                            Console.WriteLine($"{department.ListProjects.IndexOf(project) + 1} - {project}");
                        }
                        MessageService.ContinueMsg();
                    }
                    else if (command == listDepatments.Count + 1) exit = true;
                    else MessageService.WrongInputMsg();
                }
                else MessageService.WrongInputMsg();
            }
        }
        public void DisplayDeveloperProjects()
        {
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*                                Select 'developer' to view projects                            *");
                Console.WriteLine("*************************************************************************************************");
                var listDevelopers = _msSqlService.GetDevelopersListWhithProject();
                foreach (var developer in listDevelopers)
                {
                    Console.WriteLine($"{listDevelopers.IndexOf(developer) + 1} - {developer}");
                }
                MessageService.BackToPreviouslyWindowMsg(listDevelopers.Count + 1);
                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    if (command > 0 && command <= listDevelopers.Count)
                    {
                        var developer = listDevelopers.ElementAt(command - 1);
                        Console.Clear();
                        Console.WriteLine($"List of the projects of developer '{developer}'");
                        foreach (var project in developer.ListProjects)
                        {
                            Console.WriteLine($"{developer.ListProjects.IndexOf(project) + 1} - {project}");
                        }
                        MessageService.ContinueMsg();
                    }
                    else if (command == listDevelopers.Count + 1) exit = true;
                    else MessageService.WrongInputMsg();
                }
                else MessageService.WrongInputMsg();
            }
        }
    }
}
