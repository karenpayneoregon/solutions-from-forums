using Microsoft.Data.SqlClient;
using static ConfigurationLibrary.Classes.ConfigurationHelper;
using Dapper;
using System.Data;
using WorkingWithSqlServerImages.Models;


namespace WorkingWithSqlServerImages.Classes;
internal class DapperPhotoOperations
{
    public static void InsertImage(byte[] imageBytes)
    {

        var sql = "INSERT INTO [dbo].[Pictures1] ([Photo])  VALUES (@ByteArray)";

        using var cn = new SqlConnection(ConnectionString());
        var values = new { ByteArray = imageBytes};
        cn.Execute(sql, values);

    }

    public static (PhotoContainer container, bool success) ReadImage(int identifier)
    {

        var photoContainer = new PhotoContainer() { Id = identifier };
        var sql = "SELECT id, Photo FROM dbo.Pictures1 WHERE dbo.Pictures1.id = @id;";

        using var cn = new SqlConnection(ConnectionString());
        var values = new { id = identifier };
        var container = cn.QueryFirstOrDefault<ImageContainer>(sql, values);

        if (container is null)
        {
            return (null, false);
        }

        var imageData = container.Photo;

        using (var ms = new MemoryStream(imageData, 0, imageData.Length))
        {
            ms.Write(imageData, 0, imageData.Length);
            photoContainer.Picture = Image.FromStream(ms, true);
        }

        return (photoContainer, true);
    }
}
