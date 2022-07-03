using DevelopersInformationSystem.Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace DevelopersInformationSystem.Infrastructure.Services
{
    public static class MessageService
    {
        public static void WrongInputMsg()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input! press anny key to continue...");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void ContinueMsg()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("* Press any key to continue...                                                                   ");
            Console.ReadKey();
        }
        public static void BackToPreviouslyWindowMsg(int commandNumber)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine($"* {commandNumber} - Go back to previous window                                                  ");
            Console.WriteLine("*************************************************************************************************");
        }
        public static void ProjectSelectionWindow(List<Project> dbListProject, List<Project> listProjects)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("*               Create new project or assign existing projects to the department                *");
            Console.WriteLine("*************************************************************************************************");
            foreach (var project in dbListProject)
            {
                Console.WriteLine($"{dbListProject.IndexOf(project) + 1} - {project}");
            }
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine($"* {dbListProject.Count + 1} - Add new project to the department                                 ");
            Console.WriteLine($"* {dbListProject.Count + 2} - Continue to next step 'Add developers to the department'          ");
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("* Existing projects assigned to the department:                                                  ");
            Console.WriteLine("*************************************************************************************************");
            if (listProjects.Count == 0)
            {
                Console.WriteLine("No projects assigned yet...");
            }
            else
            {
                foreach (var project in listProjects)
                {
                    Console.WriteLine($"{project}");
                }

            }
            Console.WriteLine("*************************************************************************************************");
        }
        public static void DepartmentForProjectSelectionWindow(List<Department> dbListDepartment, List<Department> listDepartments)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("*                         Assign an existing department to the project                          *");
            Console.WriteLine("*************************************************************************************************");
            foreach (var department in dbListDepartment)
            {
                Console.WriteLine($"{dbListDepartment.IndexOf(department) + 1} - {department}");
            }
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine($"* {dbListDepartment.Count + 1} - Back to main menu                                              ");
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("* Departments assigned to the project:                                                           ");
            Console.WriteLine("*************************************************************************************************");
            if (listDepartments.Count == 0)
            {
                Console.WriteLine("No departments assigned yet...");
            }
            else
            {
                foreach (var department in listDepartments)
                {
                    Console.WriteLine($"{department}");
                }

            }
            Console.WriteLine("*************************************************************************************************");
        }
        public static void DeveloperSelectionWindow(List<Developer> departmentDevelopersList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("*                  Create new developer or select developer to add project                      *");
            Console.WriteLine("*************************************************************************************************");
            foreach (var DepartmentDeveloper in departmentDevelopersList)
            {
                Console.WriteLine($"{departmentDevelopersList.IndexOf(DepartmentDeveloper) + 1} - {DepartmentDeveloper}");
            }
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine($"* {departmentDevelopersList.Count + 1} - Add new developer to the department                    ");
            Console.WriteLine($"* {departmentDevelopersList.Count + 2} - Back to main menu                                      ");
            Console.WriteLine("*************************************************************************************************");
        }
        public static void DeveloperProjectSelectionWindow(List<Project> departmentListProject, List<Project> developerListProject)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("*                            Add department project to the developer!                           *");
            Console.WriteLine("*************************************************************************************************");
            foreach (var project in departmentListProject)
            {
                Console.WriteLine($"{departmentListProject.IndexOf(project) + 1} - {project}");
            }
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine($"* {departmentListProject.Count + 1} - Back to main menu                                         ");
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("* Projects assigned to the developer:                                                            ");
            Console.WriteLine("*************************************************************************************************");
            if (developerListProject.Count == 0)
            {
                Console.WriteLine("* No projects assigned yet...");
            }
            else
            {
                foreach (var project in developerListProject)
                {
                    Console.WriteLine($"{project}");
                }

            }

            Console.WriteLine("*************************************************************************************************");
        }
        public static void DepartmentSelectionWindow(List<Department> listDepatments)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("*                                     Select department                                         *");
            Console.WriteLine("*************************************************************************************************");
            foreach (var department in listDepatments)
            {
                Console.WriteLine($"{listDepatments.IndexOf(department) + 1} - {department}");
            }
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine($"* {listDepatments.Count + 1} - Back to main menu                                                ");
            Console.WriteLine("*************************************************************************************************");
        }
        public static void DeveloperTransferSelectionWindow(List<Developer> listDevelopers)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("*                    Select developer to move him to another department                         *");
            Console.WriteLine("*************************************************************************************************");
            foreach (var developer in listDevelopers)
            {
                Console.WriteLine($"{listDevelopers.IndexOf(developer) + 1} - {developer}");
            }
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine($"* {listDevelopers.Count + 1} - Back to main menu                                                ");
            Console.WriteLine("*************************************************************************************************");
        }
        public static void DiplayMainWindow()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("*                                  Developers information system                                *");
            Console.WriteLine("*                                     select your option below                                  *");
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("*  1 - Create a department and add developers, projects.                                        *");
            Console.WriteLine("*  2 - Add developers/projects to an existing department.                                       *");
            Console.WriteLine("*  3 - Create project and add it to the department.                                             *");
            Console.WriteLine("*  4 - Create developer and add him to an existing department, link him to an existing projects.*");
            Console.WriteLine("*  5 - Move developer to another department and assign existing projects                        *");
            Console.WriteLine("*  6 - Show all department developers                                                           *");
            Console.WriteLine("*  7 - Show all department projects                                                             *");
            Console.WriteLine("*  8 - Show all projects by developer                                                           *");
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("*  9 - Exit Developer information system                                                        *");
            Console.WriteLine("*************************************************************************************************");
        }
    }
}
