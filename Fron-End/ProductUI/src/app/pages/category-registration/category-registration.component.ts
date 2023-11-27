import { Component } from '@angular/core';
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
  constructor(private categoryService: CategoryService, private router: Router){
    
  }
  createCategory(category: Category){
    this.categoryService.CreateCategory(category).subscribe((data) =>{
      this.router.navigate(['/'])
    })
  }
}
