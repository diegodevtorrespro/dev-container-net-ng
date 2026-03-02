import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from '../../core/product.service'; // Ajuste o caminho se necessário
import { HeaderComponent } from '../../shared/header/header.component';
import { ProductCardComponent } from '../../shared/product-card/product-card.component';
import { Observable } from 'rxjs';
import { Product } from '../../shared/models/product-model';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, HeaderComponent, ProductCardComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  private readonly productService = inject(ProductService);

  // Criamos o stream de dados que o template vai assinar
  products$: Observable<Product[]> = this.productService.products$;

  ngOnInit(): void {
    // Dispara a chamada ao backend .NET 6 assim que a Home carrega
    this.productService.refreshProducts().subscribe();
  }
}