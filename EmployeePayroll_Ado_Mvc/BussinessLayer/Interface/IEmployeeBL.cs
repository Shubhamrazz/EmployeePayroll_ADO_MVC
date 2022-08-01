using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IEmployeeBL
    {
        public void AddEmployee(EmployeeModel employee);
        public List<EmployeeModel> GetAllEmployees();
        public EmployeeModel EmployeeDetails(int? id);
        public void UpdateEmployee(EmployeeModel employee);
        public void DeleteEmployee(int? id);
    }
}
