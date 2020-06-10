using System;
using System.Collections.Generic;
using Ustalkov.SSU.Task3.Entity;

namespace Ustalkov.SSU.Task3.DAO
{
    public interface IEmployeeBase
    {
        string AddAwardForEmployee(int employeeId, int awardId);
        string DeleteEmployee(int employeeId);
        string InsertIntoEmployee(string employeeName, DateTime employeeDateOfBirth,
            int employeeAge);
        List<Employee> SelectEmployee();
    }
}