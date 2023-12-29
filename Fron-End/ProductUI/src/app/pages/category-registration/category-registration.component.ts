import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Category } from 'src/app/models/Categories';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-registration',
  templateUrl: './category-registration.component.html',
  styleUrls: ['./category-registration.component.sass']
})
export class CategoryRegistrationComponent {

  btnAction = "Create"
  btnTitle = "Create Category"
  constructor(private categoryService: CategoryService, private router: Router, public matSnackBar: MatSnackBar) {

  }
  createCategory(category: Category) {
    this.categoryService.CreateCategory(category).subscribe((data) => {
      this.router.navigate(['/categoryView'])
      this.matSnackBar.open("Create sucess", "Sucess", {
        duration: 5000
      })
    },
    erro =>{
      this.matSnackBar.open(JSON.stringify(erro.error.errors), "Error" , {
        duration: 5000
      })
    })
  }
}
