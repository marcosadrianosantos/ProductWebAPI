import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/Products';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-product-registration',
  templateUrl: './product-registration.component.html',
  styleUrls: ['./product-registration.component.sass']
})
export class ProductRegistrationComponent {
  btnAction = "Create"
  btnTitle = "Create Product"

  constructor(private productService: ProductsService, private router: Router, public matSnackBar: MatSnackBar) {

  }
  createProduct(product: Product) {
    debugger;
    this.productService.CreateProduct(product).subscribe((data) => {
      this.router.navigate(['/productView']);
      this.matSnackBar.open("Create sucess", "Sucess", {
        duration: 5000
      })
    },erro =>{
      this.matSnackBar.open(JSON.stringify(erro.error.errors == null ? erro.error : erro.error.errors), "Error" , {
        duration: 5000
      })
    })
  }

}
