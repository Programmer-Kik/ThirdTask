using System;
using System.Collections.Generic;
using Ustalkov.SSU.Task3.Entity;

namespace Ustalkov.SSU.Task3.BL
{
    public interface IEmployeeLogic
    {
        string AddAwardForEmployee(int employeeId, int awardId);
        string DeleteEmployee(int employeeId);
        string InsertIntoEmployee(string employeeName, DateTime employeeDateOfBirth,
            int employeeAge);
        List<Employee> SelectEmployee();
    }
}
