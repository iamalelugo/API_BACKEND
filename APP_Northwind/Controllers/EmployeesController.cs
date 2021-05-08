using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKEND_TAREA3.Backend;
using BACKEND_TAREA3.DataAccess;
using BACKEND_TAREA3.Models;
using Northwind_API.Controllers;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APP_Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private EmployeesSC EmployeeSC = new EmployeesSC();

        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get()
        {
            var employee = new EmployeesSC().GetEmployees().Select( s => new EmployeeModel {
                EmployeesId = s.EmployeeId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Phone = s.HomePhone}).ToList();

            return Ok(employee);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeModel  newEmployee)
        {
            try
            {
                EmployeeSC.AddEmployee(newEmployee);
                return Ok();
            }
            catch(Exception ex)
            {
                return ThrowInternalErrorServer(ex); ;
            }
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #region helpers

        private IActionResult ThrowInternalErrorServer(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        #endregion

    }
}
