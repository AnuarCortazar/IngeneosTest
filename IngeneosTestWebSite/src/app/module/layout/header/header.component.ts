import { Component, OnInit } from '@angular/core';
import { OperationsService } from 'src/app/shared/service/operations.service';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from 'src/app/shared/service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  isLoggendIn = false;
  constructor(
    private operationService: OperationsService, 
    private router: Router,
    private authService: AuthService, 
    private modalService: NgbModal) { }

  ngOnInit(): void {
    this.isLoggendIn = this.authService.isLoggedIn();
  }

  sync(content: any){
    this.operationService.syncInformation().subscribe(result => {      
      this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
        console.log(result);
      }, (reason) => {
      });
    });
  }

}
