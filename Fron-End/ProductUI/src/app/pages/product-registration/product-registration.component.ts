import { Component } from '@angular/core';
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

  constructor(private productService: ProductsService, private router: Router) {
    
  }
  createProduct(product: Product){
    this.productService.CreateProduct(product).subscribe((data)=>{
      this.router.navigate(['/'])
    })
  }

}
