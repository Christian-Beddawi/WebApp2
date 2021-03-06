using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Abstraction;
using WebApplication2.Model1;

namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]")]

public class StudentsController : ControllerBase
{
    private readonly IStudentHelper _helper;
    
    public StudentsController(IStudentHelper sHelper)
    {
        _helper = sHelper;
    }
    
    private static readonly List<Student> StudentList = new List<Student>()
    {
        new Student(1,"Stud1","Stud1@gmail.com"),
        new Student(2,"Stud2","Stud2@gmail.com"),
        new Student(3,"Stud3","Stud3@gmail.com"),
        new Student(4,"Stud4","Stud4@gmail.com")
    };

    [HttpGet()]
    public async Task<List<Student>> GetStudents()
    {
        return StudentList;
    }
    
    [HttpGet()]
    [Route("{id:int}")]
    public async Task<Student> GetStudentById([FromRoute] int id)
    {
        return _helper.GetStudentById(StudentList,id);
    }
    
    [HttpGet("search")]
    public async Task<Student> GetStudentByName([FromQuery] string name)
    {
        return _helper.GetStudentByName(StudentList,name);
    }
    
    [HttpGet("date")]
    public async Task<string> GetCurrentDate([FromHeader] string acceptedLanguage)
    {
        return _helper.GetSpecificDateFormat(acceptedLanguage);
    }
    
    [HttpPost()]
    public async Task<ActionResult> AddStudent([FromBody] Student s)
    {
        StudentList.Add(s);
        return Ok();
    }
    
    [HttpPost("update")]
    public async Task<List<Student>> UpdateStudentNameById([FromBody] Student s)
    {
        return _helper.UpdateStudentNameById(StudentList, s.id, s.name);
    }
    
    [HttpDelete()]
    [Route("{id:int}")]
    public async Task<List<Student>> DeleteStudent([FromRoute] int id)
    {
        return _helper.DeleteStudent(StudentList, id);
    }

    [HttpPost("uploadImage")]
    public async Task<string> UploadImage([FromForm]IFormFile file)
    {
        return _helper.UploadImage(file);
    }

}
