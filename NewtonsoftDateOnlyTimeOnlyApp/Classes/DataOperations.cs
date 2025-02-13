using ConfigurationLibrary.Classes;
using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using NewtonsoftDateOnlyTimeOnlyApp.Models;

namespace NewtonsoftDateOnlyTimeOnlyApp.Classes;

internal class DataOperations
{
    /// <summary>
    /// Reads data from the database using a SQL query and deserializes it into a JSON format.
    /// </summary>
    /// <remarks>
    /// This method demonstrates how to work with <see cref="DateOnly"/> and <see cref="TimeOnly"/> types 
    /// using a <see cref="SqlDataReader"/>. It retrieves data from the database, maps it to a 
    /// <see cref="VisitorLog"/> object, and serializes the object to JSON for display.
    /// </remarks>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static async Task Read()
    {
        Helpers.PrintSampleName();
        var statement =
            "SELECT VL.VisitOn, VL.EnteredTime, VL.ExitedTime FROM Visitor AS V " + 
            "INNER JOIN VisitorLog AS VL ON V.VisitorIdentifier = VL.VisitorIdentifier WHERE (V.VisitorIdentifier = 1);";

        // connection string different from appsettings.json
        await using SqlConnection cn = new("Data Source=.\\SQLEXPRESS;Initial Catalog=TimeOnlyDatabase;Integrated Security=True;Encrypt=False");
        await using SqlCommand cmd = new() { Connection = cn, CommandText = statement };

        await cn.OpenAsync();
        await using var reader = await cmd.ExecuteReaderAsync();

        reader.Read();
        var logItem = new VisitorLog()
        {
            VisitOn = reader.GetDateOnly(0), EnteredTime = reader.GetTimeOnly(1), ExitedTime = reader.GetTimeOnly(2)
        };

        string json = JsonConvert.SerializeObject(logItem, Formatting.Indented);

        Console.WriteLine(json);

    }

    /// <summary>
    /// Reads visitor log data from the database using Dapper and custom type handlers for 
    /// <see cref="DateOnly"/> and <see cref="TimeOnly"/> types, and outputs the result as a JSON string.
    /// </summary>
    /// <remarks>
    /// This method demonstrates the use of Dapper for querying data, including the use of custom type handlers 
    /// to map <see cref="DateOnly"/> and <see cref="TimeOnly"/> values from the database.
    /// </remarks>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static async Task ReadUsingDapper()
    {
        Helpers.PrintSampleName();

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        SqlMapper.AddTypeHandler(new TimeOnlyTypeHandler());

        var query = @"
            SELECT VL.VisitOn, VL.EnteredTime, VL.ExitedTime 
            FROM Visitor AS V 
            INNER JOIN VisitorLog AS VL ON V.VisitorIdentifier = VL.VisitorIdentifier 
            WHERE V.VisitorIdentifier = @VisitorId";

        await using var cn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TimeOnlyDatabase;Integrated Security=True;Encrypt=False");
        await cn.OpenAsync();

        var logItem = await cn.QueryFirstOrDefaultAsync<VisitorLog>(query, new { VisitorId = 1 });

        if (logItem != null)
        {
            string json = JsonConvert.SerializeObject(logItem, Formatting.Indented);
            Console.WriteLine(json);
        }
        else
        {
            Console.WriteLine("No visitor log found.");
        }
    }

}