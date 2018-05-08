import * as alertify from 'alertify.js';

import { Injectable } from "@angular/core";

@Injectable()
export class AlertifyService {    
    constructor() { 
        alertify.logPosition("bottom right");
        alertify.maxLogItems(1);
    }

    error(message: string) {
        alertify.error(message);
    }

    log(message: string) {
        alertify.log(message);
    }

    success(message: string) {
        alertify.success(message);
    }

    confirm(message: string){
        alertify.confirm(message, function(){
            return true;
        }, function() {
            return false;
        });
    }
    
}
