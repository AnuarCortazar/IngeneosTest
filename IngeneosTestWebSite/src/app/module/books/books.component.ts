import { Component, OnInit } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { Book } from 'src/app/shared/model/book';
import { BookInput } from 'src/app/shared/model/book-input';
import { ExcelService } from 'src/app/shared/service/excel.service';
import { OperationsService } from 'src/app/shared/service/operations.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  page = 1;
  pageSize = 20;
  collectionSize = 0;
  books!: Book[];
  bookInput!: BookInput;
  modelInitial!: NgbDateStruct;
  modelFinal!: NgbDateStruct;

  constructor(
    private operationService: OperationsService,
    private excelService:ExcelService) { }

  ngOnInit(): void {    
    this.bookInput = new BookInput();
    this.bookInput.idAuthor = 0;
    this.loadBooks();
  }

  loadBooks(){
    if(this.modelInitial !== undefined) this.bookInput.initialPublishDate = new Date(this.modelInitial.year, this.modelInitial.month-1, this.modelInitial.day);
    if(this.modelFinal !== undefined) this.bookInput.finalPublishDate = new Date(this.modelFinal.year, this.modelFinal.month-1, this.modelFinal.day);
    this.operationService.getBooks(this.bookInput)
        .subscribe(result => {          
          this.collectionSize = result.length;
          this.books = result.slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
        })
  }

  exportAsXLSX():void {
    this.operationService.getBooks(this.bookInput).subscribe(result => { 
      this.excelService.exportAsExcelFile(result, 'books');
    });    
  }

}
