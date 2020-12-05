import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AuthenticationResult } from '../model/authentication-result';
import { User } from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl: string;
  
  constructor(private http: HttpClient) { 
    this.baseUrl = environment.baseUrl + '/auth';
  }

  login(user: User) : Observable<AuthenticationResult> {
    let url = this.baseUrl + '/login';    
    return this.http.post(url, user).pipe(
      map((result: any) => {
        return result;
      })
    )
  }

  isLoggedIn(){
    if (localStorage.getItem('token')) { return true; }
    return false;
  }

  logOut(){
    localStorage.removeItem('token');
  }
}
