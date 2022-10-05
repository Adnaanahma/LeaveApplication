using System;

namespace LeaveApplication.Model.Entity
{
    public class Leave
    {
        public Guid Id { get; set; }
        public string  EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public string Purpose { get; set; }
        public int Duration { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
