using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;
using System.Net.Sockets;

namespace RepoLayer
{
    public class DbsAccess
    {


        public async Task<bool> RegisterUserAsync(Guid accountID, string firstName, string lastName, bool isAdmin, string email, string password, string address)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mjrevatureserver.database.windows.net,1433;Initial Catalog=mjaworskiproject1;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO shop.Accounts (AccountId, FName, LName, IsAdmin, Email, Password, Address) VALUES (@accountID, @firstname, @lastname, 0, @email, @password, @address)", connect))// The 0 means all new accounts are employees by default
            {
                command.Parameters.AddWithValue("@accountID", accountID);
                command.Parameters.AddWithValue("@firstname", firstName);
                command.Parameters.AddWithValue("@lastname", lastName);
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
            SqlConnection connect = new SqlConnection("Server=tcp:mjrevatureserver.database.windows.net,1433;Initial Catalog=mjaworskiproject1;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
            SqlConnection connect = new SqlConnection("Server=tcp:mjrevatureserver.database.windows.net,1433;Initial Catalog=mjaworskiproject1;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
            SqlConnection connect = new SqlConnection("Server=tcp:mjrevatureserver.database.windows.net,1433;Initial Catalog=mjaworskiproject1;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT ProductId, ProductName, ProductColor, ProductAmount, ProductPrice, ProductSize FROM shop.products", connect))
            {

                connect.Open(); //Open connection
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                List<Products> pList = new List<Products>();//Output is a list so make a list and put stuff in it
                while (ret.Read())
                {
                    Products p = new Products((Guid)ret[0], ret.GetString(1), ret.GetString(2), ret.GetInt16(3), ret.GetDecimal(4), ret.GetInt16(5));//Similar to SQL Inserting values after creating tables
                    pList.Add(p);
                }
                connect.Close();
                return pList;
            }
        }//EoM

        //UpdateCart (tricky)

        //Checkout (tricky)


        public async Task<List<Orders>> GetPreviousOrdersAsync(string FK_accountID)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mjrevatureserver.database.windows.net,1433;Initial Catalog=mjaworskiproject1;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT OrderId, FK_AccountId, OrderDate, OrderAmount, OrderTotal FROM shop.Orders WHERE FK_AccountId = @fk_accountID", connect))
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


        //User Profile? (does this need to be a thing in the repo layer?)

        // *Mikael Response=> I would think so. It's function is meant to update information in the database.
        // It should take the user's updates that were stored locally and then send in the information the db
        // in the form of a SQL Query. It would just be an:
        //                                          "UPDATE shop.Account"
        //                                          "SET <columnname> = <value>,... WHERE condition"






        /**
        public async Task<RegisterAccount> RegisterAccountAsync(RegisterAccount n)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mjrevatureserver.database.windows.net,1433;Initial Catalog=mjaworskiproject1;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand("p2.register_account", connect))
            {
                    command.CommandType = CommandType.StoredProcedure; //wanted to have the procedure generate a fresh guid but will have to refactor that another time.
                    command.Parameters.AddWithValue("@accountid", n.accountID);
                    command.Parameters.AddWithValue("@fname", n.FirstName);
                    command.Parameters.AddWithValue("@lname", n.LastName);
                    command.Parameters.AddWithValue("@isadmin", n.IsAdmin);
                    command.Parameters.AddWithValue("@email", n.Email);
                    command.Parameters.AddWithValue("@password", n.Password);
                    connect.Open();
                    int ret = await command.ExecuteNonQueryAsync();

                    if (ret > 1)
                    {
                        return n;
                    }
                    connect.Close();
                    return null;
            }
        }//EoM
        **/



        /**
        public async Task<LoginDTO> GetLoginAsync(LoginDTO login)
            {
                SqlConnection connect = new SqlConnection("Server=tcp:mjrevatureserver.database.windows.net,1433;Initial Catalog=mjaworskiproject1;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                using (SqlCommand command = new SqlCommand("SELECT Email, Password FROM p2.Accounts WHERE Email = @x AND Password = @y", stash))
                {
                    command.Parameters.AddWithValue("@X", login.EmailGrab); //allows local input to avoid outside injections with sql
                    command.Parameters.AddWithValue("@y", login.PasswordSet); //allows local input to avoid outside injections with sql
                    connect.Open();
                    SqlDataReader ret = await command.ExecuteReaderAsync();
                    LoginDTO l = null;

                    if(ret.Read())
                    {
                        l = new LoginDTO(ret.GetString(0), ret.GetString(1));
                        return l;
                    }
                    connect.Close();
                    return null;
                }
        **/


        //SPACE FOR Jon's Code 
        //==> cart, checkout, and User Profile is leftover

    }
}//EoN
