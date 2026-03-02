import { Component, EventEmitter, Output } from '@angular/core';
import { MatListModule } from '@angular/material/list';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [MatListModule, RouterModule],
  template: `
    <mat-nav-list>
      <a mat-list-item routerLink="/orders" routerLinkActive="active" (click)="close.emit()">Pedidos</a>
      <a mat-list-item routerLink="/products" routerLinkActive="active" (click)="close.emit()">Produtos</a>
      <a mat-list-item routerLink="/contact" routerLinkActive="active" (click)="close.emit()">Contato</a>
    </mat-nav-list>
  `,
  styles: [`
    .active { background-color: rgba(0,0,0,0.05); }
  `]
})
export class SidebarComponent {
  @Output() close = new EventEmitter<void>();
}