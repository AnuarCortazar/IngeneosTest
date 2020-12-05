import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../model/user';
import { AuthenticationResult } from '../model/authentication-result';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Author } from '../model/author';
import { Book } from '../model/book';
import { BookInput } from '../model/book-input';

@Injectable({
  providedIn: 'root'
})
export class OperationsService {

  private baseUrl: string;
  
  constructor(private http: HttpClient) { 
    this.baseUrl = environment.baseUrl + '/operations';
  }

  syncInformation() : Observable<any> {
    let url = this.baseUrl + '/sync';    
    return this.http.get(url).pipe(
      map((result: any) => {
        return result;
      })
    )
  }

  getAuthors() : Observable<Author[]> {
    let url = this.baseUrl + '/authors';    
    return this.http.get(url).pipe(
      map((result: any) => {
        return result;
      })
    )
  }

  getAuthorById(idAuthor: number) : Observable<any> {
    let url = this.baseUrl + '/authors/' + idAuthor;    
    return this.http.get(url).pipe(
      map((result: any) => {
        return result;
      })
    )
  }

  getBooks(input: BookInput) : Observable<Book[]> {
    let url = this.baseUrl + '/books';    
    return this.http.post(url, input).pipe(
      map((result: any) => {
        return result;
      })
    )
  }

  getBookById(idBook: number) : Observable<any> {
    let url = this.baseUrl + '/books/' + idBook;    
    return this.http.get(url).pipe(
      map((result: any) => {
        return result;
      })
    )
  }


}
