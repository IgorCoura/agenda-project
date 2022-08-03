import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ApiResponse } from '../classes/api-response';
import { User } from '../entities/user.entity';


@Injectable({
    providedIn: 'root'
})
export class UserService{

    protected readonly apiUrl = environment.apiUrl;

    constructor(private http: HttpClient) {
    }

    getUserAsync(): Observable<ApiResponse<User>> {
        return this.http.get<ApiResponse<User>>(`${this.apiUrl}/v1/User`);
    }

    createAsync(data: User): Observable<ApiResponse<User>> {
        return this.http.post<ApiResponse<User>>(`${this.apiUrl}/v1/User`, data);
    }

    updatePasswordAsync(user:User): Observable<ApiResponse<User>> {
        return this.http.put<ApiResponse<User>>(`${this.apiUrl}/v1/User/password`, user);
    }

    updateAsync(data: User): Observable<ApiResponse<User>> {
        return this.http.put<ApiResponse<User>>(`${this.apiUrl}/v1/User`, data);
    }

    deleteUserAsync(): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}$/v1/User`);
    }
}