import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/models/Categories';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styleUrls: ['./category-details.component.sass']
})
export class CategoryDetailsComponent implements OnInit {
  constructor(private categoryService: CategoryService, private route: ActivatedRoute, private router: Router) { }

  id: string | null = null;
  category?: Category;

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    if (this.id !== null) {
      this.categoryService.GetCategory(this.id).subscribe((data => {
        this.category = data;
      }))
    }
  }

}
