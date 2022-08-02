import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { delay, Observable, Subject, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Login } from '../entities/login.entity';
import jwtDecode from 'jwt-decode';
import { Roles } from '../enums/roles';

@Injectable()
export class AuthService {

  private readonly apiUrl = environment.apiUrl;
 
  constructor(private http: HttpClient) { }

  loginAsync(login: Login){
    return this.http.post<any>(`${this.apiUrl}/v1/auth`, login).pipe(
      tap((resp) => {
        if(!resp.success) return;
        this.setToken(resp.data);
      })
    );
  }

  getToken(): string | null{
    return window.localStorage.getItem("@token");
  }

  getRole(): string | null{
    return window.localStorage.getItem("@role");
  }

  setToken(token: string): void {
    const { role } = jwtDecode(token) as {role : Roles};
    window.localStorage.setItem("@token", token);
    window.localStorage.setItem("@role", role);

  }

  clearToken(): void {
    window.localStorage.removeItem("@token");
    window.localStorage.removeItem("@role");

  }


}
