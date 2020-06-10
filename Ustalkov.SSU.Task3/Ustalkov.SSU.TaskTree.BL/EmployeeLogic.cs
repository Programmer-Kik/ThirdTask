using System;
using System.Collections.Generic;
using Ustalkov.SSU.Task3.Entity;
using Ustalkov.SSU.Task3.DAO;

namespace Ustalkov.SSU.Task3.BL
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private IEmployeeBase employeeBase;

        public EmployeeLogic(IEmployeeBase employeeBase)
        {
            this.employeeBase = employeeBase;
        }
        public EmployeeLogic()
        {
            employeeBase = new EmployeeBase();
        }

        public string AddAwardForEmployee(int employeeId, int awardId)
        {
            return employeeBase.AddAwardForEmployee(employeeId, awardId);
        }

        public string DeleteEmployee(int employeeId)
        {
            return employeeBase.DeleteEmployee(employeeId);
        }

        public string InsertIntoEmployee(string employeeName, DateTime employeeDateOfBirth,
            int employeeAge)
        {
            return employeeBase.InsertIntoEmployee(employeeName, employeeDateOfBirth,
                employeeAge);
        }

        public List<Employee> SelectEmployee()
        {
            return employeeBase.SelectEmployee();
        }
    }
}
