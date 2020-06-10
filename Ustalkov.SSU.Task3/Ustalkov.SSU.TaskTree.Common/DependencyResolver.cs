using Ustalkov.SSU.Task3.BL;
using Ustalkov.SSU.Task3.DAO;

namespace Ustalkov.SSU.Task3.Common
{
    public class DependencyResolver
    {
        static private IAwardBase awardBase;
        static private IAwardLogic awardLogic;
        static private IEmployeeBase employeeBase;
        static private IEmployeeLogic employeeLogic;

        static public IAwardBase AwardBase
        { get => awardBase ?? new AwardBase(); }
        static public IAwardLogic AwardLogic
        { get => awardLogic ?? new AwardLogic(awardBase); }
        static public IEmployeeBase EmployeeBase
        { get => employeeBase ?? new EmployeeBase(); }
        static public IEmployeeLogic EmployeeLogic
        { get => employeeLogic ?? new EmployeeLogic(employeeBase); }
    }
}
