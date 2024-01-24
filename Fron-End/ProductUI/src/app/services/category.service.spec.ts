import { TestBed } from '@angular/core/testing';
import { CategoryService } from './category.service';
import { HttpClient } from '@angular/common/http';
import { Category } from '../models/Categories';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('CategoryService', () => {
  let service: CategoryService;
  let http: HttpClient;
  let category: Category;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports:[
        HttpClientTestingModule
      ]
    });
    service = TestBed.inject(CategoryService);
    http = TestBed.inject(HttpClient);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should be make a GET request with the correct endpoint', () => {
    const spy = spyOn(http, 'get').and.callThrough();
    service.GetCategories();
    expect(spy).toHaveBeenCalledWith('https://localhost:7228/api/Category');
  });
  
  it('should be make a GET by Id request with the correct endpoint', () => {
    const spy = spyOn(http, 'get').and.callThrough();
    service.GetCategory('1');
    expect(spy).toHaveBeenCalledWith('https://localhost:7228/api/Category/1');
  });

  it('should be make a POST request with the correct endpoint', () => {
    const spy = spyOn(http, 'post').and.callThrough();
    service.CreateCategory(category);
    expect(spy).toHaveBeenCalledWith('https://localhost:7228/api/Category', category);
  });

  it('should be make a PUT request with the correct endpoint', () => {
    const spy = spyOn(http, 'put').and.callThrough();
    service.EditCategory('1', category);
    expect(spy).toHaveBeenCalledWith('https://localhost:7228/api/Category/1', category);
  });

  it('should be make a DELETE request with the correct endpoint', () => {
    const spy = spyOn(http, 'delete').and.callThrough();
    service.DeleteCategory('1');
    expect(spy).toHaveBeenCalledWith('https://localhost:7228/api/Category/1');
  });

});
