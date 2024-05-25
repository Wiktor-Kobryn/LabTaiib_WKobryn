import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OrderResponseDTO } from './models/order-response.interface';
import { Observable } from 'rxjs';
import { OrderPositionResponseDTO } from './models/orderposition-response.interface';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  private apiUrl: string = 'http://localhost:5022/api/Orders';

  constructor(private httpClient: HttpClient) { }

  public getAllOrders(): Observable<OrderResponseDTO[]> {
    return this.httpClient.get<OrderResponseDTO[]>(this.apiUrl);
  }

  public getUserOrders(userId: number): Observable<OrderResponseDTO[]> {
    return this.httpClient.get<OrderResponseDTO[]>(this.apiUrl + "/User/" + userId);
  }

  public getOrdersOrderPositions(id: number): Observable<OrderPositionResponseDTO[]> {
    return this.httpClient.get<OrderPositionResponseDTO[]>(this.apiUrl + "/" + id + "/OrderPositions");
  }

  public createOrderFromUserBasket(userId: number): Observable<boolean> {
    return this.httpClient.post<boolean>(this.apiUrl + "/User/" + userId, {params: null})
  }
}
