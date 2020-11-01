using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouTubeTutorial.Models
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private List<Employee> _listOfEmployees;

        public EmployeesRepository()
        {
            _listOfEmployees = new List<Employee>() {
                new Employee() { Id = 1, Email = "someEmail1@dot.com", Department = "Depaertment1", FirstName = "Name1", LastName = "LastName1" },
                new Employee() { Id = 2, Email = "someEmail2@dot.com", Department = "Depaertment2", FirstName = "Name2", LastName = "LastName2" },
                new Employee() { Id = 3, Email = "someEmail3@dot.com", Department = "Depaertment3", FirstName = "Name3", LastName = "LastName3" }
            };
        }

        public void AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees(int[] ids)
        {
            List<Employee> result = new List<Employee>();
            foreach (var id in ids)
            {
                result.Add(_listOfEmployees.FirstOrDefault(e => e.Id == id));
            }

            return result;
        }
    }
}
