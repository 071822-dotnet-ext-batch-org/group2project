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


        public async Task<bool> LoginAsync(string email, string password)
        {
            bool SuccessfullLogin = await this._repoLayer.LoginAsync(email, password);
            return SuccessfullLogin;
        }


        public async Task<bool> RegisterUserAsync(string email, string password, string firstName, string lastName, string address, bool isAdmin)
        {
            bool SuccessfullyRegistered = await this._repoLayer.RegisterUserAsync(email, password, firstName, lastName, address, isAdmin);
            return SuccessfullyRegistered;
        }


        public async Task<bool> ProceedAsGuestAsync(string address)
        {
            bool AsGuest = await this._repoLayer.ProceedAsGuestAsync(address);
            return AsGuest;
        }


        public async Task<bool> ResetAsync(string email, string password, string confirmNewPassword)
        {
            bool SuccessfullReset = await this._repoLayer.ResetAsync(email, password, confirmNewPassword);
            return SuccessfullReset;
        }


        public async Task<List<Accounts>> CreateProfileAsync(string email)
        {
            List<Accounts> alist = await this._repoLayer.CreateProfileAsync(email);
            return alist;
        }


        public async Task<bool> EditProfileAsync(string email, string password, string newPassword, string confirmNewPassword, string firstName, string lastName, string address)
        {
            bool EditedProfile = await this._repoLayer.EditProfileAsync(email, password, newPassword, confirmNewPassword, firstName, lastName, address);
            return EditedProfile;
        }


        public async Task<List<Products>> GetAllProductsAsync(int ProductAmount)
        {
            List<Products> plist = await this._repoLayer.GetAllProductsAsync(ProductAmount);
            return plist;
        }


        public async Task<bool> CreateProductAsync(string email, string productName, string productColor, int productAmount, int productPrice)
        {
            bool ProductCreated = await this._repoLayer.CreateProductAsync(email, productName, productColor, productAmount, productPrice);
            return ProductCreated;
        }


        public async Task<bool> UpdateProductAsync(string email, string productName, string productColor, int productAmount, int productPrice)
        {
            bool ProductUpdated = await this._repoLayer.UpdateProductAsync(email, productName, productColor, productAmount, productPrice);
            return ProductUpdated;
        }


        public async Task<bool> AddToCartAsync(string FK_email, string FK_productName, int orderAmount)
        {
            bool AddedToCart = await this._repoLayer.AddToCartAsync(FK_email, FK_productName, orderAmount);
            return AddedToCart;
        }


        public async Task<bool> RemoveFromCartAsync(int cartID)
        {
            bool RemovedFromCart = await this._repoLayer.RemoveFromCartAsync(cartID);
            return RemovedFromCart;
        }


        public async Task<bool> CheckoutAsync(string email, int cartID, string productName, int orderAmount)
        {
            bool CheckedOut = await this._repoLayer.CheckoutAsync(email, cartID, productName, orderAmount);
            return CheckedOut;
        }


        public async Task<List<Orders>> GetPreviousOrdersAsync(string email)
        {
            List<Orders> olist = await this._repoLayer.GetPreviousOrdersAsync(email);
            return olist;
        }

        
        public async Task<bool> DoesUsernameAlreadyExistAsync(string email)
        {
            bool DoesExist = await this._repoLayer.DoesUsernameAlreadyExistAsync(email);
            return DoesExist;
        }


        public async Task<bool> IsAccountAdminAsync(string email)
        {
            bool IsAccountAdmin = await this._repoLayer.IsAccountAdminAsync(email);
            return IsAccountAdmin;
        }
    }
}
