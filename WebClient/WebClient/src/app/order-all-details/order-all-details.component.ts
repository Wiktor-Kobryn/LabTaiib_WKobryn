import { Component } from '@angular/core';
import { OrderPositionResponseDTO } from '../models/orderposition-response.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-order-all-details',
  templateUrl: './order-all-details.component.html',
  styleUrl: './order-all-details.component.css'
})
export class OrderAllDetailsComponent {
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
