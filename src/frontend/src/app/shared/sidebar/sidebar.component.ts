import { Component, EventEmitter, Output } from '@angular/core';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [MatSidenavModule, MatListModule, RouterModule],
  template: `
    <mat-sidenav mode="over" opened>
      <mat-nav-list>
        <a mat-list-item routerLink="/orders" (click)="close.emit()">Pedidos</a>
        <a mat-list-item routerLink="/products" (click)="close.emit()">Produtos</a>
        <a mat-list-item routerLink="/contact" (click)="close.emit()">Contato</a>
      </mat-nav-list>
    </mat-sidenav>
  `,
  styles: [`
    mat-sidenav { width: 250px; }
  `],
})
export class SidebarComponent {
  @Output() close = new EventEmitter<void>();
}