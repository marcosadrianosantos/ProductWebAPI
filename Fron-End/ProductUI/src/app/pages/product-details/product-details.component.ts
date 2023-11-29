import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/Products';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.sass']
})
export class ProductDetailsComponent implements OnInit{

  constructor(private productService: ProductsService, private route: ActivatedRoute, private router: Router){}
  id: string | null = null;
  product? : Product;

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    if(this.id !== null){
      this.productService.GetProduct(this.id).subscribe((data => {
        this.product = data;
      }))
    }
  }

}
