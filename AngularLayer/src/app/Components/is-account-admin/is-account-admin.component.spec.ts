import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IsAccountAdminComponent } from './is-account-admin.component';

describe('IsAccountAdminComponent', () => {
  let component: IsAccountAdminComponent;
  let fixture: ComponentFixture<IsAccountAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IsAccountAdminComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IsAccountAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
