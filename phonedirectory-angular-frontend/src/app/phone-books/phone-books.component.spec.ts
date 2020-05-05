import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PhoneBooksComponent } from './phone-books.component';

describe('PhoneBooksComponent', () => {
  let component: PhoneBooksComponent;
  let fixture: ComponentFixture<PhoneBooksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhoneBooksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhoneBooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
