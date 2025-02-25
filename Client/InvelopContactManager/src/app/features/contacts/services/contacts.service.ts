import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseResponse } from '../models/baseResponseDto';
import { ContactResponseDto } from '../models/contactResponseDto';
import { HttpClient } from '@angular/common/http';
import { ContactEditResponseDto } from '../models/contactEditResponseDto';
import { ContactEditRequestDto } from '../models/contactEditRequestDto';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<BaseResponse<ContactResponseDto[]>> {
    return this.httpClient.get<BaseResponse<ContactResponseDto[]>>(`http://localhost:4200/GetAll`);
  }

  getById(id: number): Observable<BaseResponse<ContactResponseDto>> {
    return this.httpClient.get<BaseResponse<ContactResponseDto>>(`"http://localhost:4200/GetById?id=${id}"`);
  }

  deleteById(id: number): Observable<BaseResponse<ContactEditResponseDto>> {
    return this.httpClient.delete<BaseResponse<ContactEditResponseDto>>(`http://localhost:4200/DeleteContact/${id}`);
  }

  createContact(request: ContactEditRequestDto): Observable<BaseResponse<ContactEditResponseDto>> {
    return this.httpClient.post<BaseResponse<ContactEditResponseDto>>(`http://localhost:4200/CreateContact`, request);
  }

  // Can be merged with the method above, depending on the business logic
  updateContact(request: ContactEditRequestDto): Observable<BaseResponse<ContactEditResponseDto>> {
    return this.httpClient.post<BaseResponse<ContactEditResponseDto>>(`http://localhost:4200/UpdateContact`, request);
  }
}
