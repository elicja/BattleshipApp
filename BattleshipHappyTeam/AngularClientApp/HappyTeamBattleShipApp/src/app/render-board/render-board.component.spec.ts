import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RenderBoardComponent } from './render-board.component';

describe('RenderBoardComponent', () => {
  let component: RenderBoardComponent;
  let fixture: ComponentFixture<RenderBoardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RenderBoardComponent]
    });
    fixture = TestBed.createComponent(RenderBoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
