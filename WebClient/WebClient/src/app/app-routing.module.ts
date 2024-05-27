import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { OrdersComponent } from './orders/orders.component';
import { OrdersAllComponent } from './orders-all/orders-all.component';
import { BasketComponent } from './basket/basket.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { OrderAllDetailsComponent } from './order-all-details/order-all-details.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {path: 'products', component: ProductsComponent},
  {path: 'products/:product_id', component: ProductDetailsComponent},
  {path: 'orders', component: OrdersComponent},
  {path: 'orders/all', component: OrdersAllComponent},
  {path: 'orders/:order_id', component: OrderDetailsComponent},
  {path: 'orders/all/:order_id', component: OrderAllDetailsComponent},
  {path: 'basket', component: BasketComponent},
  {path: 'login', component: LoginComponent},
  {path: '', redirectTo: 'login', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
