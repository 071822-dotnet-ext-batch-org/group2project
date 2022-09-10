using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;

namespace RepoLayer
{
    public class DbsAccess
    {


        public async Task<bool> RegisterUserAsync(Guid accountID, string firstName, string lastName, bool isAdmin, string email, string password, string address)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO shop.Accounts (AccountId, FName, LName, IsAdmin, Email, Password, Address) VALUES (@accountID, @firstname, @lastname, @isAdmin, @email, @password, @address)", connect))// The 0 means all new accounts are employees by default
            {
                command.Parameters.AddWithValue("@accountID", accountID);
                command.Parameters.AddWithValue("@firstname", firstName);
                command.Parameters.AddWithValue("@lastname", lastName);
                command.Parameters.AddWithValue("@isAdmin", isAdmin);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
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
        }//EoM


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
        }//EoM


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
        }//EoM


        public async Task<List<Products>> GetAllProductsAsync(int productamount)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT ProductId, ProductName, PRoductColor, ProductAmount, ProductPrice, ProductSize FROM shop.Products", connect))
            {

                connect.Open(); //Open connection
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                List<Products> pList = new List<Products>();//Output is a list so make a list and put stuff in it
                while (ret.Read())
                {
                    Products p = new Products((Guid)ret[0], ret.GetString(1), ret.GetString(2), ret.GetInt32(3), ret.GetDecimal(4), ret.GetInt16(5));//Similar to SQL Inserting values after creating tables
                    pList.Add(p);
                }
                connect.Close();
                return pList;
            }
        }//EoM

        //UpdateCart (tricky)




        public async Task<List<Orders>> GetPreviousOrdersAsync(string FK_accountID)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT OrderId, FK_AccountId, OrderDate, OrderAmount, OrderTotal FROM shop.Orders", connect))
            {
                command.Parameters.AddWithValue("@fk_accountID", FK_accountID);
                connect.Open(); //Open connection
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                List<Orders> oList = new List<Orders>();//Output is a list so make a list and put stuff in it
                while (ret.Read())
                {
                    Orders o = new Orders((Guid)ret[0], (Guid)ret[1], ret.GetDateTime(2), ret.GetInt32(3), ret.GetDecimal(4));//Similar to SQL Inserting values after creating tables
                    oList.Add(o);
                }
                connect.Close();
                return oList;
            }
        }//EoM


        public async Task<List<Cart>> CartDTOAsync(Guid OrderID, Guid ProductID)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO Shop.JunctTable (FK_OrderId, FK_ProductId) VALUES (@OrderID, @ProductID)", connect))
            {
                command.Parameters.AddWithValue("@OrderID", OrderID);
                command.Parameters.AddWithValue("@ProductID", ProductID);
                connect.Open();
                SqlDataReader retu = await command.ExecuteReaderAsync();
                List<Cart> OrdList = new List<Cart>();
                while (retu.Read())
                {
                    Cart Ord = new Cart((Guid)retu[0], (Guid)retu[1]);
                    OrdList.Add(Ord);
                }
                connect.Close();
                return OrdList;
            }

        }



        public async Task<bool> CheckoutAsync(string productID, int orderAmount)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"UPDATE shop.Products SET ProductAmount = ProductAmount - @orderAmount WHERE ProductId = @productID", connect))

            {
                command.Parameters.AddWithValue("@productID", productID);
                command.Parameters.AddWithValue("@orderAmount", orderAmount);
                connect.Open();
                bool ret = (await command.ExecuteNonQueryAsync()) > 0;
                connect.Close();
                return ret;

            }
        }


        public async Task<bool> ResetAsync(string email, string password)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"UPDATE shop.Accounts SET Password = @password WHERE Email = @email", connect))
            {
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                connect.Open();
                bool ret = (await command.ExecuteNonQueryAsync()) > 0;
                connect.Close();
                return ret;
            }
        }


        public async Task<bool> CreateProductAsync(Guid accountID, Guid productID, string productName, string productColor, int productAmount, decimal productPrice, int productSize)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO shop.Products (ProductId, ProductName, PRoductColor, ProductAmount, ProductPrice, ProductSize) VALUES (@productId, @productName, @productColor, @productAmount, @productPrice, @productSize)", connect))
            {
                command.Parameters.AddWithValue("@productID", productID);
                command.Parameters.AddWithValue("@productName", productName);
                command.Parameters.AddWithValue("@productColor", productColor);
                command.Parameters.AddWithValue("@productAmount", productAmount);
                command.Parameters.AddWithValue("@productPrice", productPrice);
                command.Parameters.AddWithValue("@productSize", productSize);
                connect.Open();

                bool IsAccountAdmin = await this.IsAccountAdminAsync(accountID);
                if (IsAccountAdmin != true)
                {
                    return false;
                }
                bool ret = (await command.ExecuteNonQueryAsync()) > 0;
                connect.Close();
                return ret;
            }
        }

            

        public async Task<bool> UpdateProductAsync(Guid accountID, Guid productID, string productName, string productColor, int productAmount, decimal productPrice, int productSize)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"UPDATE shop.Products SET ProductName = @productName, PRoductColor = @productColor, ProductAmount = @productAmount, ProductPrice = @productPrice, ProductSize = @productSize WHERE ProductID = @productID", connect))

            {
                command.Parameters.AddWithValue("@productID", productID);
                command.Parameters.AddWithValue("@productName", productName);
                command.Parameters.AddWithValue("@productColor", productColor);
                command.Parameters.AddWithValue("@productAmount", productAmount);
                command.Parameters.AddWithValue("@productPrice", productPrice);
                command.Parameters.AddWithValue("@productSize", productSize);
                connect.Open();

                bool IsAccountAdmin = await this.IsAccountAdminAsync(accountID);
                if (IsAccountAdmin != true)
                {
                    return false;
                }
                bool ret = (await command.ExecuteNonQueryAsync()) > 0;
                connect.Close();
                return ret;
            }
        }


        public async Task<bool> IsAccountAdminAsync(Guid accountID)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mikael-sean-jon-project2.database.windows.net,1433;Initial Catalog=mikael-sean-jon-project2;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT IsAdmin FROM shop.Accounts WHERE AccountId = @accountID", connect))
            {
                command.Parameters.AddWithValue("@accountID", accountID);
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





        //user profile needed
    }
}//EoN
