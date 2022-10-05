using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.ViewModel
{
    public class RequestLeaveViewModel
    {
        public Guid Id { get; set; }
        public string  EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public string Purpose { get; set; }
        public int Duration { get; set; }
        public DateTime EndDate { get; set; }

       // public DateTime CreatedDate { get; set; }

       // public DateTime? UpdatedDate { get; set; }
    }
}
