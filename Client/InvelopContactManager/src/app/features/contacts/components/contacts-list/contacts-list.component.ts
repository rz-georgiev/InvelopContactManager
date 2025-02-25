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
    MultiSelectModule],
  templateUrl: './contacts-list.component.html',
  styleUrl: './contacts-list.component.css'
})
export class ContactsListComponent {
 
  @ViewChild('dt') dt: Table | undefined;

  protected contacts: ContactResponseDto[] = [];

  constructor(private contactsService: ContactsService) { }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  ngOnInit() {
    this.contactsService.getAll().subscribe(x => {
      this.contacts = x.result;
    });
  }
}
