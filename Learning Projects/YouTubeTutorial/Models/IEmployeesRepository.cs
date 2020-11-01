using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouTubeTutorial.Models
{
    public interface IEmployeesRepository
    {
        public List<Employee> GetEmployees(int[] ids);

        public void AddEmployee(Employee employee);
    }
}
