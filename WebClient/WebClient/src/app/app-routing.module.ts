import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { OrdersComponent } from './orders/orders.component';
import { OrdersAllComponent } from './orders-all/orders-all.component';
import { BasketComponent } from './basket/basket.component';

const routes: Routes = [
  {path: 'products', component: ProductsComponent},
  {path: 'orders', component: OrdersComponent},
  {path: 'orders-all', component: OrdersAllComponent},
  {path: 'basket', component: BasketComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
