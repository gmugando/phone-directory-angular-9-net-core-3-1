import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PhoneBookListComponent } from './phone-book-list.component';

describe('PhoneBookListComponent', () => {
  let component: PhoneBookListComponent;
  let fixture: ComponentFixture<PhoneBookListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhoneBookListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhoneBookListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
