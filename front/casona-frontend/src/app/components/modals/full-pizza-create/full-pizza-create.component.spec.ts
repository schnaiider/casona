import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FullPizzaCreateComponent } from './full-pizza-create.component';

describe('FullPizzaCreateComponent', () => {
  let component: FullPizzaCreateComponent;
  let fixture: ComponentFixture<FullPizzaCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FullPizzaCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FullPizzaCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
