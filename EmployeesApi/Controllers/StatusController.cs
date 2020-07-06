using EmployeesApi.Controllers.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    public class StatusController : ControllerBase
    {
        ISystemTime Time;

        public StatusController(ISystemTime time)
        {
            Time = time;
        }



        //get/status
        [HttpGet("status")]
        public ActionResult GetStatus()
        {
            var response = new StatusResponse
            {
                Status = "Hello",
                CheckedBy = "me",
                LastChecked = Time.GetCurrent().AddMinutes(-15)
            };
            return Ok(response);
        }

        //1. Route Params
        [HttpGet("books/{bookId:int}")]
        public ActionResult GetABook(int bookId)
        {
            return Ok($"Getting you info for the {bookId}");
        }

        [HttpGet("blogs/{year:int}/{month:int}/{day:int}")]
        public ActionResult GetBlogPostsFor(int year, int month, int day)
        {
            return Ok($"Getting blog posts for {month}/{day}/{year}");
        }

        //2. Query strings
        [HttpGet("books")]
        public ActionResult GetBooks([FromQuery] string genre = "all")
        {
            return Ok($"getting books in {genre} genre");
        }

        //3. Headers
        [HttpGet("whoami")]
        public ActionResult WhoAmI([FromHeader(Name = "User-Agent")] string userAgent)
        {
            return Ok($"I see youre running {userAgent}");
        }
    }

    public class StatusResponse
    {
        public string Status { get; set; }
        public string CheckedBy { get; set; }
        public DateTime LastChecked { get; set; }
    }
}
