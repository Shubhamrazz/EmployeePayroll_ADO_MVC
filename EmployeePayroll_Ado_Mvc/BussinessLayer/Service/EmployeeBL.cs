using BussinessLayer.Interface;
using DatabaseLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }

        public void AddEmployee(EmployeeModel employee)
        {
            try
            {
                this.employeeRL.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteEmployee(int? id)
        {
            try
            {
                this.employeeRL.DeleteEmployee(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            try
            {
                return this.employeeRL.GetAllEmployees();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeModel EmployeeDetails
            (int? id)
        {
            try
            {
                return this.employeeRL.EmployeeDetails(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                this.employeeRL.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}