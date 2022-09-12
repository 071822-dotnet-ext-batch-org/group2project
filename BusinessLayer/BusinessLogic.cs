using Models;
using RepoLayer;
using System.Net.Sockets;

namespace BusinessLayer
{
    public class BusinessLogic
    {
        private readonly DbsAccess _repoLayer;
        public BusinessLogic()
        {
            this._repoLayer = new DbsAccess();
        }


        public async Task<bool> RegisterUserAsync(Guid accountID, string firstName, string lastName, bool isAdmin, string email, string password, string address)
        {
            bool SuccessfullyRegistered = await this._repoLayer.RegisterUserAsync(accountID, firstName, lastName, isAdmin, email, password, address);
            return SuccessfullyRegistered;
        }


        public async Task<bool> DoesUsernameAlreadyExistAsync(string email)
        {
            bool DoesExist = await this._repoLayer.DoesUsernameAlreadyExistAsync(email);
            return DoesExist;
        }


        public async Task<bool> LoginAsync(string email, string password)
        {
            bool SuccessfullLogin = await this._repoLayer.LoginAsync(email, password);
            return SuccessfullLogin;
        }


        public async Task<List<Products>> GetAllProductsAsync(int ProductAmount)
        {
            List<Products> plist = await this._repoLayer.GetAllProductsAsync(ProductAmount);
            return plist;
        }


        public async Task<List<Orders>> GetPreviousOrdersAsync(string FK_accountID)
        {
            List<Orders> olist = await this._repoLayer.GetPreviousOrdersAsync(FK_accountID);
            return olist;
        }

public async Task<List<Cart>> CartDTOAsync(Guid orderID, Guid fK_ProductID)
        {
            List<Cart> ItemsCartList = await this._repoLayer.CartDTOAsync(orderID, fK_ProductID);
            return ItemsCartList;
        }


        public async Task<bool> CheckoutAsync(string productID, int orderAmount)
        {
            bool CheckedOut = await this._repoLayer.CheckoutAsync(productID, orderAmount);
            return CheckedOut;
        }


        public async Task<bool> ResetAsync(string email, string password)
        {
            bool SuccessfullReset = await this._repoLayer.ResetAsync(email, password);
            return SuccessfullReset;
        }

        public async Task<bool> CreateProductAsync(Guid accountID, Guid productID, string productName, string productColor, int productAmount, decimal productPrice, int productSize)
        {
            bool ProductCreated = await this._repoLayer.CreateProductAsync(accountID, productID, productName, productColor, productAmount, productPrice, productSize);
            return ProductCreated;
        }

        public async Task<bool> UpdateProductAsync(Guid accountID, Guid productID, string productName, string productColor, int productAmount, decimal productPrice, int productSize)
        {
            bool ProductUpdated = await this._repoLayer.UpdateProductAsync(accountID, productID, productName, productColor, productAmount, productPrice, productSize);
            return ProductUpdated;
        }


        public async Task<bool> IsAccountAdminAsync(Guid accountID)
        {
            bool IsAccountAdmin = await this._repoLayer.IsAccountAdminAsync(accountID);
            return IsAccountAdmin;
        }

    }
}
