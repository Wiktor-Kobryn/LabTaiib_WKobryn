import { Component } from '@angular/core';
import { OrderResponseDTO } from '../models/order-response.interface';
import { OrdersService } from '../orders.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-orders-all',
  templateUrl: './orders-all.component.html',
  styleUrl: './orders-all.component.css'
})
export class OrdersAllComponent {
  public orders: OrderResponseDTO[] = [];

  constructor(private orderService: OrdersService, private router: Router) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  public loadProducts(): void {
    this.orderService.getAllOrders().subscribe(
      (orders: OrderResponseDTO[]) => { this.orders = orders; },
      (error)=>{console.error('Error fetching user orders:', error);}
    );
  }

  public onChosenRow(event: OrderResponseDTO): void {
    let path = "orders/all/" + event.id;

    this.router.navigateByUrl(path);
  }
}
