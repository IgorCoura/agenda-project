import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { take, Observable, catchError, throwError } from "rxjs";
import { AuthService } from "../../services/auth.service";

@Injectable({
providedIn: 'root'
})
export class HttpInterceptorService implements HttpInterceptor {

    constructor(
        private authService: AuthService,
        private router: Router
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const token = this.authService.getToken();
        if (token) {
        req = this.setToken(req, token);
        }
        return next.handle(req)
        .pipe(
            catchError((error: HttpEvent<any>) => {
            if (error instanceof HttpErrorResponse && error.status === 401 ) {
                this.authService.clearToken();
                this.router.navigate(['/login']);
            }
            return throwError(() => error);
            })
        );
    }


    setToken(req: HttpRequest<any>, token: string): HttpRequest<any> {
        return req.clone({ headers: req.headers.set('Authorization', `Bearer ${token}`) });
    }

}
