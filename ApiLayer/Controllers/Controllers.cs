using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using Models;
using System.Net.Sockets;
using RepoLayer;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controllers : ControllerBase
    {
        private readonly BusinessLogic _businessLayer;
        public Controllers()
        {
            this._businessLayer = new BusinessLogic();
        }



        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync(string email, string password)
        {
            bool SuccessfullLogin = await this._businessLayer.LoginAsync(email, password);
            return Ok(SuccessfullLogin);
        }


        [HttpPost("RegisterUser")]
        public async Task<ActionResult> RegisterUserAsync(string email, string password, string firstName, string lastName, string address, bool isAdmin)
        {
            bool SuccessfullyRegistered = await this._businessLayer.RegisterUserAsync(email, password, firstName, lastName, address, isAdmin);
            return Ok(SuccessfullyRegistered);
        }


        [HttpPost("ProceedAsGuest")]
        public async Task<ActionResult> ProceedAsGuestAsync(string address)
        {
            bool AsGuest = await this._businessLayer.ProceedAsGuestAsync(address);
            return Ok(AsGuest);
        }


        [HttpPut("ResetPassword")]
        public async Task<ActionResult> ResetAsync(string email, string password, string confirmNewPassword)
        {
            bool SuccessfullReset = await this._businessLayer.ResetAsync(email, password, confirmNewPassword);
            return Ok(SuccessfullReset);
        }


        [HttpGet("CreateUserProfile")]
        public async Task<List<Accounts>> CreateProfileAsync(string email)
        {
            List<Accounts> alist = await this._businessLayer.CreateProfileAsync(email);
            return alist;
        }


        [HttpPut("EditProfile")]
        public async Task<ActionResult> EditProfileAsync(string email, string password, string newPassword, string confirmNewPassword, string firstName, string lastName, string address)
        {
            bool EditedProfile = await this._businessLayer.EditProfileAsync(email, password, newPassword, confirmNewPassword, firstName, lastName, address);
            return Ok(EditedProfile);
        }


        [HttpGet("DisplayAllProducts")]
        public async Task<List<Products>> GetAllProductsAsync(int ProductAmount)
        {
            List<Products> plist = await this._businessLayer.GetAllProductsAsync(ProductAmount);
            return plist;
        }


        [HttpPost("CreateProduct")]
        public async Task<ActionResult> CreateProductAsync(string email, string productName, string productColor, int productAmount, int productPrice)
        {
            bool ProductCreated = await this._businessLayer.CreateProductAsync(email, productName, productColor, productAmount, productPrice);
            return Ok(ProductCreated);
        }


        [HttpPut("UpdateProduct")]
        public async Task<ActionResult> UpdateProductAsync(string email, string productName, string productColor, int productAmount, int productPrice)
        {
            bool ProductUpdated = await this._businessLayer.UpdateProductAsync(email, productName, productColor, productAmount, productPrice);
            return Ok(ProductUpdated);
        }


        [HttpPost("AddToCart")]
        public async Task<ActionResult> AddToCartAsync(string FK_email, string FK_productName, int orderAmount)
        {
            bool AddedToCart = await this._businessLayer.AddToCartAsync(FK_email, FK_productName, orderAmount);
            return Ok(AddedToCart);
        }


        [HttpPut("RemoveFromCart")]
        public async Task<ActionResult> RemoveFromCartAsync(int cartID)
        {
            bool RemovedFromCart = await this._businessLayer.RemoveFromCartAsync(cartID);
            return Ok(RemovedFromCart);
        }


        [HttpPost("Checkout")]
        public async Task<ActionResult> CheckoutAsync(string email, int cartID, string productName, int orderAmount)
        {
            bool CheckedOut = await this._businessLayer.CheckoutAsync(email, cartID, productName, orderAmount);
            return Ok(CheckedOut);
        }


        [HttpGet("ViewPreviousOrders")]
        public async Task<List<Orders>> GetPreviousOrdersAsync(string email)
        {
            List<Orders> olist = await this._businessLayer.GetPreviousOrdersAsync(email);
            return olist;
        }


        [HttpGet("DoesUsernameAlreadyExist")]
        public async Task<ActionResult> DoesUsernameAlreadyExistAsync(string email)
        {
            bool DoesExist = await this._businessLayer.DoesUsernameAlreadyExistAsync(email);
            return Ok(DoesExist);
        }


        [HttpGet("IsAccountAdmin")]
        public async Task<ActionResult> IsAccountAdminAsync(string email)
        {
            bool IsAccountAdmin = await this._businessLayer.IsAccountAdminAsync(email);
            return Ok(IsAccountAdmin);
        }  
    }
}
