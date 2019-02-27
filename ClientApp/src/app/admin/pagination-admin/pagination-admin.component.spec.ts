import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PaginationAdminComponent } from './pagination-admin.component';

describe('PaginationAdminComponent', () => {
  let component: PaginationAdminComponent;
  let fixture: ComponentFixture<PaginationAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PaginationAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PaginationAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
