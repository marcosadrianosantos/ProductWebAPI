import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductRegistrationComponent } from './pages/product-registration/product-registration.component';
import { HomeComponent } from './pages/home/home.component';
import { CategoryRegistrationComponent } from './pages/category-registration/category-registration.component';
import { ProductEditComponent } from './pages/product-edit/product-edit.component';
import { CategoryEditComponent } from './pages/category-edit/category-edit.component';
import { ProductDetailsComponent } from './pages/product-details/product-details.component';
import { CategoryDetailsComponent } from './pages/category-details/category-details.component';

const routes: Routes = [
  {path: 'productRegistration', component: ProductRegistrationComponent},
  {path: 'categoryRegistration', component: CategoryRegistrationComponent},
  {path: '', component: HomeComponent},
  {path: 'editProduct/:id', component:ProductEditComponent},
  {path: 'editCategory/:id', component: CategoryEditComponent},
  {path: 'detailsProduct/:id', component: ProductDetailsComponent},
  {path: 'detailsCategory/:id', component: CategoryDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 }
