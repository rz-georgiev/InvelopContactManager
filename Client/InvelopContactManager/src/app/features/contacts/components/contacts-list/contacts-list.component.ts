import { CommonModule } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { SelectModule } from 'primeng/select';
import { Table, TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { ReactiveFormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { MultiSelectModule } from 'primeng/multiselect';
import { ContactResponseDto } from '../../models/contactResponseDto copy';
import { ContactsService } from '../../services/contacts.service';
import { ButtonModule } from 'primeng/button';
import { Router, RouterModule } from '@angular/router';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'app-contacts-list',
  standalone: true,
  imports: [
    CommonModule,
    TableModule,
    TagModule,
    SelectModule,
    IconFieldModule,
    InputIconModule,
    SelectModule,
    ReactiveFormsModule,
    FormsModule,
    DropdownModule,
    ButtonModule,
    RouterModule,
    InputTextModule,
    MultiSelectModule],
  templateUrl: './contacts-list.component.html',
  styleUrl: './contacts-list.component.css'
})
export class ContactsListComponent {
 
  @ViewChild('dt') dt: Table | undefined;

  protected contacts: ContactResponseDto[] = [];

  constructor(private contactsService: ContactsService, private router: Router) { }

  ngOnInit() {
    this.contactsService.getAll().subscribe(x => {
      this.contacts = x.result;
    });
  }

  createNewContact() {
    this.router.navigate(['./contacts-editor']);
  }

  editContact(contact: ContactResponseDto) {
    this.router.navigate(['/contacts-editor'], { queryParams: { id: contact.id } });
  }

  deleteContact(contact: ContactResponseDto) {
    this.contactsService.deleteById(contact.id).subscribe();
    this.contacts = this.contacts.filter(x => x.id !== contact.id);
  }

}
