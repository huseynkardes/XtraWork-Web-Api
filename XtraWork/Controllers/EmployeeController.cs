﻿using Microsoft.AspNetCore.Mvc;
using XtraWork.Requests;
using XtraWork.Responses;
using XtraWork.Services;

namespace XtraWork.Controllers
{
    [ApiController]
    [Route("employee")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeResponse>>> GetAll()
        {
            var response = await _employeeService.GetAll();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponse>> Get(Guid id)
        {
            var response = await _employeeService.Get(id);
            return Ok(response);
        }

        

        [HttpPost]
        public async Task<ActionResult<EmployeeResponse>> Create([FromBody] EmployeeRequest request)
        {
            var response = await _employeeService.Create(request);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeResponse>> Update(Guid id, [FromBody] EmployeeRequest request)
        {
            var response = await _employeeService.Update(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _employeeService.Delete(id);
            return NoContent();
        }

    }
}
