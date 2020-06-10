using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Ustalkov.SSU.Task3.Entity;

namespace Ustalkov.SSU.Task3.DAO
{
    public class EmployeeBase : IEmployeeBase
    {
        private string connectionString = "Data Source=LAPTOP-ST7R1B1J\\SQLEXPRESS;Initial Catalog=Job;Integrated Security=True";

        public string AddAwardForEmployee(int employeeId, int awardId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Add_award_for_employee";

                    var parametrEmployeeId = command.CreateParameter();
                    parametrEmployeeId.DbType = DbType.Int32;
                    parametrEmployeeId.ParameterName = "@employee_id";
                    parametrEmployeeId.Value = employeeId;

                    var parametrAwardId = command.CreateParameter();
                    parametrAwardId.DbType = DbType.Int32;
                    parametrAwardId.ParameterName = "@award_id";
                    parametrAwardId.Value = awardId;

                    command.Parameters.Add(parametrAwardId);
                    command.Parameters.Add(parametrEmployeeId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return "Added!";
            }
            catch
            {
                throw new Exception("Wrong award id and/or employee id!");
            }
        }

        public string DeleteEmployee(int employeeId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Delete_employee_by_id";

                    var parametrId = command.CreateParameter();
                    parametrId.DbType = DbType.Int32;
                    parametrId.ParameterName = "@id";
                    parametrId.Value = employeeId;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return "Deleted!";
            }
            catch
            {
                throw new Exception("Wrong employee id!");
            }
        }

        public string InsertIntoEmployee(string employeeName, DateTime employeeDateOfBirth,
            int employeeAge)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Insert_into_employee";

                    var parametrName = command.CreateParameter();
                    parametrName.DbType = DbType.String;
                    parametrName.ParameterName = "@name";
                    parametrName.Value = employeeName;

                    var parametrDate = command.CreateParameter();
                    parametrDate.DbType = DbType.Date;
                    parametrDate.ParameterName = "@date";
                    parametrDate.Value = employeeDateOfBirth;

                    var parametrAge = command.CreateParameter();
                    parametrAge.DbType = DbType.Int32;
                    parametrAge.ParameterName = "@age";
                    parametrAge.Value = employeeAge;

                    command.Parameters.Add(parametrName);
                    command.Parameters.Add(parametrDate);
                    command.Parameters.Add(parametrAge);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return "Inserted!";
            }
            catch
            {
                throw new Exception("Error during inserting!");
            }
        }

        public List<Employee> SelectEmployee()
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Select_employee";

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (employees.Exists(x => x.Id == (int)reader["employee_id"]))
                                {
                                    int id = employees.FindIndex(x => x.Id == (int)reader["employee_id"]);
                                    Award award = new Award((int)reader["award_id"],
                                        (string)reader["award_title"]);
                                    employees[id].AddToAwards(award);
                                }
                                else
                                {
                                    Award award = new Award((int)reader["award_id"],
                                        (string)reader["award_title"]);
                                    Employee employee = new Employee((int)reader["employee_id"],
                                        (string)reader["employee_name"],
                                        (DateTime)reader["employee_date_of_birth"],
                                        (int)reader["employee_age"], award);
                                    employees.Add(employee);
                                }
                            }
                        }
                    }
                }
                return employees;
            }
            catch
            {
                throw new Exception("Error during reading!");
            }
        }
    }
}
