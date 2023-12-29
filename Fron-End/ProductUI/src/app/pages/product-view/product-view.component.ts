import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DeleteComponent } from 'src/app/componentes/delete/delete.component';
import { Product } from 'src/app/models/Products';
import { ProductsService } from 'src/app/services/products.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.sass']
})
export class ProductViewComponent implements OnInit{
  
  products: any;
  generalProducts: Product[] = [];

  columnsProduct = ['Product', 'Descripiton', 'Price', 'Color', 'Category', 'Actions', 'Delete']
  @ViewChild(MatPaginator) paginatorProducts !: MatPaginator;

  constructor(private productService: ProductsService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.productService.GetProducts().subscribe(data => {
      this.products = new MatTableDataSource<Product>(data);
      this.generalProducts = data;
      this.products.paginator = this.paginatorProducts;
    });
  }

  search(event: Event) {
    const value =(event.target as HTMLInputElement).value;
    this.products.filter = value;
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

}
