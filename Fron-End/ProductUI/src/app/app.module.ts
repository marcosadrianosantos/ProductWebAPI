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
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { DeleteComponent } from './componentes/delete/delete.component';
import { MatDividerModule } from '@angular/material/divider';
import { MatPaginatorModule } from '@angular/material/paginator';
import { CategoryViewComponent } from './pages/category-view/category-view.component';
import { ProductViewComponent } from './pages/product-view/product-view.component';
import {MatSnackBarModule} from '@angular/material/snack-bar';

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
    CategoryDetailsComponent,
    DeleteComponent,
    CategoryViewComponent,
    ProductViewComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatSelectModule,
    MatTableModule,
    MatDialogModule,
    MatDividerModule,
    MatPaginatorModule,
    MatSnackBarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
