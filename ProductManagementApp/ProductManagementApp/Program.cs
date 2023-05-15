using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;


namespace ProductManagementApp
{
    internal class Program
    {


        static void Main(string[] args)
        {

            SqlConnection con = new SqlConnection("Data Source=IN-4LSQ8S3; Initial Catalog=ProductDB; Integrated Security=true");
            con.Open();

            while (true)
            {
               
                Console.WriteLine("Welcome to Product Management App");
                Console.WriteLine("1. Add New Product");
                Console.WriteLine("2. Get Product");
                Console.WriteLine("3. Get All Products");
                Console.WriteLine("4. Update Product");
                Console.WriteLine("5. Delete Product");

               
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("\nWrong Choice Entered. Try Again!\n");
                    continue;
                }



                
                switch (choice)
                {
                    case 1:
                        
                        AddProduct(con);
                        break;
                    case 2:
                        
                        GetProduct(con);
                        break;
                    case 3:
                        
                        GetAllProducts(con);
                        break;
                    case 4:
                        
                        UpdateProduct(con);
                        break;
                    case 5:
                        
                        DeleteProduct(con);
                        break;
                }

               
                con.Close();

            }

            static void AddProduct(SqlConnection con)
            {
                con.Open();
                Console.WriteLine("Enter product name:");
                string productName = Console.ReadLine();
                Console.WriteLine("Enter product description:");
                string productDescription = Console.ReadLine();
                Console.WriteLine("Enter quantity:");
                int quantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter price:");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                
                SqlCommand cmd = new SqlCommand("INSERT INTO Products (ProductName, ProductDescription, Quantity, Price) VALUES (@ProductName, @ProductDescription, @Quantity, @Price)", con);
                cmd.Parameters.AddWithValue("@ProductName", productName);
                cmd.Parameters.AddWithValue("@ProductDescription", productDescription);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.ExecuteNonQuery();

                con.Close();
                Console.WriteLine("Product added successfully.");
            }

            static void GetProduct(SqlConnection con)
            {
                con.Open();
                
                Console.WriteLine("Enter product ID:");
                int productID = Convert.ToInt32(Console.ReadLine());

               
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ProductID = @ProductID", con);
                cmd.Parameters.AddWithValue("@ProductID", productID);
                SqlDataReader reader = cmd.ExecuteReader();
                

               
                if (reader.Read())
                {
                    Console.WriteLine("Product Name: {0}", reader["ProductName"]);
                    Console.WriteLine("Product Description: {0}", reader["ProductDescription"]);
                    Console.WriteLine("Quantity: {0}", reader["Quantity"]);
                    Console.WriteLine("Price: {0}", reader["Price"]);
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }

                reader.Close();
            }

            static void GetAllProducts(SqlConnection con)
            {
                con.Open();
                
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", con);
                SqlDataReader reader = cmd.ExecuteReader();

                
                while (reader.Read())
                {
                    Console.WriteLine("Product Name: {0}", reader["ProductName"]);
                    Console.WriteLine("Product Description: {0}", reader["ProductDescription"]);
                    Console.WriteLine("Quantity: {0}", reader["Quantity"]);
                    Console.WriteLine("Price: {0}", reader["Price"]);
                }

                reader.Close();
            }

            static void UpdateProduct(SqlConnection con)
            {
                con.Open();
                
                Console.WriteLine("Enter product ID:");
                int productID = Convert.ToInt32(Console.ReadLine());

                
                Console.WriteLine("Enter product name:");
                string productName = Console.ReadLine();
                Console.WriteLine("Enter product description:");
                string productDescription = Console.ReadLine();
                Console.WriteLine("Enter quantity:");
                int quantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter price:");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                SqlCommand cmd = new SqlCommand("UPDATE Products SET ProductName = @ProductName, ProductDescription = @ProductDescription, Quantity = @Quantity, Price = @Price WHERE ProductID = @ProductID", con);
                cmd.Parameters.AddWithValue("@ProductName", productName);
                cmd.Parameters.AddWithValue("@ProductDescription", productDescription);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@ProductID", productID);
                cmd.ExecuteNonQuery();
                con.Close();

                
                Console.WriteLine("Product updated successfully.");
            }

            static void DeleteProduct(SqlConnection con)
            {
                con.Open();
                
                Console.WriteLine("Enter product ID:");
                int productID = Convert.ToInt32(Console.ReadLine());

               
                SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductID = @ProductID", con);
                cmd.Parameters.AddWithValue("@ProductID", productID);
                cmd.ExecuteNonQuery();

                
                con.Close();

                
                Console.WriteLine("Product deleted successfully.");
            }
        }
    }

}