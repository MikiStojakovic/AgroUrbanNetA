import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Product } from '../../shared/models/product';
import { Pagination } from '../../shared/pagination';
import { ProductType } from '../../shared/models/productType';
import { ProductBrand } from '../../shared/models/productBrand';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  private http = inject(HttpClient);
  types: ProductType[] = [];
  brands: ProductBrand[] = [];

  getProducts() {
    return this.http.get<Pagination<Product>>(this.baseUrl + 'products?pageSize=12');
  }

  getTypes() {
    if (this.types.length > 0) return;
    return this.http.get<ProductType[]>(this.baseUrl + "products/types").subscribe({
      next: response => this.types = response
    })
  }
  
  getBrands() {
    if (this.brands.length > 0) return;
    return this.http.get<ProductBrand[]>(this.baseUrl + "products/brands").subscribe({
      next: response => this.brands = response
    })
  }
}
