import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../entities/user.entity';
import { ApiBaseService } from './api-base.service';


@Injectable({
    providedIn: 'root'
})
export class UserService extends ApiBaseService<User>{

    constructor(protected override http: HttpClient) {
        super("/v1/user", http); 
    }

}