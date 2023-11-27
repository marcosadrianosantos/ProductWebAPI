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


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProductRegistrationComponent,
    ProductsFormComponent,
    CategoryRegistrationComponent,
    CategoriesFormComponent
  ],
  imports: [
   BrowserModule,
   HttpClientModule,
   AppRoutingModule,
   FormsModule,
   ReactiveFormsModule
  ],
  providers: [ ],
  bootstrap: [AppComponent]
})
export class AppModule {}
