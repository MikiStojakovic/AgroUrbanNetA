import { ProductBrand } from "./productBrand";
import { ProductType } from "./productType";

export class ShopParams {
    brands: ProductBrand[] = [];
    types: ProductType[] = [];
    sort = "name";
    pageIndex = 1;
    pageSize = 6;
    search = '';
 }