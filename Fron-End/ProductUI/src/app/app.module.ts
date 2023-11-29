import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { HomeComponent } from './pages/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { ProductRegistrationComponent } from './pages/product-registration/product-registration.component';
import { AppRoutingModule } from './app-routing.module';
import { ProductsFormComponent } from './componentes/products-form/products-form.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CategoryRegistrationComponent } from './pages/category-registration/category-registration.component';
import { CategoriesFormComponent } from './componentes/categories-form/categories-form.component';
import { ProductEditComponent } from './pages/product-edit/product-edit.component';
import { CategoryEditComponent } from './pages/category-edit/category-edit.component';
import { ProductDetailsComponent } from './pages/product-details/product-details.component';
import { CategoryDetailsComponent } from './pages/category-details/category-details.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// Angular Material
import {MatButtonModule} from '@angular/material/button';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProductRegistrationComponent,
    ProductsFormComponent,
    CategoryRegistrationComponent,
    CategoriesFormComponent,
    ProductEditComponent,
    CategoryEditComponent,
    ProductDetailsComponent,
    CategoryDetailsComponent
  ],
  imports: [
   BrowserModule,
   HttpClientModule,
   AppRoutingModule,
   FormsModule,
   ReactiveFormsModule,
   BrowserAnimationsModule,
   MatButtonModule
  ],
  providers: [ ],
  bootstrap: [AppComponent]
})
export class AppModule {}
