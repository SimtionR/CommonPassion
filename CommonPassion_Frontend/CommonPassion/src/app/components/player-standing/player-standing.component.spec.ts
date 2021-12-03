import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerStandingComponent } from './player-standing.component';

describe('PlayerStandingComponent', () => {
  let component: PlayerStandingComponent;
  let fixture: ComponentFixture<PlayerStandingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlayerStandingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlayerStandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
