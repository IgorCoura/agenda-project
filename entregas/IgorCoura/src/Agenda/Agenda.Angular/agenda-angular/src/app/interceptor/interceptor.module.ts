import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpInterceptorService } from './service/http-interceptor.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    HttpInterceptorService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpInterceptorService,
      multi: true,
    },
  ]
})
export class InterceptorModule { }
