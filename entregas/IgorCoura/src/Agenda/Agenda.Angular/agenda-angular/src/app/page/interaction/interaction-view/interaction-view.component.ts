import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Interaction } from 'src/app/entities/interaction.entity';
import { InteractionService } from 'src/app/services/interaction.service';
import { apiErrorHandler } from 'src/app/utils/api-error-handler';
import { pipe, Subscription, take } from 'rxjs';

@Component({
  selector: 'app-interaction-view',
  templateUrl: './interaction-view.component.html',
  styleUrls: ['./interaction-view.component.scss']
})
export class InteractionViewComponent implements OnInit {

  interactions: Interaction[]= [];
  isLoading = true;
  
  constructor(private interactionService: InteractionService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.getDataAsync();
  }


  getDataAsync(){
    this.interactionService.getAsync()
    .pipe(take(1))
    .subscribe({
      next: (resp) => {
        this.isLoading = false;
        this.interactions = resp.data;
      },
      error: ({error}) => {
        this.isLoading = false;
        apiErrorHandler(this.snackBar, error);
      }
    });
  }

  onDownload(){
    this.interactionService.download().subscribe((res) => {
      const file = new Blob([res], { type: res.type });
      const blob = window.URL.createObjectURL(file);

      const link = document.createElement('a');
      link.href = blob;
      link.download = 'interactions.json';
      link.click();
      window.URL.revokeObjectURL(blob);
      link.remove();
    });  
  }

}
