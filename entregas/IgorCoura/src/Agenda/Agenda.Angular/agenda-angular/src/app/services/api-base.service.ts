import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BaseParams } from 'src/params/base-params';

@Injectable({
  providedIn: 'root'
})
export class ApiBaseService<T> {
  
    private readonly apiUrl = environment.apiUrl;

    constructor(
        @Inject("route") protected route: string,
        protected http: HttpClient,
    ) { }

    getAsync(params = new BaseParams()): Observable<T> {
        return this.http.get<T>(`${this.apiUrl}${this.route}`, { params });
    }

    getByIdAsync(id: number): Observable<T> {
        return this.http.get<T>(`${this.apiUrl}${this.route}/${id}`);
    }

    createAsync(data: T): Observable<T> {
        return this.http.post<T>(`${this.apiUrl}${this.route}`, data);
    }

    updateAsync(data: T): Observable<T> {
        const body = Object.assign(data, {})
        return this.http.put<T>(`${this.apiUrl}${this.route}`, body);
    }

    deleteAsync(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}${this.route}/${id}`);
    }
}
