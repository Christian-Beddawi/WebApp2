using System.Globalization;
using WebApplication2.Exceptions;
using WebApplication2.Model1;

namespace WebApplication2.Abstraction;

public class StudentHelper1 : IStudentHelper  
{
    
    public Student GetStudentById(List<Student> students, int sId)
    {
        foreach (Student s in students)
        {
            if (s.id == sId)
            {
                return s;
            }
        }
        throw new StudentNotFoundException("No student with the given ID!");

        throw new NotImplementedException();
    }
    
    public Student GetStudentByName(List<Student> students, string sName )
    {
        //return students.First(obj => obj.name == sName);
        foreach (Student s in students)
        {
            if (s.name == sName)
            {
                return s;
            }
        }
        throw new StudentNotFoundException("No student with the given Name!");
        throw new NotImplementedException();
    }
    
    public string GetSpecificDateFormat(string acceptedLanguage)
    {
        DateTime localDate = DateTime.Now;
        //string[] cultureNames = { "en-US", "es-ES", "fr-FR"};
        try
        {
            CultureInfo culture = new CultureInfo(acceptedLanguage);
            return localDate.ToString(culture);
        }
        catch (CultureNotFoundException ex)
        {
            return ex.Message;
        }
        
        throw new NotImplementedException();
    }

    public List<Student> UpdateStudentNameById(List<Student> students, long id, string name)
    {
        foreach (Student s in students)
        {
            if (s.id == id)
            {
                s.name = name;
                return students;
            }
        }
        throw new StudentNotFoundException("No student with the given ID!");
    }
    
    public string UploadImage(IFormFile file)
    {
        try
        {
            // getting file original name
            string fileName = file.FileName;
                
            // combining GUID to create unique name before saving in wwwroot
            //string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
            // getting full path inside wwwroot/images
            try
            {
                string ext=Path.GetExtension(fileName);
                if (ext != ".png" && ext != ".jpeg" && ext != ".jpg" && ext != ".bmp")
                    throw new InvalidFileTypeException("Unsupported file type!!");
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", fileName);
                // copying file
                file.CopyTo(new FileStream(imagePath, FileMode.Create));
                return "File Uploaded Successfully!";
            }
            catch (InvalidFileTypeException e)
            {
                return e.Message;
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    
    public List<Student> DeleteStudent(List<Student> students, int sId)
    {
        var studentToRemove = students.SingleOrDefault(r => r.id == sId);
        if (studentToRemove != null)
            students.Remove(studentToRemove);
        else
            throw new StudentNotFoundException("No student with the given ID!");
        return students;
        /*foreach (var s in students)
        {
            if (s.id == sId)
            {
                students.Remove(s);
            }
        }*/
    }

}