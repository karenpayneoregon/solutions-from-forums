using System.Data;
using System.Security;
using ConfigurationLibrary.Classes;
using Microsoft.Data.SqlClient;

namespace BasicSqlServerPasswordApp.Classes;

/// <summary>
/// Make sure to following instructions in readme under the scripts folder before running the code.
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
}