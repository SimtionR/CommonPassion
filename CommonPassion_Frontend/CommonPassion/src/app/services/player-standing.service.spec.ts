import { TestBed } from '@angular/core/testing';

import { PlayerStandingService } from './player-standing.service';

describe('PlayerStandingService', () => {
  let service: PlayerStandingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlayerStandingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
