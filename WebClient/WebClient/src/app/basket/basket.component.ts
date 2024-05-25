import { Component } from '@angular/core';
import { BasketPositionResponseDTO } from '../models/basketposition-response.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { OrdersService } from '../orders.service';
import { BasketpositionsService } from '../basketpositions.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.css'
})
export class BasketComponent {
  public basketPositions: BasketPositionResponseDTO[] = [];
  public userId: number = 1;

  constructor(private basketPositionService: BasketpositionsService, private router: Router) {}

  ngOnInit(): void {
    this.loadOrders();
  }

  public loadOrders(): void {
    this.basketPositionService.getUserBasketPositions(this.userId).subscribe(
      (basketPositions: BasketPositionResponseDTO[]) => { this.basketPositions = basketPositions; },
      (error)=>{console.error('Error fetching users basket positions:', error);}
    );
  }
}