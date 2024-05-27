import { Component } from '@angular/core';
import { OrderPositionResponseDTO } from '../models/orderposition-response.interface';
import { OrdersService } from '../orders.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrl: './order-details.component.css'
})
export class OrderDetailsComponent {
  public orderPositions: OrderPositionResponseDTO[] = [];
  public orderId: number = -1;

  constructor(private route: ActivatedRoute, private orderService: OrdersService, private router: Router) {
    this.loadOrderPositions();
  }

  public loadOrderPositions(): void {
    const id = this.route.snapshot.paramMap.get('order_id');

    if(id != null) {
      this.orderId = parseInt(id);

      this.orderService.getOrdersOrderPositions(parseInt(id)).subscribe(
        (orderPositions: OrderPositionResponseDTO[]) => { this.orderPositions = orderPositions; },
        (error)=>{console.error('Error fetching orders orderpositions:', error);}
      );
    }
  }
}
