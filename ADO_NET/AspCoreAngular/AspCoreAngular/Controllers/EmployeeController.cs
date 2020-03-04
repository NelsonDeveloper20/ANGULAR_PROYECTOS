using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreAngular.DataAccess;
using AspCoreAngular.Interfaces;
using AspCoreAngular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    { 
        private readonly IEmployee objemployee;

        public EmployeeController(IEmployee _objemployee)
        {
            objemployee = _objemployee;
        }
        // GET: api/Employee
        [HttpGet]
        [Route("Index")]
        public IEnumerable<Employee> Get()
        {
            return objemployee.GetAllEmployees();
        }

        // GET: api/Employee/5
        //xample api call :http://localhost:61783/api/Employee/Details/6
        [HttpGet]
        [Route("Details/{id}")]
        public Employee Details(int id)
        {
            return objemployee.GetEmployeeData(id);
        }

        // POST: api/Employee
        [HttpPost]
        [Route("Create")]
        public Int32 Create([FromBody] Employee emp)
        {
            return objemployee.AddEmployee(emp);
        }

        // PUT: api/Employee/5
        [HttpPut]
        [Route("Edit")]
        public Int32 Edit([FromBody] Employee emp)
        {
            return objemployee.UpdateEmployee(emp);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public Int32 Delete(int id)
        {
            return objemployee.DeleteEmployee(id);
        }
        [HttpGet]
        [Route("GetCityList")]
        public IEnumerable<City> Details()
        {
            return objemployee.GetCities();
        }
    }
}
