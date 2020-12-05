import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationResult } from 'src/app/shared/model/authentication-result';
import { AuthService } from 'src/app/shared/service/auth.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  result!: AuthenticationResult;

  constructor(
    private authService: AuthService, 
    private router: Router) { }

  ngOnInit(): void {
    
  }

  onLogin(loginForm: NgForm) {    
    this.authService.login(loginForm.value).subscribe(result => {
      this.result = result;
      console.log(result);
      if(this.result.success) {
        localStorage.setItem('token', this.result.token);
        this.router.navigate(['/books']);        
      } else{
        console.error('informacion incorrecta,  intenta nuevamente!');
      }
    });
    
  }

}
