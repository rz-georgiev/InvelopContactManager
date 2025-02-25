import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseResponse } from '../models/baseResponseDto';
import { ContactResponseDto } from '../models/contactResponseDto';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<BaseResponse<ContactResponseDto[]>> {
    return this.httpClient.get<any>(`http://localhost:4200/GetAll`);
  }
}
