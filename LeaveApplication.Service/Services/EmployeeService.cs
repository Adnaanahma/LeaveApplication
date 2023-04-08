using Arch.EntityFrameworkCore.UnitOfWork;
using LeaveApplication.Model.Entity;
using LeaveApplication.Model.ViewModel;
using LeaveApplication.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace LeaveApplication.Service.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// "Create Employee"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> CreateEmployee(EmployeeRequestViewModel model)
        {
            //check if the user already exist
            var employee = await _unitOfWork.GetRepository<Employee>().GetFirstOrDefaultAsync(x => x.EmployeeId.ToUpper() == model.EmployeeId.ToUpper(), null, null, false);
            if(employee == null)
            {
                //if not exist create the user
                var newEmployee = new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    DateOfEmployment = model.DateOfEmployment,
                    EmailAddress = model.EmailAddress,
                    EmployeeId = model.EmployeeId,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    CreatedDate = DateTime.Now,
                    
            };
                _unitOfWork.GetRepository<Employee>().Insert(newEmployee);
                await _unitOfWork.SaveChangesAsync();

                return new BaseResponse { Message = "Employee Created Successfully </br> Congratulations!!!", Status = true };
            }
           else return new BaseResponse { Message = "Employee Already Exist </br> Oops Sorry!!!", Status = false };
        }

        /// <summary>
        /// "Get Employee By Id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<Employee> GetById(Guid id)
        {
            var employee = await _unitOfWork.GetRepository<Employee>().GetFirstOrDefaultAsync(x => x.Id == id, null, null, false);

            return employee;
        }

       /// <summary>
       /// "Get By emailaddress"
       /// </summary>
       /// <param name="emailaddress"></param>
       /// <returns></returns>
        public async Task<Employee> GetEmployee(string emailaddress)
        {
            var employee = await _unitOfWork.GetRepository<Employee>().GetFirstOrDefaultAsync(x => x.EmailAddress == emailaddress, null, null, false);

            
            return employee;
        }

        /// <summary>
        /// "Updates On Emloyee By Fetching With EmployeeId"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UpdateEmployee(EmployeeUpdateViewModel model)
        {
            var employee = await _unitOfWork.GetRepository<Employee>().GetFirstOrDefaultAsync(x => x.EmployeeId.ToUpper() == model.EmployeeId.ToUpper(), null, null, false);
            if(employee != null)
            {
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.EmailAddress = model.EmailAddress;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Address = model.Address;
                employee.PhoneNumber = model.PhoneNumber;
                employee.UpdatedDate = DateTime.Now;

                _unitOfWork.GetRepository<Employee>().Update(employee);
                await _unitOfWork.SaveChangesAsync();

                return new BaseResponse { Message = "Employee Updated Successfully </br> Congratulations!!!", Status = true };
            }
           else return new BaseResponse { Message = "Employee Does not Exist </br> Oops Sorry!!!", Status = false };
        }

        /// <summary>
        /// "Delete Employee By Fetchimg With Id"
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<BaseResponse> DeleteEmployee(Guid Id)
        {
            var employee = await _unitOfWork.GetRepository<Employee>().GetFirstOrDefaultAsync(x => x.Id == Id, null, null, false);
            if (employee != null)
            {
               
                _unitOfWork.GetRepository<Employee>().Delete(employee);
                await _unitOfWork.SaveChangesAsync();

                return new BaseResponse { Message = ("Deleted Successfully </br> Congratulations!!!"), Status = (true) };

            }

           else return new BaseResponse { Message = ("Employee Does Not Exist </br> Oops Sorry!!!"), Status = (false) };
        }




    }

}
