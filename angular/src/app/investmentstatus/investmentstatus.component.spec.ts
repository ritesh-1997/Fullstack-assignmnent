import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvestmentstatusComponent } from './investmentstatus.component';

describe('InvestmentstatusComponent', () => {
  let component: InvestmentstatusComponent;
  let fixture: ComponentFixture<InvestmentstatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InvestmentstatusComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(InvestmentstatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
