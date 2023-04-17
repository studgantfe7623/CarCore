import { TestBed } from '@angular/core/testing';

import { MakeDropdownService } from './make-dropdown.service';

describe('MakeDropdownService', () => {
  let service: MakeDropdownService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MakeDropdownService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
