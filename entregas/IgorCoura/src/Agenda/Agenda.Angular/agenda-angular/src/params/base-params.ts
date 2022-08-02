import { HttpParams } from "@angular/common/http";

export class BaseParams extends HttpParams {
  take = 10;
  skip = 0;
}
