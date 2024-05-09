import { Component } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
  public page: number = 0;
  public count: number = 10;

  public onPaginationSubmit(): void {
    this.getData();
  }
}
