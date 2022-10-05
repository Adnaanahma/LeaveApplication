using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.ViewModel
{
    public class EmployeeUpdateViewModel
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; } 
        public DateTime DateOfBirth { get; set; }
        //public DateTime UpdatedDate { get; set; }

    }
}
