import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Category } from 'src/app/models/Categories';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.sass']
})
export class DeleteComponent implements OnInit {

  inputData: any;
  category!: Category;

  constructor(private categoryService: CategoryService, 
    @Inject(MAT_DIALOG_DATA) public data: any, private ref: MatDialogRef<DeleteComponent>, public matSnackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.inputData = this.data;
      this.categoryService.GetCategory(this.inputData.id).subscribe((data) => {
        this.category = data;
      });
  }

  DeleteCategory() {
    this.categoryService.DeleteCategory(this.inputData.id).subscribe((data) => {
      this.ref.close();
      window.location.reload();
      this.matSnackBar.open("Deletion sucess", "Sucess", {
        duration: 5000
      })
    },
    erro =>{
      this.matSnackBar.open(JSON.stringify(erro.error), "Error" , {
        duration: 5000
      })
    })    
  }

  Cancel() {
    this.ref.close();
  }
}
