import { Component } from '@angular/core';
import { ProductResponseDTO } from '../models/product-response.interface';
import { ProductsService } from '../products.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
  public products: ProductResponseDTO[] = [];
  public order: string = '';
  public page: number = 0;
  public count: number = 10;
  public searchText: string = "";

  constructor(private productService: ProductsService, private router: Router) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  public onChosenRow(event: ProductResponseDTO): void {
    let path = "products/" + event.id;

    this.router.navigateByUrl(path);
  }

  public loadProducts(): void {
    if(this.order == "asc") {
      this.productService.getProductsAsc().subscribe(
        (products: ProductResponseDTO[]) => { this.products = products; },
        (error)=>{console.error('Error fetching products sorted asc:', error);}
      );
    } else if (this.order == "desc") {
      this.productService.getProductsDesc().subscribe(
        (products: ProductResponseDTO[]) => { this.products = products; },
        (error)=>{console.error('Error fetching products sorted desc:', error);}
      );
    } else if (this.order == "paged") {
      this.productService.getProductsPaged(this.page, this.count).subscribe(
        (products: ProductResponseDTO[]) => { this.products = products; },
        (error) => { console.error('Error fetching paged products:', error); }
      );
    } else if (this.order == "search") {
      this.productService.getProductsNamed(this.searchText).subscribe(
        (products: ProductResponseDTO[]) => { this.products = products; },
        (error)=>{console.error('Error fetching searched products:', error);}
      );
    } else {
      this.productService.getAllProducts().subscribe(
        (products: ProductResponseDTO[]) => { this.products = products; },
        (error)=>{console.error('Error fetching all products:', error);}
      );
    }
  }
}
