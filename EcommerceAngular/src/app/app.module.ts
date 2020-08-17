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
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'; 
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
import { CategoryComponent } from './category/category.component';
import { CategoryRoutingModule } from './category/category-routing.module';
import { SignInComponent } from './sign-in/sign-in.component';
import { SigninRoutingModule } from './sign-in/sign-in-routing.module';
import { SignupComponent } from './signup/signup.component';
import { SignupRoutingModule } from './signup/signup-routing.module';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { AuthService } from './auth/auth.service';
import { TokenInterceptorService } from './auth/token-interceptor.service';
import { CartComponent } from './cart/cart.component';
import { CartRoutingModule } from './cart/cart-routing.module';
import { MatTableModule } from '@angular/material/table';
import {MatListModule} from '@angular/material/list';
import { OrderComponent } from './order/order.component'
import { OrderRoutingModule } from './order/order-routing.module';
import { SummaryComponent } from './summary/summary.component';
import { SummaryRoutingModule } from './summary/summary-routing.module';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProductComponent,
    CategoryComponent,
    SignupComponent,
    SignInComponent,
    CartComponent,
    OrderComponent,
    SummaryComponent,
  ],
  imports: [
    LayoutModule,
    MatSidenavModule,
    SummaryRoutingModule,
    HomeRoutingModule,
    CartRoutingModule,
    SigninRoutingModule,
    SignupRoutingModule,
    CategoryRoutingModule,
    ProductRoutingModule,
    OrderRoutingModule,
    MatGridListModule,
    MatToolbarModule,
    BrowserModule,
    MatListModule,
    MatTableModule,
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
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
    AuthService,
    { 
      provide: JWT_OPTIONS, useValue: JWT_OPTIONS 
    },
    JwtHelperService,   
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
