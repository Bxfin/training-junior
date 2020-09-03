import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BlogListComponent } from './blogs/blog-list/blog-list.component';
import { BlogDetailsComponent } from './blogs/blog-details/blog-details.component';

@NgModule({
  declarations: [
    AppComponent,
    BlogListComponent,
    BlogDetailsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
