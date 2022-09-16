import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProceedAsGuestComponent } from './proceed-as-guest.component';

describe('ProceedAsGuestComponent', () => {
  let component: ProceedAsGuestComponent;
  let fixture: ComponentFixture<ProceedAsGuestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProceedAsGuestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProceedAsGuestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
