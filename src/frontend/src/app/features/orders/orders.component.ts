import { Component, inject } from '@angular/core';
import { HeaderComponent } from '../../shared/header/header.component';
import { CartService } from '../../core/cart.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [HeaderComponent, CommonModule], 
  template: `
    <app-header></app-header>
    <div class="content">
      <h2>Meus Pedidos</h2>
      <ul>
        <li *ngFor="let item of cartItems">{{ item.nome }} - R$ {{ item.preco }}</li>
      </ul>
    </div>
  `,
  styles: [`
    .content { margin-top: 64px; padding: 20px; }
  `],
})
export class OrdersComponent {
  cartService = inject(CartService);
  cartItems = this.cartService.getCartItems();
}