using DatabaseLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly string connectionString;
        public EmployeeRL(IConfiguration configuartion)
        {
            connectionString = configuartion.GetConnectionString("EmpPayroll_MVC_ADO");
        }

        // To add New Employee Record
        public void AddEmployee(EmployeeModel employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@profileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@startDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@notes", employee.Notes);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                }
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
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId", id);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // To View All Employee Details
        public List<EmployeeModel> GetAllEmployees()
        {
            try
            {
                List<EmployeeModel> lstemployee = new List<EmployeeModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EmployeeModel employee = new EmployeeModel();

                        employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                        employee.Name = Convert.ToString(rdr["Name"]);
                        employee.ProfileImage = Convert.ToString(rdr["profileImage"]);
                        employee.Gender = Convert.ToString(rdr["Gender"]);
                        employee.Department = Convert.ToString(rdr["Department"]);
                        employee.Salary = Convert.ToInt32(rdr["salary"]);
                        employee.StartDate = Convert.ToDateTime(rdr["startDate"]);
                        employee.Notes = Convert.ToString(rdr["notes"]);

                        lstemployee.Add(employee);
                    }
                    con.Close();
                }
                return lstemployee;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeModel EmployeeDetails(int? id)
        {
            try
            {
                EmployeeModel employee = new EmployeeModel();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Employee WHERE EmployeeId= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                        employee.Name = Convert.ToString(rdr["Name"]);
                        employee.ProfileImage = Convert.ToString(rdr["profileImage"]);
                        employee.Gender = Convert.ToString(rdr["Gender"]);
                        employee.Department = Convert.ToString(rdr["Department"]);
                        employee.Salary = Convert.ToInt32(rdr["salary"]);
                        employee.StartDate = Convert.ToDateTime(rdr["startDate"]);
                        employee.Notes = Convert.ToString(rdr["notes"]);
                    }
                }
                return employee;
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
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@profileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@startDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@notes", employee.Notes);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }    
}
