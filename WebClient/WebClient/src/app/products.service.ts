import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, count } from 'rxjs';
import { ProductResponseDTO } from './models/product-response.interface';
import { ProductRequestDTO } from './models/product-request.interface';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private apiUrl: string = 'http://localhost:5022/api/Products';

  constructor(private httpClient: HttpClient) { }

  public getAllProducts(): Observable<ProductResponseDTO[]> {
      return this.httpClient.get<ProductResponseDTO[]>(this.apiUrl);
  }

  public getProductsAsc(): Observable<ProductResponseDTO[]> {
    return this.httpClient.get<ProductResponseDTO[]>(this.apiUrl + '/Asc');
  }

  public getProductsDesc(): Observable<ProductResponseDTO[]> {
    return this.httpClient.get<ProductResponseDTO[]>(this.apiUrl + '/Desc');
  }

  public getProductsPaged(page: number, count: number): Observable<ProductResponseDTO[]> {
    return this.httpClient.get<ProductResponseDTO[]>(this.apiUrl + '/Paged',
      {params: {page, pageSize: count}}
    );
  }

  public getProductsNamed(name: string): Observable<ProductResponseDTO[]> {
    return this.httpClient.get<ProductResponseDTO[]>(this.apiUrl + '/Name',
      {params: {name}}
    );
  }

  public getProductSingle(id: number): Observable<ProductResponseDTO> {
    return this.httpClient.get<ProductResponseDTO>(this.apiUrl + '/' + id);
  }

  public deleteProduct(id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.apiUrl + '/' + id);
  }

  public addProduct(product: ProductRequestDTO): Observable<boolean> {
    return this.httpClient.post<boolean>(this.apiUrl, product);
  }

  public changeProduct(id: number, product: ProductRequestDTO): Observable<boolean> {
    return this.httpClient.put<boolean>(this.apiUrl + '/' + id, product);
  }

  public activateProduct(id: number): Observable<boolean> {
    return this.httpClient.put<boolean>(this.apiUrl + '/Activate/' + id, {params: null});
  }
}
