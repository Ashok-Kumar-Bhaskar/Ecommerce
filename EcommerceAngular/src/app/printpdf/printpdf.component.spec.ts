import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintpdfComponent } from './printpdf.component';

describe('PrintpdfComponent', () => {
  let component: PrintpdfComponent;
  let fixture: ComponentFixture<PrintpdfComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrintpdfComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrintpdfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
