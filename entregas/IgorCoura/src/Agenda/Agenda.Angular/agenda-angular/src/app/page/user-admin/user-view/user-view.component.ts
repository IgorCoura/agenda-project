import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { User } from 'src/app/entities/user.entity';
import { UserAdminService } from 'src/app/services/user-admin.service';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import { apiErrorHandler } from 'src/app/utils/api-error-handler';
import { pipe, Subscription, take } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.scss']
})
export class UserViewComponent implements OnInit {
  params : {[key: string] : any} = {};
  lengthPage = 10;
  optionsSearch: Array<string> = ["Name", "Email", "Username"];
  Users : User[]= [];

  constructor(
    private router: Router, 
    private dialog: MatDialog , 
    private userAdminService : UserAdminService,
    private snackBar : MatSnackBar) { }


  ngOnInit(): void {
    this.params['skip'] = 0;
    this.params['take'] = 10;
    this.getDataAsync();
  }



  getDataAsync(){
    this.userAdminService.getAsync(this.params)
    .pipe(take(1))
    .subscribe({
      next: (resp) => {
        this.lengthPage = resp.totalItems;
        this.Users = resp.data;
      },
      error: ({error}) => {
        apiErrorHandler(this.snackBar, error);
      }
    });
  }

  onSearch(event: any) {
    this.params['skip'] = 0;
    this.params[event.option] = event.search;
    this.getDataAsync();
  }

  onAdd() {
    this.router.navigate(['admin/user/form', 0]);
  }

  onDelete(user:User){
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '350px',
      data: {title: "Confirmar Exclusão", message: "Deseja realmente excluir o usuário " + user.name + "?"}
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.userAdminService.deleteAsync(user.id).pipe(take(1)).subscribe({
          next: () => { this.snackBar.open("Usuário excluído com sucesso!", "Fechar"); this.getDataAsync(); 
          },  
          error: ({error}) => {
            apiErrorHandler(this.snackBar, error);
          }
        });
      }
    });
  }

  onChangePage(event: any) {
    this.params['skip'] = event.skip;
    this.params['take'] = event.take;
    this.getDataAsync();
  }

  

}
