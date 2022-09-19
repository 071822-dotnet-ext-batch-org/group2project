import { TestBed } from '@angular/core/testing';

import { AngularService } from './ang-service.service';

describe('CustomRequestService', () => {
  let service: AngularService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AngularService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
