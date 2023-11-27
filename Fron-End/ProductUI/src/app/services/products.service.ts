import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { HttpClient } from '@angular/common/http'
import { Product } from '../models/Products';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private apiUrl = `${environment.ApiUrl}/Product`
  constructor( private http: HttpClient) { }

  GetProducts() : Observable<Product[]>{
    return this.http.get<Product[]>(this.apiUrl);
  }

  CreateProduct(product: Product) : Observable<Product[]>{
    return this.http.post<Product[]>(`${this.apiUrl}`, product)
  }
}
