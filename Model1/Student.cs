using System.ComponentModel.DataAnnotations;
using WebApplication2.Abstraction;

namespace WebApplication2.Model1;

public class Student
{
    //properties
    [Required(ErrorMessage="Please enter your Id")]
    public long id { get; set; }
    
    [Required]
    [MinLength(4, ErrorMessage="Please enter at least 3 characters")]
    public string name { get; set; }
    
    [Required(ErrorMessage = "Please enter your email")]
    public string email { get; set; }
    
    public Student(long id, string name, string email)
    {
        this.id = id;
        this.name = name;
        this.email = email;
    }
    
    
}