import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryRegistrationComponent } from './category-registration.component';

describe('CategoryRegistrationComponent', () => {
  let component: CategoryRegistrationComponent;
  let fixture: ComponentFixture<CategoryRegistrationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CategoryRegistrationComponent]
    });
    fixture = TestBed.createComponent(CategoryRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
