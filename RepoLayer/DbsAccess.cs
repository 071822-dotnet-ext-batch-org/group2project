using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Data;

namespace RepoLayer
{
    public class DbsAccess
    {


        public async Task<bool> LoginAsync(string email, string password)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Email FROM shop.Accounts WHERE Email = @email AND Password = @password", connect))
            {
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                connect.Open();

                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    connect.Close();
                    return true;
                }
                connect.Close();
                return false;
            }
        }


        public async Task<bool> RegisterUserAsync(string email, string password, string firstName, string lastName, string address)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO shop.Accounts (Email, Password, FName, LName, Address, IsAdmin) VALUES (@email, @password, @firstname, @lastname, @address, 0)", connect))
            {
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@firstname", firstName);
                command.Parameters.AddWithValue("@lastname", lastName);
                command.Parameters.AddWithValue("@address", address);
                connect.Open();

                bool DoesUsernameExist = await this.DoesUsernameAlreadyExistAsync(email); //Use a method in the repo layer to do a 'yes' or 'no' check if username already exists
                if (DoesUsernameExist == true) //If true, username already exists
                {
                    return false; //If that is the case DO NOT execute query
                }
                bool ret = (await command.ExecuteNonQueryAsync()) == 1; //Only execute query AFTER confirming no duplicate usernames
                connect.Close();
                return ret;
            }
        }


        public async Task<bool> ProceedAsGuestAsync(string address)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO shop.Accounts (Email, Password, FName, LName, Address, IsAdmin) VALUES (RAND(), RAND(), 'GuestFName', 'GuestLname', @address, 0)", connect))
            {
                command.Parameters.AddWithValue("@address", address);
                connect.Open();
                bool ret = (await command.ExecuteNonQueryAsync()) == 1;
                connect.Close();
                return ret;
            }
        }


        public async Task<bool> ResetAsync(string email, string password, string confirmNewPassword)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"UPDATE shop.Accounts SET Password = @password WHERE Email = @email", connect))
            {
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                connect.Open();

                if (password != confirmNewPassword)
                {
                    return false;
                }
                bool ret = (await command.ExecuteNonQueryAsync()) > 0;
                connect.Close();
                return ret;
            }
        }


        public async Task<List<Accounts>> CreateProfileAsync(string email)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Email, Password, FName, LName, Address, IsAdmin FROM shop.Accounts WHERE Email = @email", connect))
            {
                command.Parameters.AddWithValue("@email", email);
                connect.Open();

                SqlDataReader? ret = await command.ExecuteReaderAsync();
                List<Accounts> aList = new List<Accounts>();
                while (ret.Read())
                {
                    Accounts a = new Accounts(ret.GetString(0), ret.GetString(1), ret.GetString(2), ret.GetString(3), ret.GetString(4), ret.GetBoolean(5));
                    aList.Add(a);
                }
                connect.Close();
                return aList;
            }
        }


        public async Task<bool> EditProfileAsync(string email, string password, string newPassword, string confirmNewPassword, string firstName, string lastName, string address)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"UPDATE shop.Accounts SET Password = @newpassword, FName = @firstName, LName = @lastName, Address = @address WHERE Email = @email AND Password = @password", connect))
            {
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@newpassword", newPassword);
                command.Parameters.AddWithValue("@firstname", firstName);
                command.Parameters.AddWithValue("@lastname", lastName);
                command.Parameters.AddWithValue("@address", address);
                connect.Open();
                if (confirmNewPassword != newPassword)
                {
                    return false;
                }
                bool ret = (await command.ExecuteNonQueryAsync()) > 0;
                connect.Close();
                return ret;
            }
        }


        public async Task<List<Products>> GetAllProductsAsync(int productamount)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT ProductName, ProductColor, ProductAmount, ProductPrice FROM shop.Products", connect))
            {

                connect.Open(); //Open connection
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                List<Products> pList = new List<Products>();
                while (ret.Read())
                {
                    Products p = new Products(ret.GetString(0), ret.GetString(1), ret.GetInt32(2), ret.GetInt32(3));
                    pList.Add(p);
                }
                connect.Close();
                return pList;
            }
        }


        public async Task<bool> CreateProductAsync(string email, string productName, string productColor, int productAmount, int productPrice)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO shop.Products (ProductName, ProductColor, ProductAmount, ProductPrice) VALUES (@productName, @productColor, @productAmount, @productPrice)", connect))
            {
                command.Parameters.AddWithValue("@productName", productName);
                command.Parameters.AddWithValue("@productColor", productColor);
                command.Parameters.AddWithValue("@productAmount", productAmount);
                command.Parameters.AddWithValue("@productPrice", productPrice);
                connect.Open();

                bool IsAccountAdmin = await this.IsAccountAdminAsync(email);
                if (IsAccountAdmin != true)
                {
                    return false;
                }
                bool ret = (await command.ExecuteNonQueryAsync()) > 0;
                connect.Close();
                return ret;
            }
        }


        public async Task<bool> UpdateProductAsync(string email, string productName, string productColor, int productAmount, int productPrice)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"UPDATE shop.Products SET ProductColor = @productColor, ProductAmount = @productAmount, ProductPrice = @productPrice WHERE ProductName = @productName", connect))

            {
                command.Parameters.AddWithValue("@productName", productName);
                command.Parameters.AddWithValue("@productColor", productColor);
                command.Parameters.AddWithValue("@productAmount", productAmount);
                command.Parameters.AddWithValue("@productPrice", productPrice);
                connect.Open();

                bool IsAccountAdmin = await this.IsAccountAdminAsync(email);
                if (IsAccountAdmin != true)
                {
                    return false;
                }
                bool ret = (await command.ExecuteNonQueryAsync()) > 0;
                connect.Close();
                return ret;
            }
        }


        public async Task<bool> AddToCartAsync(string FK_email, string FK_productName, int orderAmount)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO Shop.Cart (Email, ProductName, OrderAmount, Subtotal) VALUES (@email, @productName, @orderAmount, @orderAmount * 10)", connect))
            {
                command.Parameters.AddWithValue("@email", FK_email);
                command.Parameters.AddWithValue("@productName", FK_productName);
                command.Parameters.AddWithValue("@orderAmount", orderAmount);
                connect.Open();
                bool IsAccountAdmin = await this.IsAccountAdminAsync(FK_email);
                if (IsAccountAdmin == true)
                {
                    return false;
                }

                bool ret = (await command.ExecuteNonQueryAsync()) > 0;
                connect.Close();
                return ret;
            }
        }


        public async Task<bool> RemoveFromCartAsync(int cartID)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"DELETE FROM shop.Cart WHERE CartId = @cartID ", connect))
            {
                command.Parameters.AddWithValue("@cartID", cartID);
                connect.Open();
                bool ret = (await command.ExecuteNonQueryAsync()) > 0;
                connect.Close();
                return ret;
            }
        }


        public async Task<bool> CheckoutAsync(string email, int cartID, string productName, int orderAmount)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO shop.Orders(CartId, Email, ProductName, OrderAmount, Subtotal) SELECT CartId, Email, ProductName, OrderAmount, Subtotal FROM shop.Cart WHERE CartId IN (@cartID) UPDATE shop.Products SET ProductAmount = ProductAmount - @orderAmount WHERE ProductName = @productName", connect))
            {
                command.Parameters.AddWithValue("@cartID", cartID);
                command.Parameters.AddWithValue("@productName", productName);
                command.Parameters.AddWithValue("@orderAmount", orderAmount);
                connect.Open();
                bool IsAccountAdmin = await this.IsAccountAdminAsync(email);
                if (IsAccountAdmin == true)
                {
                    return false;
                }
                bool ret = (await command.ExecuteNonQueryAsync()) > 0;
                connect.Close();
                return ret;
            }
        }


        public async Task<List<Orders>> GetPreviousOrdersAsync(string email)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT OrderId, CartId, Email, ProductName, OrderAmount, Subtotal, OrderDate FROM shop.Orders WHERE Email = @email", connect))
            {
                command.Parameters.AddWithValue("@email", email);
                connect.Open(); //Open connection
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                List<Orders> oList = new List<Orders>();//Output is a list so make a list and put stuff in it
                while (ret.Read())
                {
                    Orders o = new Orders(ret.GetInt32(0), ret.GetInt32(1), ret.GetString(2), ret.GetString(3), ret.GetInt32(4), ret.GetDecimal(5), ret.GetDateTime(6));
                    oList.Add(o);
                }
                connect.Close();
                return oList;
            }
        }


        public async Task<bool> DoesUsernameAlreadyExistAsync(string email)//Made purely to get a 'yes' or 'no' value before the SQL query for program to know when to stop or continue in the IF statements
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Email FROM shop.Accounts WHERE Email = @email", connect))
            {
                command.Parameters.AddWithValue("@email", email);
                connect.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    connect.Close();
                    return true;
                }
                connect.Close();
                return false;
            }
        }


        public async Task<bool> IsAccountAdminAsync(string email)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT IsAdmin FROM shop.Accounts WHERE Email = @email", connect))
            {
                command.Parameters.AddWithValue("@email", email);
                connect.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read() && ret.GetBoolean(0))
                {
                    connect.Close();
                    return true;
                }
                connect.Close();
                return false;
            }
        }
    }
}
