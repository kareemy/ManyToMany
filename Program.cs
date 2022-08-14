using ManyToMany;
using Microsoft.EntityFrameworkCore;

App MyApp = new App();
List<Employee> employees = new List<Employee> {
    new Employee {Name = "Employee 1"},
    new Employee {Name = "Employee 2"},
    new Employee {Name = "Employee 3"}
};

List<Project> projects = new List<Project> {
    new Project {Name = "Project A"},
    new Project {Name = "Project B"}
};

// Build up association entity.
List<EmployeeProject> employeeProjects = new List<EmployeeProject> {
    new EmployeeProject {Employee = employees[0], Project = projects[0]},
    new EmployeeProject {Employee = employees[1], Project = projects[0]},
    new EmployeeProject {Employee = employees[2], Project = projects[1]},
    new EmployeeProject {Employee = employees[0], Project = projects[1]}
};

using (var db = new AppDbContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
    db.AddRange(employees);
    db.AddRange(projects);
    db.AddRange(employeeProjects);
    db.SaveChanges();
}
MyApp.List();

using (var db = new AppDbContext())
{
    // Remove an employee from a specific project
    // .Find(employeeId, projectId)
    EmployeeProject epRemove = db.EmployeeProjects.Find(1,2)!;
    db.Remove(epRemove);

    // Add employee to a project TECHNIQUE 1
    // STEP 1: Find the employee in the database
    Employee empToAdd = db.Employees.Where(e => e.Name == "Employee 3").Single();

    // STEP 2: Find the project in the database
    Project project = db.Projects.Where(p => p.Name == "Project A").Single();

    // STEP 3: Create an EmployeeProject association
    EmployeeProject ep = new EmployeeProject{Employee = empToAdd, Project = project};
    db.Add(ep);
    db.SaveChanges();
}
MyApp.List();

// Add employee to project TECHNIQUE 2
using (var db = new AppDbContext())
{
    // Use the primary keys. We want to add employee 2 to project B
    int employeeId = 2; // Employee 2
    int newProjectId = 2; // Project B
    EmployeeProject ep2 = new EmployeeProject {EmployeeId = employeeId, ProjectId = newProjectId};
    db.Add(ep2);
    db.SaveChanges();
    // If you are moving an employee from one project to another. Remove from the first project
}

using (var db = new AppDbContext())
{
    EmployeeProject epToUpdate = db.EmployeeProjects.Find(1,1)!;
    epToUpdate.EmployeeRole = "Manager";
    db.SaveChanges();
}            
MyApp.List();