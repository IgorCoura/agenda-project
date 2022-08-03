import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { pipe, Subscription, take } from 'rxjs';
import { Contact } from 'src/app/entities/contact.entity';
import { Phone } from 'src/app/entities/phone.entity';
import { ContactAdminService } from 'src/app/services/contact-admin.service';
import { ContactService } from 'src/app/services/contact.service';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import { apiErrorHandler } from 'src/app/utils/api-error-handler';
import { BaseParams } from 'src/params/base-params';

@Component({
  selector: 'app-contact-view',
  templateUrl: './contact-view.component.html',
  styleUrls: ['./contact-view.component.scss']
})
export class ContactViewComponent implements OnInit, OnDestroy {

  userId: number = 0;
  contacts: Contact[]= [];
  optionsSearch : Array<string> = ["Name", "Number", "DDD"];
  subscribe! : Subscription;
  params : {[key: string] : any} = {};
  lengthPage = 10;

  constructor(
    private router : Router, 
    private activatedRoute : ActivatedRoute, 
    private dialog: MatDialog,
    private contactService: ContactService,
    private snackBar: MatSnackBar,
    private contactAdminService: ContactAdminService
    ) { }

  ngOnInit(): void {

    this.params['skip'] = 0;
    this.params['take'] = 10;

    this.subscribe = this.activatedRoute.params.subscribe(params => {
      if(params["userId"]){
        this.userId = params['userId'];
      }
    });
    this.getDataAsync();
    
  }

  ngOnDestroy(): void {
    this.subscribe.unsubscribe();
  }


  getDataAsync(){
    if(this.userId === 0){ 
      this.contactService.getAsync(this.params)
      .pipe(take(1))
      .subscribe({
        next: resp => {
          this.lengthPage = resp.totalItems;
          this.contacts = resp.data;
        },
        error: ({error}) => {
          apiErrorHandler(this.snackBar, error);
        }
      })
    }
    else{
      this.params['userId'] = this.userId;
      this.contactAdminService.getAsync(this.params)
      .pipe(take(1))
      .subscribe({
        next: resp => {
          this.lengthPage = resp.totalItems;
          this.contacts = resp.data;
        },
        error: ({error}) => {
          apiErrorHandler(this.snackBar, error);
        }
      })
    }
  }


  onDelete(contact: Contact){
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '350px',
      data: {title: "Confirmar Exclusão", message: "Deseja realmente excluir o usuário " + contact.name + "?"}
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result){
        if(this.userId == 0){
          this.contactService.deleteAsync(contact.id).pipe(take(1)).subscribe({
            next: () => {
              this.snackBar.open("Contato excluído com sucesso!", "fechar", {duration: 2000});
              this.getDataAsync();
            },
            error: ({error}) => {
              apiErrorHandler(this.snackBar, error);
            }
            
          });
        }
        else{
          this.contactAdminService.deleteAsync(contact.id, this.userId).pipe(take(1)).subscribe({
            next: () => {
              this.snackBar.open("Contato excluído com sucesso!", "fechar", {duration: 2000});
              this.getDataAsync();
            },
            error: ({error}) => {
              apiErrorHandler(this.snackBar, error);
            }
            
          });
        }
      }
    });
  }

  onSearch(event : any){
    this.params['skip'] = 0;
    this.params[event.option] = event.search;
    this.getDataAsync();
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
    this.params['skip'] = event.skip;
    this.params['take'] = event.take;
    this.getDataAsync();
  }

}
