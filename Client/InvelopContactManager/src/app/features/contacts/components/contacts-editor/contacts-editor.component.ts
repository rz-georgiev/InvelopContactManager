import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { CalendarIcon } from 'primeng/icons';
import { ContactsService } from '../../services/contacts.service';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ContactResponseDto } from '../../models/contactResponseDto';
import { ContactEditRequestDto } from '../../models/contactEditRequestDto';
import { ContactEditResponseDto } from '../../models/contactEditResponseDto';
import { InputTextModule } from 'primeng/inputtext';
import { CardModule } from 'primeng/card';
import { Button, ButtonModule } from 'primeng/button';
import { FloatLabel, FloatLabelModule } from 'primeng/floatlabel';
import { BadgeModule } from 'primeng/badge';
import { OverlayBadgeModule } from 'primeng/overlaybadge';
import { CalendarModule } from 'primeng/calendar';


@Component({
  selector: 'app-contacts-editor',
  standalone: true,
  imports: [DropdownModule, CommonModule,
    ReactiveFormsModule,
    BadgeModule, OverlayBadgeModule,
    FloatLabelModule, ButtonModule, CardModule, InputTextModule,
    CalendarModule],
  templateUrl: './contacts-editor.component.html',
  styleUrl: './contacts-editor.component.css'
})
export class ContactsEditorComponent {

  protected contactForm!: FormGroup;
  protected errorMessage?: string;
  private response!: ContactResponseDto;

  constructor(private fb: FormBuilder,
    private contactsService: ContactsService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit() {

    const id = +((this.route.snapshot.queryParamMap.get('id')) ?? 0);

    this.contactsService.getById(id).subscribe(x => {
      this.response = x.result;

      this.contactForm = this.fb.group({
        firstName: [this.response?.firstName, [Validators.required]],
        surname: [this.response?.surname, [Validators.required]],
        dob: [this.response?.dob, Validators.required],
        address: [this.response?.address, Validators.required],
        phoneNumber: [this.response?.phoneNumber, Validators.required],
        iban: [this.response?.iban, Validators.required],
      });

      const dateString = this.response.dob;
      const dateObject = new Date(dateString);

      this.contactForm.get('dob')?.setValue(dateObject);
    });
  }

  onSubmit() {

    let newData = this.contactForm.value as ContactResponseDto;
    
    if (this.contactForm.valid) {
      if (this.response) {

        newData.id = this.response.id;

        this.contactsService.updateContact(newData).subscribe(x => {
          if (x.isOk) {
            this.router.navigate(['']);
          }
          else {
            this.errorMessage = x.message;
          }
        });
      }
      else {
        this.contactsService.createContact(newData).subscribe(x => {
          if (x.isOk) {
            this.router.navigate(['']);
          }
          else {
            this.errorMessage = x.message;
          }
        });
      }
    } else {
      console.log('Form is not valid');
    }
  }
}
