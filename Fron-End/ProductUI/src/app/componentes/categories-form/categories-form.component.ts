import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Category } from 'src/app/models/Categories';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-categories-form',
  templateUrl: './categories-form.component.html',
  styleUrls: ['./categories-form.component.sass']
})
export class CategoriesFormComponent implements OnInit{
  @Output() onSubmit = new EventEmitter<Category>();
  @Input() btnAction!: string;
  @Input() btnTitle!: string; 

  formCategory! : FormGroup;

  constructor(private categoryService : CategoryService){}

  ngOnInit(): void {
    this.formCategory = new FormGroup({
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
    });
  }

  submit()
  {
    this.onSubmit.emit(this.formCategory.value);
  }

}
