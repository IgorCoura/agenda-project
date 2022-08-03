import { HttpClient } from '@angular/common/http';
import { Injectable, EventEmitter} from '@angular/core';
import { delay, Observable, Subject, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Login } from '../entities/login.entity';
import jwtDecode from 'jwt-decode';
import { Roles } from '../enums/roles';

@Injectable()
export class AuthService {

  private readonly apiUrl = environment.apiUrl;
  showNavBar  = new EventEmitter<boolean>();
  showOptinsAdmin = new EventEmitter<boolean>();
 
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
    this.updateEvent()
    return window.localStorage.getItem("@token");
  }

  getRole(): string | null{
    this.updateEvent()
    return window.localStorage.getItem("@role");
  }

  setToken(token: string): void {
    const { role } = jwtDecode(token) as {role : Roles};
    window.localStorage.setItem("@token", token);
    window.localStorage.setItem("@role", role);
    this.updateEvent()
  }

  clearToken(): void {
    window.localStorage.removeItem("@token");
    window.localStorage.removeItem("@role");
    this.updateEvent()
  }

  updateEvent(){
    if(window.localStorage.getItem("@token") != null){
      var role = window.localStorage.getItem("@role") == Roles.ADMIN;
      if(role){
        this.showOptinsAdmin.emit(true);
      }
      else{
        this.showOptinsAdmin.emit(false);
      }
      this.showNavBar.emit(true);
    }
    else{
      this.showNavBar.emit(false);
    }
    
  }


}
