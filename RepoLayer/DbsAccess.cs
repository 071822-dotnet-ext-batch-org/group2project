using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;

namespace RepoLayer;
public class DbsAccess
{
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

        } //EoM

      //ticket method that checks the status for all existing tickets.    
    public async Task<List<Products>> GetAllProductsAsync(int status)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:mjrevatureserver.database.windows.net,1433;Initial Catalog=mjaworskiproject1;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand("SELECT ProductName, ProductColor, ProductPrice, ProductSize FROM p2.products WHERE ProductId = @p", connect))
            {
                command.Parameters.AddWithValue("@stat", status);
                connect.Open();
                SqlDataReader ret = await command.ExecuteReaderAsync();
                List<Products> listtickets = new List<Products>();

                while(ret.Read())
                {
                    var t = new Products(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3), ret.GetDecimal(4), ret.GetInt16(5));
                    listtickets.Add(t);
                }
                    connect.Close();
                    return listtickets;
            }

        }//EoM

        //TODO -Mikael- Finish the view past orders => figure out the error on line 96
    public async Task<Orders> GetPreviousOrdersAsync(int status)
    {
        SqlConnection connect = new SqlConnection("Server=tcp:mjrevatureserver.database.windows.net,1433;Initial Catalog=mjaworskiproject1;Persist Security Info=False;User ID=master;Password=REVATURubie$235;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand command = new SqlCommand("SELECT * FROM p2.Orders WHERE AccountId = @a", connect))
            {
                command.Parameters.AddWithValue("@a", status);
                connect.Open();
                SqlDataReader ret = await command.ExecuteReaderAsync();
                List<Orders> prevorders = new List<Orders>();

                while(ret.Read())
                {
                    var t = new Orders(ret.GetGuid(0), ret.GetGuid(1), ret.GetGuid(2), ret.GetDateTime(3), ret.GetInt32(4));
                    prevorders.Add(t);
                }
                    connect.Close();
                    return prevorders;
            }
    }
        
        
        //SPACE FOR Jon's Code 
        //==> cart, checkout, and User Profile is leftover
        

}//EoN
