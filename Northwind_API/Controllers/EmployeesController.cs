﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKEND_TAREA3.Backend;
using BACKEND_TAREA3.DataAccess;
using BACKEND_TAREA3.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //GET Eemployee
        // GET: api/<EmployeesController>
        [HttpGet]
        public List<Employee> Get()
        {
            var Employees = new EmployeesSC().GetEmployees().ToList();
            return Employees;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] EmployeeModel newEmployee)
        {
            new EmployeesSC().AddEmployee(newEmployee);   
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(EmployeeModel EmployeeID)
        {
            try
            {
                new EmployeesSC().DeleteEmployee(EmployeeID);
                return Ok();
            }
            catch (Exception Ex)
            {
                return ThrowInternalErrorException(Ex);
            }
            
        }

        #region helpers
        private IActionResult ThrowInternalErrorException(Exception ex)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
