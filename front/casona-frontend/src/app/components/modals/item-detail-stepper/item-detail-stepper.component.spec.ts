import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemDetailStepperComponent } from './item-detail-stepper.component';

describe('ItemDetailStepperComponent', () => {
  let component: ItemDetailStepperComponent;
  let fixture: ComponentFixture<ItemDetailStepperComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItemDetailStepperComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemDetailStepperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
