import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subject, Subscription, takeUntil } from 'rxjs';
import { Roles } from 'src/app/enums/roles';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit, OnDestroy{

  IsAuthenticated!: boolean;
  IsAdmin! : boolean;
  unsub : Subscription[] = [];

  constructor(private auth: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.unsub.push(this.auth.showNavBar.subscribe((resp) => { this.IsAuthenticated = resp; }));
    this.unsub.push(this.auth.showOptinsAdmin.subscribe((resp) => { this.IsAdmin = resp; }));
  }

  ngOnDestroy(): void {
    this.unsub.forEach((sub) => sub.unsubscribe());
  }

  onLogout(){
    this.auth.clearToken();
    this.router.navigate(['/login']);
  }

}
