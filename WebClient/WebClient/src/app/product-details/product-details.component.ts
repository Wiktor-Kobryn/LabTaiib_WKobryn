import { Component, Input } from '@angular/core';
import { ProductResponseDTO } from '../models/product-response.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent {
  public product!: ProductResponseDTO;

  constructor(private route: ActivatedRoute, private productService: ProductsService, private router: Router) {
    this.getProduct();
  }

  private getProduct(): void {
    const id = this.route.snapshot.paramMap.get('product_id');

    if(id != null) {
      this.productService.getProductSingle(parseInt(id)).subscribe(
        (product: ProductResponseDTO) => { this.product = product; },
        (error)=>{console.error('Error fetching single product:', error);}
      );
    }
  }

  public onActivateClick(): void {
    console.log('click');
    this.productService.activateProduct(this.product.id).subscribe(
      response => {
        console.log('Product activated:', response);
      },
      error => {
        console.error('Error activating product:', error);
      }
    );

    this.getProduct();
  }

  public onDeleteClick(): void {
    console.log('click del');
    this.productService.deleteProduct(this.product.id).subscribe(
      response => {
        this.router.navigateByUrl("products");
      },
      error => {
        console.error('Error deleting product:', error);
      }
    );
  }
}
