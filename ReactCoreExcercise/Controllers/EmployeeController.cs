using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReactCoreExcercise.DatabaseMock;
using ReactCoreExcercise.Models;

namespace ReactCoreExcercise.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<EmployeeViewModel> Index()
        {
            return objemployee.GetAllEmployees();
        }

        [HttpPost]
        [Route("api/Employee/Create")]
        public int Create(EmployeeViewModel employee)
        {
            return objemployee.AddEmployee(employee);
        }

        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public EmployeeViewModel Details(int id)
        {
            return objemployee.GetEmployeeData(id);
        }

        [HttpPut]
        [Route("api/Employee/Edit")]
        public int Edit(EmployeeViewModel employee)
        {
            return objemployee.UpdateEmployee(employee);
        }

        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public int Delete(int id)
        {
            return objemployee.DeleteEmployee(id);
        }

        [HttpGet]
        [Route("api/Employee/GetCityList")]
        public IEnumerable<CityViewModel> Details()
        {
            return objemployee.GetCities();
        }
    }
}