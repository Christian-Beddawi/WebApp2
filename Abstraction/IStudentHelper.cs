using WebApplication2.Model1;

namespace WebApplication2.Abstraction;

public interface IStudentHelper
{
    public Student GetStudentById(List<Student> students, int id);
    public Student GetStudentByName(List<Student> students, string sName);
    public string GetSpecificDateFormat(string acceptedLanguage);
    public List<Student> UpdateStudentNameById(List<Student> students, long id, string name);
    public string UploadImage(IFormFile file);
    public List<Student> DeleteStudent(List<Student> students, int sId);
 }