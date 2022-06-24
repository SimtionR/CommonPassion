import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeagueFixtureComponent } from './league-fixture.component';

describe('LeagueFixtureComponent', () => {
  let component: LeagueFixtureComponent;
  let fixture: ComponentFixture<LeagueFixtureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeagueFixtureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeagueFixtureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
