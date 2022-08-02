import { HttpClient, HttpParams } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BaseParams } from 'src/params/base-params';
import { ApiResponse } from '../classes/api-response';

@Injectable({
  providedIn: 'root'
})
export class ApiBaseService<T> {


  
    protected readonly apiUrl = environment.apiUrl;

    constructor(
        @Inject("route") protected route: string,
        protected http: HttpClient,
    ) { }

    getAsync(params: any): Observable<ApiResponse<T[]>> {
        return this.http.get<ApiResponse<T[]>>(`${this.apiUrl}${this.route}`, { params: params });
    }

    getByIdAsync(id: number): Observable<ApiResponse<T>> {
        return this.http.get<ApiResponse<T>>(`${this.apiUrl}${this.route}/${id}`);
    }
    createAsync(data: T): Observable<ApiResponse<T>> {
        return this.http.post<ApiResponse<T>>(`${this.apiUrl}${this.route}`, data);
    }

    updateAsync(data: T): Observable<ApiResponse<T>> {
        const body = Object.assign(data, {})
        return this.http.put<ApiResponse<T>>(`${this.apiUrl}${this.route}`, body);
    }

    deleteAsync(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}${this.route}/${id}`);
    }
}
