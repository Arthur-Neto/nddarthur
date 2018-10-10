import { Router } from '@angular/router';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { IErrorResponse } from './shared/error-response.model';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    private static HTTP_STATUS_404: number = 404;
    private readonly notFoundRoute: string = '/page-not-found';

    constructor(
        private router: Router,
    ) { }

    public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).do((event: HttpEvent<any>) => {
            //
        }, (response: any) => {
            if (response instanceof HttpErrorResponse) {

                const error: IErrorResponse = response.error;
                switch (error.errorCode) {
                    case (ErrorInterceptor.HTTP_STATUS_404): {
                        this.handleNotFound();
                        break;
                    }
                    default: {
                        break;
                    }
                }
            }
        });
    }

    private handleNotFound(): void {
        this.router.navigate([this.notFoundRoute]);
    }
}
