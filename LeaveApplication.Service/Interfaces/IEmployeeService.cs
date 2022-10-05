using LeaveApplication.Model.Entity;
using LeaveApplication.Model.ViewModel;
using System;
using System.Threading.Tasks;

namespace LeaveApplication.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<BaseResponse> CreateEmployee(EmployeeRequestViewModel model);
        Task<Employee> GetById(Guid id);
        Task<Employee> GetEmployee(string emailaddress);
        Task<BaseResponse> UpdateEmployee(EmployeeUpdateViewModel model);
        Task<BaseResponse> DeleteEmployee(Guid Id);
    }
}
