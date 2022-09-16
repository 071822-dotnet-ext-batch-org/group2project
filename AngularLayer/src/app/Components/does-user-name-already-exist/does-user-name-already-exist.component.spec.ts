import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoesUserNameAlreadyExistComponent } from './does-user-name-already-exist.component';

describe('DoesUserNameAlreadyExistComponent', () => {
  let component: DoesUserNameAlreadyExistComponent;
  let fixture: ComponentFixture<DoesUserNameAlreadyExistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoesUserNameAlreadyExistComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DoesUserNameAlreadyExistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
