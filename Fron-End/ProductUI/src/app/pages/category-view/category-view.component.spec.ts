import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CategoryViewComponent } from './category-view.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormControl } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule, MatFormFieldControl } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

describe('CategoryViewComponent', () => {
  let component: CategoryViewComponent;
  let fixture: ComponentFixture<CategoryViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CategoryViewComponent],
      imports: [HttpClientTestingModule, MatDialogModule, MatCardModule, MatFormFieldModule, MatPaginatorModule, MatTableModule, MatInputModule,
        BrowserAnimationsModule],
      providers: [
          {provide: MatFormFieldControl, useValue: new FormControl() }
      ]
    });
    fixture = TestBed.createComponent(CategoryViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
