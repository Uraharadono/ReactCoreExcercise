using System.Collections.Generic;
using System.Linq;
using ReactCoreExcercise.Models;

namespace ReactCoreExcercise.DatabaseMock
{

    public class EmployeeDataAccessLayer
    {
        List<EmployeeViewModel> employees = new List<EmployeeViewModel>
        {
            new EmployeeViewModel
            {
                EmployeeId= 1,
                Name= "test 1",
                City= "test 1",
                Department= "test 1",
                Gender= "test 1",
            },
            new EmployeeViewModel
            {
                EmployeeId= 2,
                Name= "test 2",
                City= "test 2",
                Department= "test 2",
                Gender= "test 2",
            },
            new EmployeeViewModel
            {
                EmployeeId=3,
                Name = "test 3",
                City= "test 3",
                Department= "test 3",
                Gender= "test 3"
            }
        };

        public IEnumerable<EmployeeViewModel> GetAllEmployees()
        {
            try
            {
                return employees.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new employee record     
        public int AddEmployee(EmployeeViewModel employee)
        {
            try
            {
                employees.Add(employee);
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar employee    
        public int UpdateEmployee(EmployeeViewModel employee)
        {
            try
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    if (employees[i].EmployeeId == employee.EmployeeId)
                    {
                        employees[i].Name = employee.Name;
                        employees[i].City = employee.City;
                        employees[i].Department = employee.Department;
                        employees[i].Gender = employee.Gender;
                    }
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular employee    
        public EmployeeViewModel GetEmployeeData(int id)
        {
            try
            {
                EmployeeViewModel employee = employees.FirstOrDefault(s => s.EmployeeId == id);
                return employee;
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular employee    
        public int DeleteEmployee(int id)
        {
            try
            {
                EmployeeViewModel emp = employees.Find(s => s.EmployeeId == id);
                employees.Remove(emp);
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Get the list of Cities    
        public List<CityViewModel> GetCities()
        {
            List<CityViewModel> lstCity = new List<CityViewModel>();
            var cty1 = new CityViewModel { CityId = 1, CityName = "Nesto 1" };
            var cty2 = new CityViewModel { CityId = 2, CityName = "Nesto 2" };
            var cty3 = new CityViewModel { CityId = 3, CityName = "Nesto 3" };
            var cty4 = new CityViewModel { CityId = 4, CityName = "Nesto 4" };
            lstCity.Add(cty1);
            lstCity.Add(cty2);
            lstCity.Add(cty3);
            lstCity.Add(cty4);
            return lstCity;
        }
    }
}
