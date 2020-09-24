import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HalfPizzaCreateComponent } from './half-pizza-create.component';

describe('HalfPizzaCreateComponent', () => {
  let component: HalfPizzaCreateComponent;
  let fixture: ComponentFixture<HalfPizzaCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HalfPizzaCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HalfPizzaCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
