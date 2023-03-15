/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EnventoDetelheComponent } from './envento-detelhe.component';

describe('EnventoDetelheComponent', () => {
  let component: EnventoDetelheComponent;
  let fixture: ComponentFixture<EnventoDetelheComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EnventoDetelheComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EnventoDetelheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
