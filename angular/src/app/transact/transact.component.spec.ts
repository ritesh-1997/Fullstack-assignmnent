import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransactComponent } from './transact.component';

describe('TransactComponent', () => {
  let component: TransactComponent;
  let fixture: ComponentFixture<TransactComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TransactComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TransactComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
