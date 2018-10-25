using System.Collections.Generic;
using System.Linq;
using ReactCoreExcercise.Models;

namespace ReactCoreExcercise.DatabaseMock
{

    public class EmployeeDataAccessLayer
    {
        List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

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
                    if (employees[i].EmployeeID == employee.EmployeeID)
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
                EmployeeViewModel employee = employees.FirstOrDefault(s => s.EmployeeID == id);
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
                EmployeeViewModel emp = employees.Find(s => s.EmployeeID == id);
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
            var cty1 = new CityViewModel { CityID = 1, CityName = "Nesto 1" };
            var cty2 = new CityViewModel { CityID = 2, CityName = "Nesto 2" };
            var cty3 = new CityViewModel { CityID = 3, CityName = "Nesto 3" };
            var cty4 = new CityViewModel { CityID = 4, CityName = "Nesto 4" };
            lstCity.Add(cty1);
            lstCity.Add(cty2);
            lstCity.Add(cty3);
            lstCity.Add(cty4);
            return lstCity;
        }
    }
}
