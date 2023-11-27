import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Category } from 'src/app/models/Categories';
import { Product } from 'src/app/models/Products';
import { CategoryService } from 'src/app/services/category.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-products-form',
  templateUrl: './products-form.component.html',
  styleUrls: ['./products-form.component.sass']
})
export class ProductsFormComponent implements OnInit{
@Output() onSubmit = new EventEmitter<Product>();
@Input() btnAction!: string;
@Input() btnTitle!: string;

  categories: Category[] = [];
  formProduct! : FormGroup;

  constructor(private categoryService : CategoryService, private productService : ProductsService){}

  ngOnInit(): void {
    this.formProduct = new FormGroup({
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      price: new FormControl('', [Validators.required]),
      color: new FormControl(''),
      categoryId: new FormControl('', [Validators.required]),
    });

    this.categoryService.GetCategory().subscribe(data => {
      this.categories = data;
    });
  }

  submit(){
    this.onSubmit.emit(this.formProduct.value);
  }
}
