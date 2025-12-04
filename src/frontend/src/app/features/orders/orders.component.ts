import { Component, inject } from '@angular/core';
import { HeaderComponent } from '../../shared/header/header.component';
import { CartService } from '../../core/cart.service';

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [HeaderComponent],
  template: `
    <app-header></app-header>
    <div class="content">
      <h2>Meus Pedidos</h2>
      <ul>
        <li *ngFor="let item of cartItems">{{ item.name }} - R$ {{ item.price }}</li>
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