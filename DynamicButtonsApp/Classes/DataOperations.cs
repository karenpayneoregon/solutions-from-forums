using System.Data;
using DynamicButtonsApp.Classes.Containers;
using Microsoft.Data.SqlClient;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace DynamicButtonsApp.Classes
{
    public class DataOperations
    {

        /// <summary>
        /// Read all categories
        /// </summary>
        /// <returns>list of categories</returns>
        public static List<Category> ReadCategories()
        {
            var list = new List<Category>();

            using SqlConnection cn = new() { ConnectionString = ConnectionString() };
            // disregard list category, CategoryID = 9 no products
            var selectStatement = "SELECT CategoryID, CategoryName FROM dbo.Categories WHERE CategoryID <9;";

            using SqlCommand cmd = new () { Connection = cn, CommandText = selectStatement };
            cn.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Category() {Id = reader.GetInt32(0), Name = reader.GetString(1)});
            }

            return list;
            
        }
        /// <summary>
        /// Read products by category identifier
        /// </summary>
        /// <param name="identifier">category identifier</param>
        /// <returns>list of products for category</returns>
        public static List<Product> ReadProducts(int identifier)
        {
            var list = new List<Product>();

            using SqlConnection cn = new () { ConnectionString = ConnectionString() };

            var selectStatement = 
                """
                SELECT ProductID, ProductName 
                FROM dbo.Products 
                WHERE CategoryID = @Id 
                ORDER BY ProductName 
                """;

            using SqlCommand cmd = new () { Connection = cn, CommandText = selectStatement };
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = identifier;
            cn.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Product() { Id = reader.GetInt32(0), Name = reader.GetString(1) });
            }

            return list;
            
        }
    }
}
