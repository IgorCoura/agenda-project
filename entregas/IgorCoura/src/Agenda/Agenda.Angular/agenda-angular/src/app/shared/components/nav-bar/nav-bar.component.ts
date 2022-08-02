import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit, OnDestroy{

  IsAuthenticated : boolean = true;
  IsAdmin : boolean = true;
  subs! : Subscription;

  constructor(private auth: AuthService, private router: Router) { }

  ngOnInit(): void {

  }

  ngOnDestroy(): void {
    console.log("Destroy");
    this.subs.unsubscribe();
  }

  onLogout(){
    this.auth.clearToken();
    this.router.navigate(['/login']);
  }

}
