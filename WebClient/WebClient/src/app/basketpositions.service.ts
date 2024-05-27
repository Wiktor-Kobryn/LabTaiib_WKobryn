import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BasketPositionResponseDTO } from './models/basketposition-response.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BasketpositionsService {
  private apiUrl: string = 'http://localhost:5022/api/BasketPositions';

  constructor(private httpClient: HttpClient) { }

  public getUserBasketPositions(userId: number): Observable<BasketPositionResponseDTO[]> {
    return this.httpClient.get<BasketPositionResponseDTO[]>(this.apiUrl + "/User/" + userId);
  }

  // public changeBasketPosition(id: number, amount: number): Observable<boolean> {
  //   return this.httpClient.get<boolean>(this.apiUrl + "/" + id, amount);
  // }
}
