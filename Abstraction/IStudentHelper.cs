using WebApplication2.Model1;

namespace WebApplication2.Abstraction;

public interface IStudentHelper
{
    public Student GetStudentById(List<Student> students, int id);
    public Student GetStudentByName(List<Student> students, string sName);
    public string GetSpecificDateFormat(string acceptedLanguage);
    public List<Student> UpdateStudentNameById(List<Student> students, int id, string name);

    public string UploadImage(IFormFile file);
    public List<Student> DeleteStudentById(List<Student> students, int id);

}