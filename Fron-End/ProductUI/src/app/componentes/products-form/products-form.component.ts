import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Category } from 'src/app/models/Categories';
import { Product } from 'src/app/models/Products';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-products-form',
  templateUrl: './products-form.component.html',
  styleUrls: ['./products-form.component.sass']
})
export class ProductsFormComponent implements OnInit {
  @Output() onSubmit = new EventEmitter<Product>();
  @Input() btnAction!: string;
  @Input() btnTitle!: string;
  @Input() productDate: Product | null = null;

  categories: Category[] = [];
  formProduct!: FormGroup;

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {

    this.formProduct = new FormGroup({
      id: new FormControl(this.productDate ? this.productDate.id : ''),
      name: new FormControl(this.productDate ? this.productDate.name : '', [Validators.required]),
      description: new FormControl(this.productDate ? this.productDate.description : '', [Validators.required]),
      price: new FormControl(this.productDate ? this.productDate.price : '', [Validators.required]),
      color: new FormControl(this.productDate ? this.productDate.color : ''),
      categoryId: new FormControl(this.productDate ? this.productDate.category.id : '', [Validators.required]),
    });

    this.categoryService.GetCategories().subscribe(data => {
      this.categories = data;
    });
  }

  submit() {
    this.onSubmit.emit(this.formProduct.value);
  }
}
