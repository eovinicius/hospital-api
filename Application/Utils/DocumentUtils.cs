namespace SistemaHospitalar.Application.Utils;

public class DocumentUtils
{
    public static string Save(IFormFile document)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Infrastructure\\images");

        Console.WriteLine(Directory.GetCurrentDirectory());

        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(document.FileName);

        var filePath = Path.Combine(path, uniqueFileName);

        var fileStream = new FileStream(filePath, FileMode.Create);

        Task task = document
            .CopyToAsync(fileStream)
            .ContinueWith(task => fileStream.Close());

        return filePath;
    }
}