import { Component } from '@angular/core';
import { OrderResponseDTO } from '../models/order-response.interface';
import { OrdersService } from '../orders.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css'
})
export class OrdersComponent {
  public userId: number = 1;
  public orders: OrderResponseDTO[] = [];

  constructor(private orderService: OrdersService, private router: Router) {}

  ngOnInit(): void {
    this.loadOrders();
  }

  public loadOrders(): void {
    this.orderService.getUserOrders(this.userId).subscribe(
      (orders: OrderResponseDTO[]) => { this.orders = orders; },
      (error)=>{console.error('Error fetching user orders:', error);}
    );
  }

  public onChosenRow(event: OrderResponseDTO): void {
    let path = "orders/" + event.id;

    this.router.navigateByUrl(path);
  }
}
