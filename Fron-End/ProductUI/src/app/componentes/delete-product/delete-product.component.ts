import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/Products';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-delete-product',
  templateUrl: './delete-product.component.html',
  styleUrls: ['./delete-product.component.sass']
})
export class DeleteProductComponent implements OnInit {
  inputData: any;
  product!: Product;

  constructor(private productService: ProductsService,
    @Inject(MAT_DIALOG_DATA) public data: any, private ref: MatDialogRef<DeleteProductComponent>, public matSnackBar: MatSnackBar) { }

    ngOnInit(): void {
      this.inputData = this.data;
        this.productService.GetProduct(this.inputData.id).subscribe((data) => {
          this.product = data;
        })
      }
      DeleteProduct() {
        this.productService.DeleteProduct(this.inputData.id).subscribe((data) => {
          this.ref.close();
          window.location.reload();
          this.matSnackBar.open("Deletion sucess", "Sucess", {
            duration: 5000
          })
        },
        erro =>{
          this.matSnackBar.open(JSON.stringify(erro.error), "Error", {
            duration: 5000
          })
        })
      }
    
      Cancel() {
        this.ref.close();
      }
    }
  

    
  

