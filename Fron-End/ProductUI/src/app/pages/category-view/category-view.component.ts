import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DeleteComponent } from 'src/app/componentes/delete/delete.component';
import { Category } from 'src/app/models/Categories';
import { CategoryService } from 'src/app/services/category.service';
import { MatPaginator} from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-category-view',
  templateUrl: './category-view.component.html',
  styleUrls: ['./category-view.component.sass']
})
export class CategoryViewComponent implements OnInit {

  categories: any;
  generalCategories: Category[] = [];

  columnsCategory = ['Category', 'Description', 'Actions', 'Delete'];
  @ViewChild(MatPaginator) paginatorCategories !: MatPaginator;

  constructor(private categoryService: CategoryService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.categoryService.GetCategories().subscribe(data => {
      this.categories = new MatTableDataSource<Category>(data);
      this.generalCategories = data;
      this.categories.paginator = this.paginatorCategories;
    })
  }

  OpenDialog(id: string, type: string) {
    this.dialog.open(DeleteComponent, {
      width: '450px',
      height: '450px',
      data: {
        id: id,
        type: type
      }
    });
  }

  searchCategory(event: Event) {
    const value = (event.target as HTMLInputElement).value;
    this.categories.filter = value;
  }
}
