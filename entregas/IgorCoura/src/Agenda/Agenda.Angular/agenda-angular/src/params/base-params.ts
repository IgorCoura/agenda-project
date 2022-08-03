import { HttpParams } from "@angular/common/http";

export class BaseParams {
  [key: string] : any;
  take = 10;
  skip = 0;
}
