import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddToCartComponent } from './Components/add-to-cart/add-to-cart.component';
import { CheckoutComponent } from './Components/checkout/checkout.component';
import { CreateProductComponent } from './Components/create-product/create-product.component';
import { CreateUserProfileComponent } from './Components/create-user-profile/create-user-profile.component';
import { DisplayAllProductsComponent } from './Components/display-all-products/display-all-products.component';
import { DoesUserNameAlreadyExistComponent } from './Components/does-user-name-already-exist/does-user-name-already-exist.component';
import { EditProfileComponent } from './Components/edit-profile/edit-profile.component';
import { IsAccountAdminComponent } from './Components/is-account-admin/is-account-admin.component';
import { LoginComponent } from './Components/login/login.component';
import { ProceedAsGuestComponent } from './Components/proceed-as-guest/proceed-as-guest.component';
import { RegisterUserComponent } from './Components/register-user/register-user.component';
import { RemoveFromCartComponent } from './Components/remove-from-cart/remove-from-cart.component';
import { UpdateProductComponent } from './Components/update-product/update-product.component';
import { ViewPreviousOrdersComponent } from './Components/view-previous-orders/view-previous-orders.component';

const routes: Routes = [
  {path: 'add to cart', component: AddToCartComponent },
  {path: 'checkout', component: CheckoutComponent },
  {path: 'create product', component: CreateProductComponent },
  {path: 'create user profile', component: CreateUserProfileComponent },
  {path: 'display all products', component: DisplayAllProductsComponent },
  {path: 'does username already exist', component: DoesUserNameAlreadyExistComponent },
  {path: 'edit profile', component: EditProfileComponent },
  {path: 'Is Account Admin', component: IsAccountAdminComponent },
  {path: 'login', component: LoginComponent },
  {path: 'proceed as guest', component: ProceedAsGuestComponent },
  {path: 'register user', component: RegisterUserComponent },
  {path: 'remove from cart', component: RemoveFromCartComponent },
  {path: 'reset password', component: RemoveFromCartComponent },
  {path: 'update', component:UpdateProductComponent },
  {path: 'view previous orders', component: ViewPreviousOrdersComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
