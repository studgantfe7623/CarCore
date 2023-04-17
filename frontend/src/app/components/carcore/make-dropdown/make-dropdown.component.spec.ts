import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MakeDropdownComponent } from './make-dropdown.component';

describe('MakeDropdownComponent', () => {
  let component: MakeDropdownComponent;
  let fixture: ComponentFixture<MakeDropdownComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MakeDropdownComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MakeDropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
