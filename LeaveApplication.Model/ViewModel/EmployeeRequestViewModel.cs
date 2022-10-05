using System;

namespace LeaveApplication.Model.ViewModel
{
    public class EmployeeRequestViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public string EmployeeId { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
