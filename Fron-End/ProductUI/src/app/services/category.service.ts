import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Category } from '../models/Categories';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private apiUrl = `${environment.ApiUrl}/Category`
  constructor( private http: HttpClient) { }

  GetCategory() : Observable<Category[]>{
    return this.http.get<Category[]>(this.apiUrl);
  }

  CreateCategory(category: Category) : Observable<Category[]>{
    return this.http.post<Category[]>(`${this.apiUrl}`,category)
  } 
}
