using LeaveApplication.Model.ViewModel;
using LeaveApplication.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LeaveApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService LeaveService;
        public LeaveController(ILeaveService leaveService)
        {
            LeaveService = leaveService;
        }
        /// <summary>
        /// "Create Leave"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateLeave")]
        public async Task<IActionResult> CreateLeave(RequestLeaveViewModel model)
        {
            var response = await LeaveService.CreateLeave(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// "Get Leave By Id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await LeaveService.GetById (id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        /// <summary>
        /// "Get Leave By EmployeeId"
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("GetByEmployeeId")]
        public async Task<IActionResult> GetByEmployeeId(string employeeId)
        {
            var response = await LeaveService.GetByEmployeeId(employeeId);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// "Updates On Leave By Fetching With Id"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdatesOnLeave")]
        public async Task<IActionResult> UpdateLeave(UpdateLeaveViewModel model)
        {
            var response = await LeaveService.UpdateLeave(model);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        /// <summary>
        /// "Delete Leave By fetching With Id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete ("DeleteLeave")]
        public async Task<IActionResult> DeleteLeave(Guid id)
        {
            var response = await LeaveService.DeleteLeave(id);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok();
        }
    }
}
