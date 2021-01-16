using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany
{
    public class Project
    {
        public int ProjectId {get; set;} // Primary Key
        public string Name {get; set;}
        public List<EmployeeProject> EmployeeProjects {get; set;} // Navigation Property to EmployeeProjects
    }

    public class EmployeeProject
    {
        public int EmployeeId {get; set;} // Primary Key, Foreign Key 1
        public int ProjectId {get; set; } // Primary Key, Foreign Key 2
        public Employee Employee {get; set;} // Navigation property back to EMPLOYEE
        public Project Project {get; set;} // Navigation property back to PROJECT
        // Extra properties if necessary
        public string EmployeeRole {get; set;}
        public DateTime EmployeeJoinDate {get; set;}
    }

    
}        