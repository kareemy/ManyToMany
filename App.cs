using ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany
{
    public class App
    {
        public void List()
        {
            // LINQ query to pull all Projects, EmployeeProjects, and then Employees.
            // You need .Include() and .ThenInclude() to bring in all entitys so that you can list them
            using (var db = new AppDbContext())
            {
                var allProjects = db.Projects.Include(p => p.EmployeeProjects)
                                    .ThenInclude(ep => ep.Employee);
                foreach (var project in allProjects)
                {
                    Console.WriteLine($"{project.Name} - ");
                    foreach (EmployeeProject employee in project.EmployeeProjects)
                    {
                        Console.WriteLine($"\t{employee.Employee.Name} {employee.EmployeeRole}");
                    }
                    Console.WriteLine();
                }

            }            
        }
    }
}