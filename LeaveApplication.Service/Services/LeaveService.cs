using Arch.EntityFrameworkCore.UnitOfWork;
using LeaveApplication.Model.Entity;
using LeaveApplication.Model.ViewModel;
using LeaveApplication.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApplication.Service.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LeaveService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// "Create Leave"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> CreateLeave(RequestLeaveViewModel model)
        {
            var leave = await _unitOfWork.GetRepository<Leave>().GetFirstOrDefaultAsync(x => x.EmployeeId.ToUpper() == x.EmployeeId.ToUpper() && x.EndDate > DateTime.Now, null, null, false);
            if (leave == null)
            {
                //Create a new leave for the employee
                var newLeave = new Leave
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now.Date,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Duration = model.Duration,
                    Purpose = model.Purpose,
                    UpdatedDate = DateTime.Now.Date,
                };
                _unitOfWork.GetRepository<Leave>().Insert(newLeave);
                await _unitOfWork.SaveChangesAsync();

                return new BaseResponse { Message = ("Leave Is Requested Successfully"), Status = (true) };
            }

           else return new BaseResponse { Message = ("Employee Is Already On Leave"), Status = (false) };

        }
        /// <summary>
        /// "Get Leave By Id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Leave> GetById(Guid id)
        {
            var response = await _unitOfWork.GetRepository<Leave>().GetFirstOrDefaultAsync(x => x.Id == id, null, null, false);
            

            return response;
        }
        /// <summary>
        /// "Get Leave By EmployeeId"
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<Leave> GetByEmployeeId(string employeeId)
        {
            var response = await _unitOfWork.GetRepository<Leave>().GetFirstOrDefaultAsync(x => x.EmployeeId == employeeId, null, null, false);
           
            return response;
        }
        /// <summary>
        /// "Updates On Leave By Fetching With Id"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UpdateLeave(UpdateLeaveViewModel model)
        {
            var leave = await _unitOfWork.GetRepository<Leave>().GetFirstOrDefaultAsync(x => x.Id == model.Id && x.EndDate > DateTime.Now, null, null, false);

            if (leave != null)
            {
                var Newleave = new Leave
                {
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Purpose = model.Purpose,
                    Duration = model.Duration,
                    UpdatedDate = DateTime.Now.Date,
                };
                _unitOfWork.GetRepository<Leave>().Update(Newleave);
                await _unitOfWork.SaveChangesAsync();

                return new BaseResponse { Message = ("Leave Updated Successfully"), Status = (true) };


            }
            else return new BaseResponse { Message = ("Employee Is Already On Leave"), Status = (false) };
        }
        /// <summary>
        /// "Delete Leave By Fetching With Id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseResponse> DeleteLeave(Guid id)
        {
            var leave = await _unitOfWork.GetRepository<Leave>().GetFirstOrDefaultAsync(x => x.Id == id, null, null, false);
            if (leave != null)
            {
                var newleave = new Leave
                {
                    EmployeeId = leave.EmployeeId,
                    StartDate = leave.StartDate,
                    EndDate = leave.EndDate,
                    Duration = leave.Duration,
                    Purpose = leave.Purpose, 
                    CreatedDate = leave.CreatedDate,
                };

                _unitOfWork.GetRepository<Leave>().Delete(newleave);
                await _unitOfWork.SaveChangesAsync();

                return new BaseResponse { Message = ("Leave Deleted Successfully"), Status = (true) };

            }
            else return new BaseResponse { Message = ("Employee Not Found"), Status = (false) };
        }
    }
}
