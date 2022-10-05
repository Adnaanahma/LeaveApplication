using LeaveApplication.Model.Entity;
using LeaveApplication.Model.ViewModel;
using System;
using System.Threading.Tasks;

namespace LeaveApplication.Service.Interfaces
{
    public interface ILeaveService
    {
        Task<BaseResponse> CreateLeave(RequestLeaveViewModel model);
        Task<Leave> GetById(Guid id);
        Task<Leave> GetByEmployeeId(string employeeId);
        Task<BaseResponse> UpdateLeave(UpdateLeaveViewModel model);
        Task<BaseResponse> DeleteLeave(Guid id);

    }
}
