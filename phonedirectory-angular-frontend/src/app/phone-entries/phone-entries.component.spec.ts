import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PhoneEntriesComponent } from './phone-entries.component';

describe('PhoneEntriesComponent', () => {
  let component: PhoneEntriesComponent;
  let fixture: ComponentFixture<PhoneEntriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhoneEntriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhoneEntriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
