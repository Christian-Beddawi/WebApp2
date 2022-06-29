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
        //Console.WriteLine(localDate);
        string[] cultureNames = { "en-US", "es-ES", "fr-FR"};
        //Console.WriteLine("Accepted Language : " + acceptedLanguage);
        
        foreach (var cultureName in cultureNames)
        {
            if (cultureName == acceptedLanguage)
            {
                CultureInfo culture = new CultureInfo(cultureName);
                //Console.WriteLine("{0}: {1}", cultureName, localDate.ToString(culture));
                return localDate.ToString(culture);
            }
        }
        return "Format Not Found";
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
    
    public string UploadImage(IFormFile file)
    {
        try
        {
            // getting file original name
            string fileName = file.FileName;
                
            // combining GUID to create unique name before saving in wwwroot
            //string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
            // getting full path inside wwwroot/images
            string ext=Path.GetExtension(fileName);
            if (ext != ".png" && ext != ".jpeg" && ext != ".jpg" && ext != ".bmp")
                return "Invalid File Type!!";
            
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", fileName);
            // copying file
            file.CopyTo(new FileStream(imagePath, FileMode.Create));
            return "File Uploaded Successfully!";
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