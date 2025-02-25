import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ContactsEditorComponent } from './features/contacts/components/contacts-editor/contacts-editor.component';
import { ContactsListComponent } from './features/contacts/components/contacts-list/contacts-list.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ContactsListComponent, ContactsEditorComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'InvelopContactManager';

  constructor() {
  }
  
}
