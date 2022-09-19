import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { AddToCartComponent } from './Components/add-to-cart/add-to-cart.component';
import { CheckoutComponent } from './Components/checkout/checkout.component';
import { CreateProductComponent } from './Components/create-product/create-product.component';
import { CreateUserProfileComponent } from './Components/create-user-profile/create-user-profile.component';
import { BlackComponent } from './Components/Detailed-Views/black/black.component';
import { GreenComponent } from './Components/Detailed-Views/green/green.component';
import { OrangeComponent } from './Components/Detailed-Views/orange/orange.component';
import { PinkComponent } from './Components/Detailed-Views/pink/pink.component';
import { PurpleComponent } from './Components/Detailed-Views/purple/purple.component';
import { RedComponent } from './Components/Detailed-Views/red/red.component';
import { TealComponent } from './Components/Detailed-Views/teal/teal.component';
import { YellowComponent } from './Components/Detailed-Views/yellow/yellow.component';
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
import { WelcomePageComponent } from './Components/welcome-page/welcome-page.component';

const routes: Routes = [
  // {path: 'add to cart', component: AddToCartComponent },
  {path: 'welcome', component: WelcomePageComponent},
  {path: 'checkout', component: CheckoutComponent },
  {path: 'create product', component: CreateProductComponent },
  {path: 'create user profile', component: CreateUserProfileComponent },
  {path: 'display', component: DisplayAllProductsComponent },
  {path: 'does username already exist', component: DoesUserNameAlreadyExistComponent },
  {path: 'edit profile', component: EditProfileComponent },
  {path: 'Is Account Admin', component: IsAccountAdminComponent },
  {path: 'login', component: LoginComponent },
  {path: 'proceed as guest', component: ProceedAsGuestComponent },
  {path: 'register user', component: RegisterUserComponent },
  {path: 'remove from cart', component: RemoveFromCartComponent },
  {path: 'reset password', component: RemoveFromCartComponent },
  {path: 'update', component:UpdateProductComponent },
  {path: 'view previous orders', component: ViewPreviousOrdersComponent },
  {path: 'black', component: BlackComponent },
  {path: 'green', component: GreenComponent },
  {path: 'orange', component: OrangeComponent },
  {path: 'pink', component: PinkComponent},
  {path: 'purple', component: PurpleComponent},
  {path: 'red', component: RedComponent},
  {path: 'teal', component: TealComponent},
  {path: 'yellow', component: YellowComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
