import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductResponseDTO } from './models/product.interface';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private httpClient: HttpClient) { }

  public get(pagination: PaginationDTO): Observable<ProductResponseDTO[]> {

    return this.httpClient.get<ProductResponseDTO[]>('link',{params:
      {page: pagination.page ?? 0,
      count: pagination.count ?? 10}});
  }

  public post(body: Product)
}
