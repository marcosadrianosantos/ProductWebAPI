import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ProductViewComponent } from './product-view.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { MatDialogModule } from '@angular/material/dialog';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldControl, MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { FormControl } from '@angular/forms';

describe('ProductViewComponent', () => {
  let component: ProductViewComponent;
  let fixture: ComponentFixture<ProductViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProductViewComponent],
      imports: [HttpClientTestingModule, MatDialogModule, MatCardModule, MatFormFieldModule, MatPaginatorModule, MatTableModule, MatInputModule,
                BrowserAnimationsModule],
      providers: [
        {provide: MatFormFieldControl, useValue: new FormControl() }
      ]
    });
    fixture = TestBed.createComponent(ProductViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});