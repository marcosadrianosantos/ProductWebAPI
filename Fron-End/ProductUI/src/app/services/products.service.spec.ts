import { TestBed } from '@angular/core/testing';
import { ProductsService } from './products.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/Products';

describe('ProductsService', () => {
  let service: ProductsService;
  let http: HttpClient;
  let product: Product;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports:[
        HttpClientTestingModule
      ]
    });
    service = TestBed.inject(ProductsService);
    http = TestBed.inject(HttpClient);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should be make a GET request with the correct endpoint', () => {
    const spy = spyOn(http, 'get').and.callThrough();
    service.GetProducts();
    expect(spy).toHaveBeenCalledWith('https://localhost:7228/api/Product');
  });
  
  it('should be make a GET by Id request with the correct endpoint', () => {
    const spy = spyOn(http, 'get').and.callThrough();
    service.GetProduct('1');
    expect(spy).toHaveBeenCalledWith('https://localhost:7228/api/Product/1');
  });

  it('should be make a POST request with the correct endpoint', () => {
    const spy = spyOn(http, 'post').and.callThrough();
    service.CreateProduct(product);
    expect(spy).toHaveBeenCalledWith('https://localhost:7228/api/Product', product);
  });

  it('should be make a PUT request with the correct endpoint', () => {
    const spy = spyOn(http, 'put').and.callThrough();
    service.EditProduct('1', product);
    expect(spy).toHaveBeenCalledWith('https://localhost:7228/api/Product/1', product);
  });

  it('should be make a DELETE request with the correct endpoint', () => {
    const spy = spyOn(http, 'delete').and.callThrough();
    service.DeleteProduct('1');
    expect(spy).toHaveBeenCalledWith('https://localhost:7228/api/Product/1');
  });

});
