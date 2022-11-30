using System.Data;
using System.Security;
using ConfigurationLibrary.Classes;
using Microsoft.Data.SqlClient;

namespace BasicSqlServerPasswordApp.Classes;

/// <summary>
/// * Make sure to following instructions in readme under the scripts folder before running the code.
/// * Recommend <see cref="ValidateUser3"/> others are there to see how we got there and that HASHBYTES is better than PWDCOMPARE
///   but that is up to the developer.
/// </summary>
public class DataOperations
{
    /// <summary>
    /// Validate a user name then password. Password validation is done via a SQL-Server using PWDCOMPARE which may go away in
    /// future releases of SQL-Server.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static bool ValidateUser(string username, SecureString password)
    {
        using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        using var cmd = new SqlCommand() { Connection = cn };
        cmd.CommandText = "SELECT Id from dbo.Users WHERE Username = @UserName AND PWDCOMPARE(@Password,[Password]) = 1";
        cmd.Parameters.Add("@UserName", SqlDbType.NChar).Value = username;
        cmd.Parameters.Add("@Password", SqlDbType.NChar).Value = password.ToUnSecureString();

        cn.Open();
        return cmd.ExecuteScalar() != null;

    }

    /// <summary>
    /// Validate a user name then password. Password validation is done via a SQL-Server function.
    /// It's not perfect as the password check does not validate against a user.
    /// </summary>
    public static bool ValidateUser1(string username, SecureString password)
    {
        using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        using var cmd = new SqlCommand() { Connection = cn };

        cmd.CommandText = "SELECT Id from dbo.Users WHERE Username = @UserName";
        cmd.Parameters.Add("@UserName", SqlDbType.NChar).Value = username;
        cn.Open();

        var result = cmd.ExecuteScalar();

        if (cmd.ExecuteScalar() == null)
        {
            return false;
        }

        cmd.CommandText = "SELECT [dbo].[Password_Check](@Password);";
        cmd.Parameters.Add("@Password", SqlDbType.NChar).Value = password.ToUnSecureString();


        return Convert.ToString(cmd.ExecuteScalar()) == "Valid";

    }
    /// <summary>
    /// Validate user name and password
    /// </summary>
    /// <param name="username">user name to validate</param>
    /// <param name="password">user password to validate</param>
    /// <returns>success or failure</returns>
    public static bool ValidateUser2(string username, SecureString password)
    {
        using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        using var cmd = new SqlCommand() { Connection = cn };

        cmd.CommandText = "SELECT Id from dbo.Users WHERE Username = @UserName  AND [dbo].[Password_Check](@Password) = 'Valid'";
        cmd.Parameters.Add("@UserName", SqlDbType.NChar).Value = username;
        cmd.Parameters.Add("@Password", SqlDbType.NChar).Value = password.ToUnSecureString();
        cn.Open();
        
        return Convert.ToString(cmd.ExecuteScalar()) == "1";

    }

    /// <summary>
    /// Validate user name and password, if user input matches return their primary key
    /// </summary>
    /// <param name="username">user name to validate</param>
    /// <param name="password">user password to validate</param>
    /// <returns>success and identity</returns>
    public static (bool success, int id) ValidateUser3(string username, SecureString password)
    {
        using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        using var cmd = new SqlCommand() { Connection = cn };

        cmd.CommandText = "SELECT Id from dbo.Users WHERE Username = @UserName  AND [dbo].[Password_Check](@Password) = 'Valid'";
        cmd.Parameters.Add("@UserName", SqlDbType.NChar).Value = username;
        cmd.Parameters.Add("@Password", SqlDbType.NChar).Value = password.ToUnSecureString();
        cn.Open();

        var identifier = Convert.ToInt32(Convert.ToString(cmd.ExecuteScalar()) == "1");
        return identifier > 0 ? (true, identifier) : (false, 0);
        
    }
}