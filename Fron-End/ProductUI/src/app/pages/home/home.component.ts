import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/models/Categories';
import { Product } from 'src/app/models/Products';
import { CategoryService } from 'src/app/services/category.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent  implements OnInit {

  products: Product[] = [];
  generalProducts : Product[] = [];

  categories: Category[] = [];
  generalCategories : Category[] = [];

  constructor(private productService : ProductsService, private categoryService : CategoryService){}

  ngOnInit(): void {
    
    this.productService.GetProducts().subscribe(data => {
      this.products = data;
      this.generalProducts = data;
    });

    this.categoryService.GetCategory().subscribe(data => {
      this.categories = data;
      this.generalCategories = data;
    })
  }

  search(event : Event){
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase();

    this.products = this.generalProducts.filter(product => {
      return product.name.toLowerCase().includes(value);
    })
  }

  searchCategory(event : Event){
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase();

    this.categories = this.generalCategories.filter(category => {
      return category.name.toLowerCase().includes(value);
    })
  }
}
