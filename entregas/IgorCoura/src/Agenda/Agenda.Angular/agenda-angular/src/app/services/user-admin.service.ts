import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ApiResponse } from '../classes/api-response';
import { User } from '../entities/user.entity';


@Injectable({
    providedIn: 'root'
})
export class UserAdminService{

    protected readonly apiUrl = environment.apiUrl;

    constructor(private http: HttpClient) {
    }

    getAsync(params: any): Observable<ApiResponse<User[]>> {
        return this.http.get<ApiResponse<User[]>>(`${this.apiUrl}/v1/User/admin/`, { params: params });
    }

    getByIdAsync(id: number): Observable<ApiResponse<User>> {
        return this.http.get<ApiResponse<User>>(`${this.apiUrl}/v1/User/admin/${id}`);
    }
    createAsync(data: User): Observable<ApiResponse<User>> {
        return this.http.post<ApiResponse<User>>(`${this.apiUrl}/v1/User/admin`, data);
    }

    updateAsync(data: User): Observable<ApiResponse<User>> {
        return this.http.put<ApiResponse<User>>(`${this.apiUrl}/v1/User/admin/${data.id}`, data);
    }

    deleteAsync(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/v1/User/admin/${id}`);
    }

}