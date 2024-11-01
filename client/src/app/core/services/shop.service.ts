import { HttpClient, HttpParams } from '@angular/common/http';
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

  getProducts(brands?: ProductBrand[], types?: ProductType[]) {
    let params = new HttpParams();
    if (brands && brands.length > 0) {
      params = params.append('brands', brands.map(b => b.id).join(','));
    }

    if (types && types.length > 0) {
      params = params.append('types', types.map(t => t.id).join(','));
    }

    params = params.append('pageSize', 12);

    return this.http.get<Pagination<Product>>(this.baseUrl + 'products', {params});
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
