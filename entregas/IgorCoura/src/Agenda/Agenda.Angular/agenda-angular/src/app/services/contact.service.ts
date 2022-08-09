import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ApiResponse } from '../classes/api-response';
import { Contact } from '../entities/contact.entity';
import { PhoneType } from '../entities/phoneTypes.entity';


@Injectable({
    providedIn: 'root'
})
export class ContactService {

    protected readonly apiUrl = environment.apiUrl;

    constructor(private http: HttpClient) {
    }

    getAsync(params: any): Observable<ApiResponse<Contact[]>> {
        return this.http.get<ApiResponse<Contact[]>>(`${this.apiUrl}/v1/Contact`, { params: params });
    }

    getByIdAsync(id: number): Observable<ApiResponse<Contact>> {
        return this.http.get<ApiResponse<Contact>>(`${this.apiUrl}/v1/Contact/${id}`);
    }
    createAsync(data: Contact): Observable<ApiResponse<Contact>> {
        return this.http.post<ApiResponse<Contact>>(`${this.apiUrl}/v1/Contact`, data);
    }

    updateAsync(data: Contact): Observable<ApiResponse<Contact>> {
        return this.http.put<ApiResponse<Contact>>(`${this.apiUrl}/v1/Contact`, data);
    }

    deleteAsync(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/v1/Contact/${id}`);
    }

    getPhoneTypesAsync(): Observable<ApiResponse<PhoneType[]>> {
        return this.http.get<ApiResponse<PhoneType[]>>(`${this.apiUrl}/v1/Contact/phoneTypes`);
    }

}