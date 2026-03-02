import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap, catchError, throwError } from 'rxjs';
import { Product } from '../shared/models/product-model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  
  private readonly apiUrl = '/api/produtos';

  private productsSubject = new BehaviorSubject<Product[]>([]);
  
  public products$ = this.productsSubject.asObservable();

  constructor(private http: HttpClient) {}
  
  refreshProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl).pipe(
      tap((products) => {
        this.productsSubject.next(products);
      }),
      catchError((error) => {
        console.error('Erro ao buscar produtos:', error);
        return throwError(() => new Error('Falha na comunicação com a API'));
      })
    );
  }

  get currentProducts(): Product[] {
    return this.productsSubject.value;
  }
}