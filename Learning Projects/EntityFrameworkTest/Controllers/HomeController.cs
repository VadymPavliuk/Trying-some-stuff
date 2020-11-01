using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkTest.Data;

namespace EntityFrameworkTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<string> UserInfo()
        {

            User user = await _db.Users.FirstOrDefaultAsync();
            if (user != null)
            { return user.ToString(); }

            _db.Users.FirstOrDefault();

            return string.Empty;
        }

        public string WorkPlaceInfo()
        {
            WorkPlace place = _db.WorkPlaces.FirstOrDefault();
            if(place != null)
            { return place.RoomNumber; }
            return "No result";
        }

        public string CarList()
        {
            var autopark = _db.OfficeCars.Where(a => a.Model != string.Empty);
            string result = string.Empty;

            foreach (var car in autopark)
            {
                result += car.Model + ", ";
            }

            return result;
        }


        public string UserDevices()
        {
            _db.Devices.FirstOrDefault();
            return _db.Devices.FirstOrDefault().DeviceId.ToString();
        }

        public string UCAD()
        {
            var cars = _db.UserCars.Where(us => us.CarId > 0).Include(d => d.UserDevices);
            string result = string.Empty;
            foreach (var car in cars)
            {
                result += car.CarId + " , This car have next devices: ";
                foreach (var device in car.UserDevices)
                {
                    result += device.DeviceId.ToString() + " ," + Environment.NewLine;
                }
            }

            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
