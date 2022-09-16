import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddToCartComponent } from './Components/add-to-cart/add-to-cart.component';
import { CheckoutComponent } from './Components/checkout/checkout.component';
import { CreateProductComponent } from './Components/create-product/create-product.component';
import { CreateUserProfileComponent } from './Components/create-user-profile/create-user-profile.component';
import { DisplayAllProductsComponent } from './Components/display-all-products/display-all-products.component';
import { EditProfileComponent } from './Components/edit-profile/edit-profile.component';
import { IsAccountAdminComponent } from './Components/is-account-admin/is-account-admin.component';
import { LoginComponent } from './Components/login/login.component';
import { ProceedAsGuestComponent } from './Components/proceed-as-guest/proceed-as-guest.component';
import { RegisterUserComponent } from './Components/register-user/register-user.component';
import { RemoveFromCartComponent } from './Components/remove-from-cart/remove-from-cart.component';
import { ResetPasswordComponent } from './Components/reset-password/reset-password.component';
import { UpdateProductComponent } from './Components/update-product/update-product.component';
import { ViewPreviousOrdersComponent } from './Components/view-previous-orders/view-previous-orders.component';
import { DoesUserNameAlreadyExistComponent } from './Components/does-user-name-already-exist/does-user-name-already-exist.component';


@NgModule({
  declarations: [
    AppComponent,
    AddToCartComponent,
    CheckoutComponent,
    CreateProductComponent,
    CreateUserProfileComponent,
    DisplayAllProductsComponent,
    EditProfileComponent,
    IsAccountAdminComponent,
    LoginComponent,
    ProceedAsGuestComponent,
    RegisterUserComponent,
    RemoveFromCartComponent,
    ResetPasswordComponent,
    UpdateProductComponent,
    ViewPreviousOrdersComponent,
    DoesUserNameAlreadyExistComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
