import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactsEditorComponent } from './contacts-editor.component';

describe('ContactsEditorComponent', () => {
  let component: ContactsEditorComponent;
  let fixture: ComponentFixture<ContactsEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ContactsEditorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContactsEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
