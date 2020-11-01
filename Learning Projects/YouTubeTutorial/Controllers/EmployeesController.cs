using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouTubeTutorial.Models;

namespace YouTubeTutorial.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeesRepository _employeesRepository;

        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        [HttpGet]
        public string GetEmployees(int[] ids)
        {
            return _employeesRepository.GetEmployees(new int[] { 2 }).FirstOrDefault().FirstName;
        }
        
        [HttpGet]
        public string Details(int id)
        {
            var employees = _employeesRepository.GetEmployees(new int[] { id });
            if (employees.Count != 0)
            {
                var employee = employees.FirstOrDefault();
                return string.Format($"Id: {employee.Id}, Name: {employee.FirstName}, LastName: {employee.LastName}, Email: {employee.Email}, Department:{employee.Department}");
            }
            else
            {
                return string.Empty;
            }
  
        }

        public string Index()
        {
            return "I am controller";
        }
    }
}
