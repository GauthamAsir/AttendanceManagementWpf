using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AttendanceManagementWPF
{

    class Utils
    {

        public void EmployeeIDValidation(string empID, out bool valid,
            out int employeeID, out string errorMessage)
        {

            if (empID.Length <= 2)
            {
                valid = false;
                employeeID = 0;
                errorMessage = "Invalid Employee ID";
                return;
            }

            try
            {
                employeeID = int.Parse(empID);
                valid = true;
                errorMessage = null;

            }
            catch (Exception e)
            {
                valid = false;
                employeeID = 0;
                errorMessage = "Invalid Employee ID.\nEmployee Id only contains number.";
            }

        }

    }
    class Manager
    {
        public int EmpId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }

}
