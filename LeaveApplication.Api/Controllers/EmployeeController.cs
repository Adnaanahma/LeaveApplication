using LeaveApplication.Model.ViewModel;
using LeaveApplication.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LeaveApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService EmployeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }
        /// <summary>
        /// "Create Employee"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee (EmployeeRequestViewModel model)
        {
            var response = await EmployeeService.CreateEmployee(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// "Get Employee By Id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response =  await EmployeeService.GetById(id);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// "Get Employee By EmailAddress"
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <returns></returns>
        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee(string emailaddress)
        {
            var response = await EmployeeService.GetEmployee(emailaddress);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// "Updates On Employee By Fetching With Id"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeUpdateViewModel model)
        {
            var response = await EmployeeService.UpdateEmployee(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// "Delete Employee By Fetching With Id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var response = await EmployeeService.DeleteEmployee(id);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
