using Microsoft.Data.SqlClient;
using System.Data;
using SqlServerLibrary.Models;
using Dapper;

namespace SqlServerLibrary;

/// <summary>
/// Provides helper methods for interacting with SQL Server databases, including checking database existence,
/// retrieving table information, and performing operations on tables.
/// </summary>
/// <remarks>
/// This class includes static methods for common database-related tasks, such as verifying if tables are populated,
/// checking the existence of databases, truncating tables, and retrieving metadata about tables and their columns.
/// </remarks>
public class DataHelpers
{
    /// <summary>
    /// Determines whether all tables in the specified SQL Server database are populated with rows.
    /// </summary>
    /// <param name="connectionString">
    /// The connection string used to connect to the SQL Server database.
    /// </param>
    /// <returns>
    /// <c>true</c> if all tables in the database contain at least one row; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method queries the system tables to retrieve the row count for each table in the database.
    /// If any table has zero rows, the method returns <c>false</c>.
    /// </remarks>
    /// <exception cref="SqlException">
    /// Thrown when there is an issue connecting to the database or executing the query.
    /// </exception>
    public static bool TablesArePopulated(string connectionString)
    {
        using var cn = new SqlConnection(connectionString);
        using var cmd = new SqlCommand("""
        SELECT 
            T.name TableName,
            i.Rows NumberOfRows 
        FROM sys.tables T JOIN sys.sysindexes I ON T.OBJECT_ID = I.ID 
        WHERE indid IN (0,1) AND T.name <> 'sysdiagrams'
        ORDER BY i.Rows DESC,T.name
        """, cn);

        DataTable table = new DataTable();
        cn.Open();

        table.Load(cmd.ExecuteReader());
        return table.AsEnumerable()
            .All(row => row.Field<int>("NumberOfRows") > 0);

    }
     
    /// <summary>
    /// Checks if a database with the specified name exists in the SQL Server Express instance.
    /// </summary>
    /// <param name="databaseName">
    /// The name of the database to check for existence.
    /// </param>
    /// <returns>
    /// <c>true</c> if the database exists; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method connects to the SQL Server Express instance using the master database and queries for the database ID
    /// of the specified database name. If the database ID is not <c>NULL</c>, the database exists.
    /// </remarks>
    /// <exception cref="SqlException">
    /// Thrown when there is an issue connecting to the SQL Server Express instance or executing the query.
    /// </exception>
    public static bool ExpressDatabaseExists(string databaseName)
    {
        using var cn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=master;integrated security=True;Encrypt=False");
        using var cmd = new SqlCommand($"SELECT DB_ID('{databaseName}'); ", cn);

        cn.Open();
        return cmd.ExecuteScalar() != DBNull.Value;

    }

    /// <summary>
    /// Checks if a database with the specified name exists in the LocalDB instance.
    /// </summary>
    /// <param name="databaseName">
    /// The name of the database to check for existence.
    /// </param>
    /// <returns>
    /// <c>true</c> if the database exists; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method connects to the LocalDB instance using the master database and queries for the database ID
    /// of the specified database name. If the database ID is not <c>NULL</c>, the database exists.
    /// </remarks>
    /// <exception cref="SqlException">
    /// Thrown when there is an issue connecting to the LocalDB instance or executing the query.
    /// </exception>
    public static bool LocalDbDatabaseExists(string databaseName)
    {
        using var cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;integrated security=True;Encrypt=False");
        using var cmd = new SqlCommand($"SELECT DB_ID('{databaseName}'); ", cn);

        cn.Open();
        return cmd.ExecuteScalar() != DBNull.Value;

    }

