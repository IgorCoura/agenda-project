import { Injectable } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { AuthService } from "../services/auth.service";

@Injectable({
providedIn: 'root'
})
export class AuthGuard implements CanActivate {

    constructor(
        public router: Router,
        private authService: AuthService,
        private snackBar: MatSnackBar,
    ) {}

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        const hasToken = this.authService.getToken();
        if (!hasToken) {
            this.snackBar.open("Você não tem autorização para acessar essa página.", "OK", { duration: 5000});
            this.router.navigate(['/login']);
            return false;
        }
        return true;
    }

}
