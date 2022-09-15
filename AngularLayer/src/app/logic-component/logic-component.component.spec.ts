import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LogicComponentComponent } from './logic-component.component';

describe('LogicComponentComponent', () => {
  let component: LogicComponentComponent;
  let fixture: ComponentFixture<LogicComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LogicComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LogicComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
