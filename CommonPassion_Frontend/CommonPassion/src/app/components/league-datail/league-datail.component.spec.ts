import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeagueDatailComponent } from './league-datail.component';

describe('LeagueDatailComponent', () => {
  let component: LeagueDatailComponent;
  let fixture: ComponentFixture<LeagueDatailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeagueDatailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeagueDatailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
