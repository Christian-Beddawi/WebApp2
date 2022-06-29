using System.Globalization;
using WebApplication2.Model1;

namespace WebApplication2.Abstraction;

public class StudentHelper1 : IStudentHelper  
{
    
    public Student GetStudentById(List<Student> students, int sId)
    {
        return students.First(obj => obj.id == sId);
        throw new NotImplementedException();
    }
    
    public Student GetStudentByName(List<Student> students, string sName )
    {
        return students.First(obj => obj.name == sName);
        throw new NotImplementedException();
    }
    
    public string GetSpecificDateFormat(string acceptedLanguage)
    {
        DateTime localDate = DateTime.Now;
        CultureInfo culture = new CultureInfo(acceptedLanguage);
        return localDate.ToString(culture);
        
        throw new NotImplementedException();
    }

    public List<Student> UpdateStudentNameById(List<Student> students, int id, string name)
    {
        foreach (Student s in students)
        {
            if (s.id == id)
            {
                s.name = name;
            }
        }
        return students;
    }
}