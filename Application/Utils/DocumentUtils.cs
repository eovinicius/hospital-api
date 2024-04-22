namespace SistemaHospitalar.Application.Utils;

public class DocumentUtils
{
    public static string Save(string path, IFormFile document)
    {
        var DocGuid = Guid.NewGuid().ToString();
        while (File.Exists(Path.Combine(path, DocGuid)))
        {
            DocGuid = Guid.NewGuid().ToString();
        }

        var DocPath = Path.Combine(path, DocGuid);

        Stream fileStream =
            new FileStream(DocPath, FileMode.Create);

        Task task = document
            .CopyToAsync(fileStream)
            .ContinueWith(task => fileStream.Close());

        return DocGuid;
    }
}