import { CartItem } from "./cartItem";
import { CartType } from "./cartType";
import { nanoid } from "nanoid";

export class Cart implements CartType {
    id = nanoid();
    items: CartItem[] = [];
}