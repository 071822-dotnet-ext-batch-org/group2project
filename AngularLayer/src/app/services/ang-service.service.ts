import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http'

  //Models Imports
    import { AddToCart } from '../Models/Add To Cart';
    import { Checkout } from '../Models/Checkout';
    import { CreateProduct } from '../Models/Create Product';
    import { CreateUserProfile } from '../Models/Create User Profile';
    import { DisplayAllProducts } from '../Models/Display All Products'; 
    import { DoesUsernameAlreadyExists } from '../Models/Does Username Exist Already';
    import { EditProfile } from '../Models/Edit Profile';
    import { IsAccountAdmin } from '../Models/Is Account Admin';
    import { Login } from '../Models/Login';
    import { ProceedAsGuest } from '../Models/Proceed As Guest';
    import { RegisterUser } from '../Models/Register User';
    import { RemoveFromCart } from '../Models/Remove From Cart';
    import { UpdateProducts } from '../Models/Update Products';
    import { ViewPreviousOrders } from '../Models/View Previous Orders';
    import { ResetPassword } from '../Models/Reset Password';
import { Product, products } from '../Models/Products';
import { CreateUserProfileComponent } from '../Components/create-user-profile/create-user-profile.component';


@Injectable({
  providedIn: 'root'
}) 

export class AngularService{

  private apiUrl = 'https://localhost:7205/swagger/index.html'

  newProduct: Product [] = [];

  constructor(private http: HttpClient) {}

  public apiCall(){
    return this.http.get("https://jsonplaceholder.typicode.com/todos/1")
  }

  public async getLogin(): Promise<Observable<Login>>
  {
    return this.http.get<Login>(this.apiUrl + "/Login");
  }

  public async postRegisterUser(registeruser: RegisterUser): Promise<Observable<RegisterUser>>
  {
    return this.http.post<RegisterUser>(this.apiUrl, registeruser);
  }

  public async postProceedAsGuest(guestaccount: ProceedAsGuest): Promise<Observable<ProceedAsGuest>>
  {
    return this.http.post<ProceedAsGuest>(this.apiUrl, guestaccount);
  }

  public async putResetPassword(resetpassword: ResetPassword): Promise<Observable<ResetPassword>>
  {
    return this.http.put<ResetPassword>(this.apiUrl, resetpassword)
  }

  public async getCreateUserProfile(): Promise<Observable<CreateUserProfile>>
  {
    return this.http.get<CreateUserProfile>(this.apiUrl + "/Create User Profile");
  }

  public async putEditProfile(editprofile: EditProfile): Promise<Observable<EditProfile>>
  {
    return this.http.put<EditProfile>(this.apiUrl, editprofile);
  }

  public async getAllProducts(): Promise<Observable<DisplayAllProducts[]>>
  {
    return this.http.get<DisplayAllProducts[]>(this.apiUrl + "/Display All Products");
  }

  public async postNewProduct(createproduct: CreateProduct): Promise<Observable<CreateProduct>>
  {
    return this.http.post<CreateProduct>(this.apiUrl, createproduct);
  }

  public async putUpdateProduct(updateproduct: UpdateProducts): Promise<Observable<UpdateProducts>>
  {
    return this.http.put<UpdateProducts>(this.apiUrl, updateproduct);
  }

  public AddToCart(addproduct: Product)
  {
    this.newProduct.push(addproduct);
  }

  public getItems() {
    return this.newProduct;
  }

  public clearCart() {
    this.newProduct = [];
    return this.newProduct;
  }

  public async putRemoveFromCart(removeproduct: RemoveFromCart): Promise<Observable<RemoveFromCart>>
  {
    return this.http.put<RemoveFromCart>(this.apiUrl, removeproduct);
  }

  public async postCheckout(checkout: Checkout): Promise<Observable<Checkout>>
  {
    return this.http.post<Checkout>(this.apiUrl, checkout);
  }

  public async getPreviousOrders(): Promise<Observable<ViewPreviousOrders[]>>
  {
    return this.http.get<ViewPreviousOrders[]>(this.apiUrl + "/View Previous Orders");
  }

  public async getUsername(): Promise<Observable<DoesUsernameAlreadyExists>>
  {
    return this.http.get<DoesUsernameAlreadyExists>(this.apiUrl + "/ Does Username Exist Already");
  }

  public async getAdminAccount(): Promise<Observable<IsAccountAdmin>>
  {
    return this.http.get<IsAccountAdmin>(this.apiUrl + "/Is Account Admin");
  }

}

