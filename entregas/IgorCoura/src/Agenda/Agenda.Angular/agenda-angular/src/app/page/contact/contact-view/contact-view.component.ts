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
  isLoading = true;

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
      this.getComumContact();
    }
    else{
      this.getAdminContact();
    }
    
  }

  getComumContact(){
    this.contactService.getAsync(this.params)
      .pipe(take(1))
      .subscribe({
        next: resp => {
          this.isLoading = false;
          this.lengthPage = resp.totalItems;
          this.contacts = resp.data;
        },
        error: ({error}) => {
          this.isLoading = false;
          apiErrorHandler(this.snackBar, error);
        }
      })
  }

  getAdminContact(){
    this.params['userId'] = this.userId;
      this.contactAdminService.getAsync(this.params)
      .pipe(take(1))
      .subscribe({
        next: resp => {
          this.isLoading = false;
          this.lengthPage = resp.totalItems;
          this.contacts = resp.data;
        },
        error: ({error}) => {
          this.isLoading = false;
          apiErrorHandler(this.snackBar, error);
        }
      })
  }


  onDelete(contact: Contact){
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '350px',
      data: {title: "Confirmar Exclus??o", message: "Deseja realmente excluir o contato " + contact.name + "?"}
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result){
        if(this.userId == 0){
          this.deleteComumContact(contact);
        }
        else{
          this.deleteAdminContact(contact);
        }
      }
    });
  }

  deleteComumContact(contact : Contact){
    this.contactService.deleteAsync(contact.id).pipe(take(1)).subscribe({
      next: () => {
        this.snackBar.open("Contato exclu??do com sucesso!", "fechar", {duration: 2000});
        this.getDataAsync();
      },
      error: ({error}) => {
        apiErrorHandler(this.snackBar, error);
      }
      
    });
  }

  deleteAdminContact(contact : Contact){
    this.contactAdminService.deleteAsync(contact.id, this.userId).pipe(take(1)).subscribe({
      next: () => {
        this.snackBar.open("Contato exclu??do com sucesso!", "fechar", {duration: 2000});
        this.getDataAsync();
      },
      error: ({error}) => {
        apiErrorHandler(this.snackBar, error);
      }
      
    });
  }

  onSearch(event : any){
    this.params['skip'] = 0;
    this.params[event.option] = event.search;
    var options = this.optionsSearch.filter(option => option !== event.option);
    options.forEach(option => { delete this.params[option] });
    this.getDataAsync();
  }

  onAdd(){
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
