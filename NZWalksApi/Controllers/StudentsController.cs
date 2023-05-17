﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalksApi.Controllers
{
    //https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET:h ttps://localhost:portnumber/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "John", "Jane", "Mark", "Emily", "David" };
            return Ok(studentNames);
        }
    }
}