    /// <summary>
    /// Truncates all rows from the specified table in the SQL Server database.
    /// </summary>
    /// <param name="connectionString">
    /// The connection string used to connect to the SQL Server database.
    /// </param>
    /// <param name="tableName">
    /// The name of the table to truncate.
    /// </param>
    /// <remarks>
    /// This method uses the SQL Server <c>TRUNCATE TABLE</c> command, which removes all rows from the table 
    /// without logging individual row deletions. Ensure that the table does not have foreign key constraints 
    /// that would prevent truncation.
    /// </remarks>
    /// <exception cref="SqlException">
    /// Thrown when there is an issue executing the SQL command, such as insufficient permissions or invalid table name.
    /// </exception>
    public static void TruncateTable(string connectionString, string tableName)
    {
        using var cn = new SqlConnection(connectionString);
        using var cmd = new SqlCommand($"TRUNCATE TABLE {tableName}); ", cn);
        cn.Open();
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Retrieves metadata information about datetime2 columns in a specified SQL Server table.
    /// </summary>
    /// <param name="connectionString">
    /// The connection string used to connect to the SQL Server database.
    /// </param>
    /// <param name="tableName">
    /// The name of the table to retrieve datetime2 column information from.
    /// </param>
    /// <returns>
    /// A tuple containing:
    /// <list type="bullet">
    /// <item>
    /// <description>A list of <see cref="SqlServerLibrary.Models.DateTimeInformation"/> objects representing the datetime2 columns in the specified table.</description>
    /// </item>
    /// <item>
    /// <description>A boolean value indicating whether the table contains any datetime2 columns.</description>
    /// </item>
    /// </list>
    /// </returns>
    /// <remarks>
    /// This method queries the INFORMATION_SCHEMA.COLUMNS view to retrieve details about columns with the 'datetime2' data type in the specified table.
    /// </remarks>
    public static (List<DateTimeInformation> list, bool hasColumns) GetDateTimeInformation1(string connectionString, string tableName)
    {
        using var cn = new SqlConnection(connectionString);

        const string query = 
            """
            SELECT 
                TABLE_NAME AS TableName,
                COLUMN_NAME AS ColumnName,
                DATETIME_PRECISION AS Precision
            FROM 
                INFORMATION_SCHEMA.COLUMNS 
            WHERE DATA_TYPE = 'datetime2' AND TABLE_NAME = @TableName;
            """;

        var dateTimeInfoList = cn.Query<DateTimeInformation>(query, new { TableName = tableName }).ToList();

        return (dateTimeInfoList, dateTimeInfoList.Any());
    }

    /// <summary>
    /// Retrieves metadata information about datetime2 columns in a specified table within a SQL Server database.
    /// </summary>
    /// <param name="connectionString">The connection string used to connect to the SQL Server database.</param>
    /// <param name="tableName">The name of the table to retrieve datetime2 column information from.</param>
    /// <returns>
    /// A tuple containing:
    /// <list type="bullet">
    /// <item>
    /// <description>A <see cref="List{T}"/> of <see cref="DateTimeInformation"/> objects representing the datetime2 columns in the specified table.</description>
    /// </item>
    /// <item>
    /// <description>A <see cref="bool"/> indicating whether the table contains any datetime2 columns.</description>
    /// </item>
    /// </list>
    /// </returns>
    /// <remarks>
    /// This method queries the <c>INFORMATION_SCHEMA.COLUMNS</c> view to identify columns with the <c>datetime2</c> data type in the specified table.
    /// </remarks>
    /// <exception cref="SqlException">Thrown when an error occurs while executing the SQL query.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the connection to the database cannot be opened.</exception>
    public static (List<DateTimeInformation> list, bool hasColumns) GetDateTimeInformation(string connectionString, string tableName)
    {
        List<DateTimeInformation> dateTimeInfoList = new();
        using var cn = new SqlConnection(connectionString);
        using var cmd = new SqlCommand(
            """
                SELECT 
                    TABLE_NAME,
                    COLUMN_NAME,
                    DATETIME_PRECISION 
                FROM 
                    INFORMATION_SCHEMA.COLUMNS 
                WHERE DATA_TYPE = 'datetime2' AND TABLE_NAME = @TableName; 
                """, cn);

        cmd.Parameters.Add("@TableName", SqlDbType.NChar).Value = tableName;

        cn.Open();

        var reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                dateTimeInfoList.Add(new DateTimeInformation()
                {
                    TableName = reader.GetString(0), 
                    ColumnName = reader.GetString(1), 
                    Precision = reader.GetInt16(2)
                });
            }

            return (dateTimeInfoList, true);
        }
        else
        {
            return (null, false)!;
        }
    }

    /// <summary>
    /// Retrieves the names of all base tables from the specified SQL Server database.
    /// </summary>
    /// <param name="connectionString">The connection string used to connect to the SQL Server database.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the names of all base tables in the database, ordered alphabetically.</returns>
    public static IEnumerable<string> GetTableNames(string connectionString)
    {
        using var connection = new SqlConnection(connectionString);
        string query = """
                       SELECT TABLE_NAME
                       FROM INFORMATION_SCHEMA.TABLES
                       WHERE TABLE_TYPE = 'BASE TABLE'
                       ORDER BY TABLE_NAME;
                       """;

        return connection.Query<string>(query);
    }
}