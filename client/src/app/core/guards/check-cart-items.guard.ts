import { inject } from '@angular/core';
import { CanMatchFn } from '@angular/router';
import { CartService } from '../services/cart.service';

export const checkCartItemsGuard: CanMatchFn = (route, segments) => {
  const cartService = inject(CartService);
  let x = cartService.itemCount();
  if (cartService.itemCount() === 0) return false;
  
  return true;
};
