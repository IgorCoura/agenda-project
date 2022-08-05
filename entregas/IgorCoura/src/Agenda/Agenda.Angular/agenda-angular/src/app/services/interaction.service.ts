import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { environment } from "src/environments/environment";
import { ApiResponse } from "../classes/api-response";
import { Interaction } from "../entities/interaction.entity";


@Injectable({
    providedIn: 'root'
})
export class InteractionService {

    protected readonly apiUrl = environment.apiUrl;

    constructor(private http: HttpClient) {
    }

    getAsync(): Observable<ApiResponse<Interaction[]>> {
        return this.http.get<ApiResponse<Interaction[]>>(`${this.apiUrl}/v1/Interaction`);
    }

    download(){
        return this.http.get(`${this.apiUrl}/v1/Interaction/download`, {responseType: 'blob'});
    }

 
}