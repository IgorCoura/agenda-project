import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ApiResponse } from '../classes/api-response';
import { User } from '../entities/user.entity';
import { ApiBaseService } from './api-base.service';


@Injectable({
    providedIn: 'root'
})
export class UserService extends ApiBaseService<User>{


    constructor(protected override http: HttpClient) {
        super("/v1/User", http); 
    }

    getUserAsync(): Observable<ApiResponse<User>> {
        return this.http.get<ApiResponse<User>>(`${this.apiUrl}/v1/User`);
    }

    updatePasswordAsync(user:User): Observable<ApiResponse<User>> {
        return this.http.put<ApiResponse<User>>(`${this.apiUrl}/v1/User/password`, user);
    }

    deleteUserAsync(): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}${this.route}`);
    }
}