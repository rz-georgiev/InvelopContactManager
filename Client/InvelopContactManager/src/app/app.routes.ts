import { Routes } from '@angular/router';
import { ContactsEditorComponent } from './features/contacts/components/contacts-editor/contacts-editor.component';
import { ContactsListComponent } from './features/contacts/components/contacts-list/contacts-list.component';

export const routes: Routes = [
    { path: '', component: ContactsListComponent },
    { path: 'contacts-editor', component: ContactsEditorComponent },
];
