import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/Products';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.sass']
})
export class ProductEditComponent implements OnInit {
  btnAction: string = "Edit";
  btnTitle: string = "Edit Product";
  product!: Product;
  id: string | null = null;

  constructor(private productService: ProductsService, private route: ActivatedRoute, private router: Router, public matSnackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');

    if (this.id !== null) {
      this.productService.GetProduct(this.id).subscribe((data) => {
        this.product = data;
      })
    }
  }

  editProduct(product: Product) {
    if (this.id !== null) {
      this.productService.EditProduct(this.id, product).subscribe((data) => {
        this.router.navigate(['/productView']);
        this.matSnackBar.open("Edit sucess", "Sucess", {
          duration: 5000
        })
      },
      erro =>{
        this.matSnackBar.open(JSON.stringify(erro.error.errors == null ? erro.error : erro.error.errors), "Error" , {
          duration: 5000
        })
      })
    }

  }
}
