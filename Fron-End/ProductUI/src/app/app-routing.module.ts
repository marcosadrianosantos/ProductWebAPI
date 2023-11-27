import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductRegistrationComponent } from './pages/product-registration/product-registration.component';
import { HomeComponent } from './pages/home/home.component';
import { CategoryRegistrationComponent } from './pages/category-registration/category-registration.component';

const routes: Routes = [
  {path: 'productRegistration', component: ProductRegistrationComponent},
  {path: 'categoryRegistration', component: CategoryRegistrationComponent},
  {path: '', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 }
