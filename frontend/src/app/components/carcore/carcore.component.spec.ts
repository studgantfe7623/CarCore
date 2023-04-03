import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarcoreComponent } from './carcore.component';

describe('CarcoreComponent', () => {
  let component: CarcoreComponent;
  let fixture: ComponentFixture<CarcoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarcoreComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarcoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
