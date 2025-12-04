import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

export interface Product {
  id: number;
  name: string;
  price: number;
  image: string;
}

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private cartItems = new BehaviorSubject<Product[]>([]);
  cartItems$ = this.cartItems.asObservable();

  addToCart(product: Product) {
    const current = this.cartItems.value;
    this.cartItems.next([...current, product]);
  }

  getCartCount(): number {
    return this.cartItems.value.length;
  }

  getCartItems(): Product[] {
    return this.cartItems.value;
  }
}