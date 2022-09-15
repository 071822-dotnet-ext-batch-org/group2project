import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service.spec';

@Component({
  selector: 'app-logic-component',
  templateUrl: './logic-component.component.html',
  styleUrls: ['./logic-component.component.css']
})
export class LogicComponentComponent implements OnInit {

  login: any;
  registeruser: any;
  guestaccount: any;
  resetpassword: any;
  newuser: any;
  editprofile: any;
  allproducts: any;
  createproduct: any;
  updateproduct: any;
  addproduct: any;
  removeproduct: any;
  checkout: any;
  vieworders: any;
  checkusername: any;
  checkadmin: any;

  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

    Login()
    {
      this.AR.postLogin(this.login).then(data => {
        this.login = data;
      })
    }

    RegisterUser()
    {
      this.AR.postRegisterUser(this.registeruser).then(data =>{
        this.registeruser = data;
      })

    }

    ProceedAsGuest()
    {
      this.AR.postProceedAsGuest(this.guestaccount).then(data => {
        this.guestaccount = data;
      })
    }

    ResetPassword()
    {
      this.AR.putResetPassword(this.resetpassword).then(data => {
        this.resetpassword = data;
      })
    }

    CreateUserProfile()
    {
      this.AR.getCreateUserProfile().then(data => {
        this.registeruser = data;
      })
    }

    EditProfile()
    {
      this.AR.putEditProfile(this.editprofile).then(data => {
        this.editprofile = data;
      })
    }

    DisplayAllProducts()
    {
      this.AR.getAllProducts().then(data => {
        this.allproducts = data;
      })
    }

    CreateProducts()
    {
      this.AR.postNewProduct(this.createproduct).then(data => {
        this.createproduct = data;
      })
    }

    UpdateProduct()
    {
      this.AR.putUpdateProduct(this.updateproduct).then(data => {
        this.updateproduct = data;
      })
    }

    AddToCart()
    {
      this.AR.postAddToCart(this.addproduct).then(data => {
        this.addproduct = data;
      })
    }

    RemoveFromCart()
    {
      this.AR.putRemoveFromCart(this.removeproduct).then(data => {
        this.removeproduct = data;
      })
    }

    Checkout()
    {
      this.AR.postCheckout(this.checkout).then(data => {
        this.checkout = data;
      })
    }

    ViewPreviousOrders()
    {
      this.AR.getPreviousOrders().then(data => {
        this.vieworders = data;
      })
    }

    DoesUsernameAlreadyExist()
    {
      this.AR.getUsername().then(data => {
        this.checkusername = data;
      })
    }

    IsAccountAdmin()
    {
      this.AR.getAdminAccount().then(data => {
        this.checkadmin = data;
      })
    }

}
