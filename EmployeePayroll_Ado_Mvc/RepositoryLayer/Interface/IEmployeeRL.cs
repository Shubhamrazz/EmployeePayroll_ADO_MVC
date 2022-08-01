﻿using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        public void AddEmployee(EmployeeModel employee);
        public List<EmployeeModel> GetAllEmployees();
        public EmployeeModel EmployeeDetails(int? id);
        public void UpdateEmployee(EmployeeModel employee);
        public void DeleteEmployee(int? id);
    }
}
