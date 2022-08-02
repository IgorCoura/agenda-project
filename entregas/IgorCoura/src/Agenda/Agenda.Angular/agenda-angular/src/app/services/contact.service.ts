import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../classes/api-response';
import { Contact } from '../entities/contact.entity';
import { PhoneType } from '../entities/phoneTypes.entity';
import { ApiBaseService } from './api-base.service';


@Injectable({
    providedIn: 'root'
})
export class ContactService extends ApiBaseService<Contact>{

    constructor(protected override http: HttpClient) {
        super("/v1/Contact", http); 
    }

    getPhoneTypesAsync(): Observable<ApiResponse<PhoneType[]>> {
        return this.http.get<ApiResponse<PhoneType[]>>(`${this.apiUrl}/v1/Contact/phoneTypes`);
    }

}