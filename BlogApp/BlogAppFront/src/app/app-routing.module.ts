import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BlogListComponent } from './blogs/blog-list/blog-list.component';
import { BlogDetailsComponent } from './blogs/blog-details/blog-details.component';
import { DashboardComponent } from './home/dashboard/dashboard.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'blogs',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: DashboardComponent
  },  
  {
    path: 'blogs',
    component: BlogListComponent
  },
  {
    path: 'blog/:id',
    component: BlogDetailsComponent
  },
  {
    path: 'blog/create',
    component: BlogDetailsComponent
  }  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
