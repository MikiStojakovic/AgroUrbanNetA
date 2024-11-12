import { CartItem } from "./cartItem";
import { CartType } from "./cartType";
import { GuidGeneratorService } from "../../core/services/guid-generator.service";

export class Cart implements CartType {
    id = GuidGeneratorService.newGuid();
    items: CartItem[] = [];
}