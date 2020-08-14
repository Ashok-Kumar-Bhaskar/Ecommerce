import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import {MatSelectModule} from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatNativeDateModule } from '@angular/material/core';
import { HttpClientModule } from '@angular/common/http'; 
import { AppComponent } from './app.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle'
import { BrowserModule } from '@angular/platform-browser';
import {MatToolbarModule} from '@angular/material/toolbar';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { FooterComponent } from './layout/footer/footer.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { LayoutModule } from './layout/layout.module';
import { HomeComponent } from './home/home.component';
import {MatSidenavModule} from '@angular/material/sidenav';
import { HomeRoutingModule } from './home/home-routing.module';
import { MatButtonModule} from '@angular/material/button';
import {MatMenuModule} from '@angular/material/menu';
import { ProductComponent } from './product/product.component';
import { ProductRoutingModule } from './product/product-routing.module';
// import { CategoryComponent } from './category/category.component';
// import { CategoryRoutingModule } from './category/category-routing.module';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProductComponent,
    // CategoryComponent,
  ],
  imports: [
    LayoutModule,
    HomeRoutingModule,
    // CategoryRoutingModule,
    ProductRoutingModule,
    MatGridListModule,
    MatToolbarModule,
    BrowserModule,
    MatSlideToggleModule,
    BrowserAnimationsModule,
    CommonModule,
    MatCardModule,
    MatMenuModule, 
    MatButtonModule,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    FormsModule,
    MatIconModule,
    MatInputModule,
    MatCheckboxModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSidenavModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatIconModule,
    ReactiveFormsModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
