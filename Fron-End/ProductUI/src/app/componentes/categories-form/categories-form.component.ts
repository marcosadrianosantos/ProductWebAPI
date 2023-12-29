import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Category } from 'src/app/models/Categories';

@Component({
  selector: 'app-categories-form',
  templateUrl: './categories-form.component.html',
  styleUrls: ['./categories-form.component.sass']
})
export class CategoriesFormComponent implements OnInit {
  @Output() onSubmit = new EventEmitter<Category>();
  @Input() btnAction!: string;
  @Input() btnTitle!: string;
  @Input() categoryDate: Category | null = null;

  formCategory!: FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.formCategory = new FormGroup({
      id: new FormControl(this.categoryDate ? this.categoryDate.id : ''),
      name: new FormControl(this.categoryDate ? this.categoryDate.name : '', [Validators.required]),
      description: new FormControl(this.categoryDate ? this.categoryDate.description : '', [Validators.required]),
    });
  }

  submit() {
    this.onSubmit.emit(this.formCategory.value);
  }

}
