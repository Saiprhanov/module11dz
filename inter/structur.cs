using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inter
{
    public struct Employee : IEmployeeInfo
    {
        public string FirstName;
        public string LastName;
        public string Position;
        public double Salary;
        public Gender Gender;
        public DateTime HireDate;

        public string GetFullInfo()
        {
            return $"Name: {FirstName} {LastName}, Position: {Position}, Salary: {Salary}, Gender: {Gender}, Hire Date: {HireDate.ToShortDateString()}";
        }
    }
}
