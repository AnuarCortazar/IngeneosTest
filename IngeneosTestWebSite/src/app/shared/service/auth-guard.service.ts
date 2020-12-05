import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable()
export class AuthGuardService implements CanActivate {
  constructor(public auth: AuthService, public router: Router) {}
  canActivate(): boolean {
    console.log(this.auth.isLoggedIn());
    if (!this.auth.isLoggedIn()) {
      this.router.navigate(['account']);
      return false;
    }
    return true;
  }
}