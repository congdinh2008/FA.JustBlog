using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        public StudentsController()
        {
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = new List<Student>()
            {
                new Student()
                {
                    Id = Guid.NewGuid(),
                    Name = "Student 02",
                    DateOfBirth = DateTime.Now,
                },
                new Student()
                {
                    Id = Guid.NewGuid(),
                    Name = "Student 03",
                    DateOfBirth = DateTime.Now,
                },
                new Student()
                {
                    Id = Guid.NewGuid(),
                    Name = "Student 03",
                    DateOfBirth = DateTime.Now,
                }
            };
            return Ok(students);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Student), 200)]
        [ProducesResponseType(typeof(Student), 204)]
        public IActionResult GetById(Guid id)
        {
            var students = new List<Student>()
            {
                new Student()
                {
                    Id = Guid.NewGuid(),
                    Name = "Student 02",
                    DateOfBirth = DateTime.Now,
                },
                new Student()
                {
                    Id = Guid.NewGuid(),
                    Name = "Student 03",
                    DateOfBirth = DateTime.Now,
                },
                new Student()
                {
                    Id = Guid.NewGuid(),
                    Name = "Student 03",
                    DateOfBirth = DateTime.Now,
                }
            };
            var student = students.FirstOrDefault(x => x.Id == id);
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            return Ok(student);
        }
    }
}
