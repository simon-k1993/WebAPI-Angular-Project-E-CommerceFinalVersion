import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { ShopComponent } from './shop/shop.component';
import { InfoComponent } from './core/info/info.component';
import { BasketComponent } from './basket/basket.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { authGuard } from './core/guards/auth.guard';
import { OrdersComponent } from './orders/orders.component';

const routes: Routes = [
  {path: '', component: HomeComponent, data: {breadcrumb: 'Home'}},
  {path: 'shop', component: ShopComponent, data: {breadcrumb: 'Shop'}},
  {path: 'test-error', component: TestErrorComponent},
  {path: 'basket', component: BasketComponent, data: {breadcrumb: 'Basket'}},
  {path: 'checkout',canActivate: [authGuard],component: CheckoutComponent, data: {breadcrumb: 'Checkout'}},
  {path: 'orders',canActivate: [authGuard],component: OrdersComponent, data: {breadcrumb: 'Orders'}},
  {path: 'info', component: InfoComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: 'shop', loadChildren: () => import('./shop/shop.module').then(m => m.ShopModule)},
  {path: 'basket', loadChildren: () => import('./basket/basket.module').then(m => m.BasketModule)},
  {path: 'checkout',
  loadChildren: () => import('./checkout/checkout.module').then(m => m.CheckoutModule)},
  {path: 'orders',
  loadChildren: () => import('./orders/orders.module').then(m => m.OrdersModule)},
  {path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule)},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
