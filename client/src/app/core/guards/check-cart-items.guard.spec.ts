import { TestBed } from '@angular/core/testing';
import { CanMatchFn } from '@angular/router';

import { checkCartItemsGuard } from './check-cart-items.guard';

describe('checkCartItemsGuard', () => {
  const executeGuard: CanMatchFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => checkCartItemsGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
