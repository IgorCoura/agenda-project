import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Contact } from 'src/app/entities/contact.entity';
import { Phone } from 'src/app/entities/phone.entity';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-contact-view',
  templateUrl: './contact-view.component.html',
  styleUrls: ['./contact-view.component.scss']
})
export class ContactViewComponent implements OnInit, OnDestroy {

  userId: number = 0;
  contacts = [new Contact(1, "Jose", [new Phone(1, "123456789", "Home", 1, "Celular"), new Phone(2, "123456789", "Home", 1, "Celular")]), new Contact(2, "Maria", [new Phone(1, "123456789", "Home", 1, "Celular"), new Phone(2, "123456789", "Home", 1, "Celular")]),];
  optionsSearch : Array<string> = ["Name", "Phone", "DDD"];
  subscribe! : Subscription;



  constructor(private router : Router, private activatedRoute : ActivatedRoute, public dialog: MatDialog) { }

  ngOnInit(): void {
    this. subscribe = this.activatedRoute.params.subscribe(params => {
      if(params["userId"]){
        this.userId = params['userId'];
      }
    });
  }

  ngOnDestroy(): void {
    this.subscribe.unsubscribe();
  }


  onDelete(contact: Contact){
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '350px',
      data: {title: "Confirmar Exclusão", message: "Deseja realmente excluir o usuário " + contact.name + "?"}
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result){
        console.log(result);
      }
    });
  }

  onSearch(event : any){
    console.log(event.option + " " + event.search);
  }

  onAdd(){
    console.log(this.userId);
    if(this.userId === 0){
      this.router.navigate(['/contact/form/0']);
    }
    else{
      this.router.navigate([`admin/contact/${this.userId}/form/0`]);
    }
    
  }

  onEdit(contact: Contact){
    if(this.userId === 0){
      this.router.navigate(['/contact/form',contact.id]);
    }
    else{
      this.router.navigate([`admin/contact/${this.userId}/form`,contact.id]);
    }
  }

  onChangePageEvent(event: any){
    console.log("Take: "+event.take+" Skip: "+event.skip);
  }

}
