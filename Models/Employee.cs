using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany
{
    public class Employee 
    {
        public int EmployeeId {get; set;} // Primary Key
        public string Name {get; set;}
        public List<EmployeeProject> EmployeeProjects {get; set;} // Navigation Property to EmployeeProject Association Entity    
    }
}