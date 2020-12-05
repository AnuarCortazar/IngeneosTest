import { Component, OnInit } from '@angular/core';
import { Author } from 'src/app/shared/model/author';
import { AuthorInput } from 'src/app/shared/model/author-input';
import { OperationsService } from 'src/app/shared/service/operations.service';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {

  page = 1;
  pageSize = 20;
  collectionSize = 0;
  authors!: Author[];
  authorInput!: AuthorInput;

  constructor(private operationService: OperationsService) { }

  ngOnInit(): void {    
    this.authorInput = new AuthorInput();
    this.loadAuthors();
  }

  loadAuthors(){
    this.operationService.getAuthors()
        .subscribe(result => {          
          this.collectionSize = result.length;
          this.authors = result.slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
        })
  }

}
