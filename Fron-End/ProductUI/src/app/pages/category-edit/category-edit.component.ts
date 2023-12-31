import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/models/Categories';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.sass']
})
export class CategoryEditComponent implements OnInit {

  btnAction: string = "Edit";
  btnTitle: string = "Edit Category";
  category!: Category;
  id: string | null = null;

  constructor(private categoryService: CategoryService, private route: ActivatedRoute, private router: Router, public matSnackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');

    if (this.id !== null)
      this.categoryService.GetCategory(this.id).subscribe((date => {
        this.category = date;
      }))
  }

  editCategory(category: Category) {
    if (this.id !== null) {
      this.categoryService.EditCategory(this.id, category).subscribe((data) => {
        this.router.navigate(['/categoryView']);
        this.matSnackBar.open("Edit sucess", "Sucess", {
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

}
