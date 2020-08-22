import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Category } from '../models/category.model';
import { Product } from '../models/product.model';
import { Signin } from '../models/signin.model';
import { User } from '../models/user.model';
import { Item } from '../models/item.model';
import { Order } from '../models/order.model';
import { Inventory } from '../models/inventory.model';
import { Address } from '../models/address.model';

export const darkTheme = {
  'primary-color': '#ffd6bd',
  'background-color': '#455a64',
  'foreground-color' : '#263238',
  'text-color': '#fff'
};
export const lightTheme = {
  'primary-color': '#ffa56f',
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

  public postSigninForm(signin : Signin): Observable<any> {
    return this.http.post<any>("https://localhost:44313/token",signin);
  }

  public postSignupForm(user : User): Observable<any> {
    return this.http.post<any>("https://localhost:44313/api/PostUser", user);
  }

  public getCartItems(username : string): Observable<any> {
    return this.http.get<any>("https://localhost:44313/api/GetDetailsForCartPage/" + username);
  }

  public getUserDetails(userid : number): Observable<any> {
    return this.http.get<any>("https://localhost:44313/api/GetUser/" + userid);
  }
  
  public postItems(item : Item): Observable<any> {
    return this.http.post<any>("https://localhost:44313/api/PostItem",item);
  }

  public getAddresses(id : number): Observable<any> {
    return this.http.get<any>("https://localhost:44313/api/GetAddresses/" + id);
  }

  public postOrder(order : Order){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    return this.http.post("https://localhost:44313/api/PostOrder",order);
  }

  public postCart(id : number){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    return this.http.post<any>("https://localhost:44313/api/PostCart/"+id,httpOptions);
  }

  public putCart(id : number){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    return this.http.put<any>("https://localhost:44313/api/PutCart/"+id,httpOptions);
  }

  public getOrderid(id : number): Observable<any> {
    return this.http.get<any>("https://localhost:44313/api/GetOrdersID/" + id);
  }

  public getOrdersList(id : number): Observable<any> {
    return this.http.get<any>("https://localhost:44313/api/GetOrdersList/" + id);
  }

  public getItemsList(id : number): Observable<any> {
    return this.http.get<any>("https://localhost:44313/api/GetItemsDetails/" + id);
  }

  public putItems(cartid : number,id : number, qty:number){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    return this.http.put<any>("https://localhost:44313/api/PutItem/"+id+"/"+cartid+"/"+qty,httpOptions);
  }

  public DeleteItems(id : number){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    return this.http.delete<any>("https://localhost:44313/api/DeleteItem/"+id,httpOptions);
  }

  public postProduct(product : Product){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    return this.http.post<any>("https://localhost:44313/api/PostProduct",product);
  }
  
  public postCategory(category : Category){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    return this.http.post<any>("https://localhost:44313/api/PostCategory",category);
  }

  public getInventoryItems(): Observable<any> {
    return this.http.get<any>("https://localhost:44313/api/GetInventoryProducts");
  }

  public putInventoryItems(id : number, qty:number){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    return this.http.put<any>("https://localhost:44313/api/PutInventory/"+id+"/"+qty,httpOptions);
  }

    public getSellers(): Observable<any> {
    return this.http.get<any>("https://localhost:44313/api/GetSeller");
  }
  
  public getProdID(): Observable<any> {
    return this.http.get<any>("https://localhost:44313/api/GetProductID");
  }

  public postInventory(inventory : Inventory){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    return this.http.post<any>("https://localhost:44313/api/PostInventory",inventory);
  }

  public GetCartCommodityID(id:number, cid:number): Observable<any> {
    return this.http.get<any>("https://localhost:44313/api/GetCartCommodityID/"+id+"/"+cid);
  }

  public postAddress(address : Address){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    return this.http.post<any>("https://localhost:44313/api/PostAddress",address);
  }

  public PutStock(id : number, qty:number){
  const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
  return this.http.put<any>("https://localhost:44313/api/PutStock/"+id+"/"+qty,httpOptions);
  }
  
  public SendEmail(id:number, cid:number): Observable<any> {
    return this.http.get<any>("https://localhost:44313/api/GetEmail/"+id+"/"+cid);
  }

  public GetLastOrdersID(userid:number): Observable<any> {
    return this.http.get<any>("https://localhost:44313/api/GetLastOrdersID/"+userid);
  }

  public PostInvoice(order : Order){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    return this.http.post<any>("https://localhost:44313/api/PostInvoice",order);
  }

}
