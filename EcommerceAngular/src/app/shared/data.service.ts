import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Category } from '../models/category.model';
import { Product } from '../models/product.model';

export const darkTheme = {
  'primary-color': '#455363',
  'background-color': '#455a64',
  'foreground-color' : '#263238',
  'text-color': '#fff'
};
export const lightTheme = {
  'primary-color': '#fff',
  'background-color': '#e5e5e5',
  'foreground-color': '#ffffff',
  'text-color': '#2d2d2d'
};

@Injectable({
  providedIn: 'root'
})
export class DataService {

  toggleDark() {
    this.setTheme(darkTheme);
  }
  toggleLight() {
    this.setTheme(lightTheme);
  }
  private setTheme(theme: {}) {
    Object.keys(theme).forEach(k =>
      document.documentElement.style.setProperty(`--${k}`, theme[k])
    );
  }
  constructor(private http: HttpClient,) { }

  public getCategoriesList(): Observable<Category[]> {
    return this.http.get<Category[]>("https://localhost:44313/api/GetCategory");
  }

  public getProductsList(): Observable<Product[]> {
    return this.http.get<Product[]>("https://localhost:44313/api/GetProduct");
  }
 
  public getProductsListByCategory(id): Observable<Product[]> {
    return this.http.get<Product[]>("https://localhost:44313/api/GetProductByCategory/" + id);
  }
  
}
