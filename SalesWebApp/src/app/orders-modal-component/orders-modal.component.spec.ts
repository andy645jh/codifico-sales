import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdersModalComponentComponent } from './orders-modal.component';

describe('OrdersModalComponentComponent', () => {
  let component: OrdersModalComponentComponent;
  let fixture: ComponentFixture<OrdersModalComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OrdersModalComponentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrdersModalComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
