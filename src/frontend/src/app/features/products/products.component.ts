import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ProductCardComponent } from '../../shared/product-card/product-card.component';
import { ProductService } from '../../core/product.service';
import { Observable } from 'rxjs';
import { Product } from '../../shared/models/product-model';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, ProductCardComponent, MatProgressSpinnerModule],
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  private readonly productService = inject(ProductService);

  products$: Observable<Product[]> = this.productService.products$;

  ngOnInit(): void {
    this.productService.refreshProducts().subscribe();
  }
}