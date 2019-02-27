import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InstructionAdminComponent } from './instruction-admin.component';

describe('InstructionAdminComponent', () => {
  let component: InstructionAdminComponent;
  let fixture: ComponentFixture<InstructionAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InstructionAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstructionAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
