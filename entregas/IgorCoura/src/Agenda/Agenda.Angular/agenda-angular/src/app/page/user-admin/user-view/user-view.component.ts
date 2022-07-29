import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { User } from 'src/app/entities/user.entity';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.scss']
})
export class UserViewComponent implements OnInit {

  optionsSearch: Array<string> = ["Name", "Email", "Username"];
  Users = [
    new User(44, "Comum", "Jose", "jose", "jose@email.com", 1, "12345667", "12345667"),
    new User(55, "Comum", "Maria", "Maria", "Maria@email.com", 1, "12345667", "12345667"),
  ]


  constructor(private router: Router, public dialog: MatDialog) { }


  ngOnInit(): void {
  }

  onSearch(event: any) {
    console.log(event.option + " " + event.search);
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
        console.log(result);
      }
    });
  }

  onChangePage(event: any) {
    console.log("Take: " + event.take + " Skip: " + event.skip);
  }

  

}
