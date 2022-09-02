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


    }
}
