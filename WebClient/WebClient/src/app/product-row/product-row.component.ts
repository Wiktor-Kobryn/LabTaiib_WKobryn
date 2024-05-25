import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ProductResponseDTO } from '../models/product-response.interface';

@Component({
  selector: '[app-product-row]',
  templateUrl: './product-row.component.html',
  styleUrl: './product-row.component.css'
})
export class ProductRowComponent {
  //!: - wlasciwosc zostanie zainicjowana przed uzyciem - definite assignment assertion
  @Input('app-product-row') product!: ProductResponseDTO;
  @Output() chosen = new EventEmitter<ProductResponseDTO>();

  public onChooseClick(): void {
    this.chosen.emit(this.product);
  }

}
