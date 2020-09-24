import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, of } from 'rxjs';import { MessageService } from './message.service';

export interface IRequestOptions {
    headers?: HttpHeaders;
    observe?: 'body';
    params?: HttpParams;
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
    body?: any;
}

@Injectable({
    providedIn: 'root'
})
export class HttpServiceClient {

    public constructor(
        public http: HttpClient,
        public messageService: MessageService
    ) {
    }

    /**
     * GET request
     * @param string endPoint it doesn't need / in front of the end point
     * @param IRequestOptions options options of the request like headers, body, etc.
     * @returns Observable<T>
     */
    public Get<Response>(endPoint: string, options?: IRequestOptions): Observable<Response> {
        return this.http.get<Response>(endPoint, options);
    }

    /**
     * POST request
     * @param string endPoint end point of the api
     * @param Object params body of the request.
     * @param IRequestOptions options options of the request like headers, body, etc.
     * @returns Observable<T>
     */
    public Post<Response>(endPoint: string, params: any, options?: IRequestOptions): Observable<Response> {
        // console.log(params);
        return this.http.post<Response>(endPoint, params, options);
    }

    /**
     * PUT request
     * @param string endPoint end point of the api
     * @param Object params body of the request.
     * @param IRequestOptions options options of the request like headers, body, etc.
     * @returns Observable<T>
     */
    public Put<Response>(endPoint: string, params: object, options?: IRequestOptions): Observable<Response> {
        return this.http.put<Response>(endPoint, params, options);
    }

    /**
     * DELETE request
     * @param string endPoint end point of the api
     * @param IRequestOptions options options of the request like headers, body, etc.
     * @returns Observable<T>
     */
    public Delete<Response>(endPoint: string, options?: IRequestOptions): Observable<Response> {
        return this.http.delete<Response>(endPoint, options);
    }

    /**
     * Handle Http operation that failed.
     * Let the app continue.
     * @param operation - name of the operation that failed
     * @param result - optional value to return as the observable result
     */
    public handleError<Response>(operation = 'operation', result?: Response) {
        return (error: any): Observable<Response> => {

            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead

            // TODO: better job of transforming error for user consumption
            this.log(`${operation} failed: ${error.message}`);

            // Let the app keep running by returning an empty result.
            return of(result as Response);
        };
    }

    /** Log a AssestsService message with the MessageService */
    public log(message: string) {
        this.messageService.add(`AssetsService: ${message}`);
    }

    // public handlerError(err: Response) {
    //     const data = err.json();

    //     return JSON.parse(JSON.stringify({
    //         message: data.message !== undefined ? data.message : (data.Message !== undefined ? data.Message : 'Error'),
    //         status: err.status
    //     }));
    // }

    private getFullUrl(url: string): string {
        return url;
    }

    private noSessionResponse(): Observable<Response> {
        const response = {
            status: 401
        };
        console.log('error no session find');
        return Observable.create(observer => {
            observer.error(response);
            observer.complete();
        });
    }
}


export function HttpServiceCreator(http: HttpClient, messageService: MessageService) {
    return new HttpServiceClient(http, messageService);
}
