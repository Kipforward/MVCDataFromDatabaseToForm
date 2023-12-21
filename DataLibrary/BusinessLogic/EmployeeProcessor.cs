using DataLibrary.DataAccess;
using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.BusinessLogic
{
    public static class EmployeeProcessor
    {
        public static int CreateEmployee(int employeeId, string firstName, 
            string lastName, string emailAddress)
        {
            EmployeeModel data = new EmployeeModel
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress

            };
            
            
            string sql = @"insert into dbo.Employee (EmployeeId, FirstName, LastName, EmailAddress)
                            values(@EmployeeId, @FirstName, @LastName, @EmailAddress);";
            // These are parameterized SQL statements. The '@' symbol indicates placeholders for parameter values.
            // They are placeholders where actual data will be passed along with the SQL statement.

            // Map our model to the corresponding parameters in the SQL query and execute the query.
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<EmployeeModel> LoadEmployees()
        {
            string sql = @"select Id, EmployeeId, FirstName, LastName, EmailAddress
                            from dbo.Employee;";

            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }
    }
}
