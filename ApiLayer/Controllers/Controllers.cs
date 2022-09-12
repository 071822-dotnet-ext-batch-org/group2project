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




        [HttpPost("RegisterUser")]
        public async Task<ActionResult> RegisterUserAsync(Guid accountID, string firstName, string lastName, bool isAdmin, string email, string password, string address)
        {
            bool SuccessfullyRegistered = await this._businessLayer.RegisterUserAsync(accountID, firstName, lastName, isAdmin, email, password, address);
            return Ok(SuccessfullyRegistered);
        }


        [HttpGet("DoesUsernameAlreadyExist")]
        public async Task<ActionResult> DoesUsernameAlreadyExistAsync(string email)
        {
            bool DoesExist = await this._businessLayer.DoesUsernameAlreadyExistAsync(email);
            return Ok(DoesExist);
        }


        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync(string email, string password)
        {
            bool SuccessfullLogin = await this._businessLayer.LoginAsync(email, password);
            return Ok(SuccessfullLogin);
        }

        [HttpPost("TheCart")]
        public async Task<List<Cart>> CartDTOAsync(Guid orderID, Guid fK_ProductID)
        {
            List<Cart> CartItems = await this._businessLayer.CartDTOAsync(orderID, fK_ProductID);
                return CartItems;
        }


        [HttpGet("DisplayAllProducts")]
        public async Task<List<Products>> GetAllProductsAsync(int ProductAmount)
        {
            List<Products> plist = await this._businessLayer.GetAllProductsAsync(ProductAmount);
            return plist;
        }


        [HttpGet("ViewPreviousOrders")]
        public async Task<List<Orders>> GetPreviousOrdersAsync(string FK_accountID)
        {
            List<Orders> olist = await this._businessLayer.GetPreviousOrdersAsync(FK_accountID);
            return olist;
        }


        [HttpPost("TheCart")]
        public async Task<List<Cart>> CartDTOAsync(Guid orderID, Guid fK_ProductID)
        {
            List<Cart> CartItems = await this._businessLayer.CartDTOAsync(orderID, fK_ProductID);
            return CartItems;
        }


        [HttpPost("Checkout")]
        public async Task<ActionResult> CheckoutAsync(string productID, int orderAmount)
        {
            bool CheckedOut = await this._businessLayer.CheckoutAsync(productID, orderAmount);
            return Ok(CheckedOut);
        }


        [HttpPut("ResetPassword")]
        public async Task<ActionResult> ResetAsync(string email, string password)
        {
            bool SuccessfullReset = await this._businessLayer.ResetAsync(email, password);
            return Ok(SuccessfullReset);
        }

        
        [HttpPost("CreateProduct")]
        public async Task<ActionResult> CreateProductAsync(Guid accountID, Guid productID, string productName, string productColor, int productAmount, decimal productPrice, int productSize)
        {
            bool ProductCreated = await this._businessLayer.CreateProductAsync(accountID, productID, productName, productColor, productAmount, productPrice, productSize);
            return Ok(ProductCreated);
        }

       
        [HttpPut("UpdateProduct")]
        public async Task<ActionResult> UpdateProductAsync(Guid accountID, Guid productID, string productName, string productColor, int productAmount, decimal productPrice, int productSize)
        {
            bool ProductUpdated = await this._businessLayer.UpdateProductAsync(accountID, productID, productName, productColor, productAmount, productPrice, productSize);
            return Ok(ProductUpdated);
        }


        [HttpGet("IsAccountAdmin")]
        public async Task<ActionResult> IsAccountAdminAsync(Guid accountID)
        {
            bool IsAccountAdmin = await this._businessLayer.IsAccountAdminAsync(accountID);
            return Ok(IsAccountAdmin);
        }








    }
}
