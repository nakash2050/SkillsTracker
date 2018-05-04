import { ErrorHandler, Injector, Injectable } from "@angular/core";
import { BadRequestError } from "./bad-request-error";
import { UnauthorizedError } from "./unauthorized-error";
//import { AlertifyService } from "../_services/alertify.service";

@Injectable()
export class AppErrorHandler implements ErrorHandler {
  constructor(private injector: Injector) {}

  handleError(error: any) {    
  }
}