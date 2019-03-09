import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminsAdminComponent } from './admins-admin.component';

describe('AdminsAdminComponent', () => {
  let component: AdminsAdminComponent;
  let fixture: ComponentFixture<AdminsAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminsAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminsAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
