import { Component } from '@angular/core';
import { HeaderComponent } from '../../shared/header/header.component';
import { ProductCardComponent } from '../../shared/product-card/product-card.component';
import { Product } from '../../core/cart.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HeaderComponent, ProductCardComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  products: Product[] = [
    { id: 1, name: 'Laptop Dell', price: 2500, image: 'https://via.placeholder.com/150' },
    { id: 2, name: 'Mouse Logitech', price: 50, image: 'https://via.placeholder.com/150' },
    { id: 3, name: 'Teclado Mecânico', price: 150, image: 'https://via.placeholder.com/150' },
    // Adicione mais produtos fake conforme necessário
  ];
}