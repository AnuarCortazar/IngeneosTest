import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountComponent } from './module/account/account.component';
import { AuthorsComponent } from './module/authors/authors.component';
import { BooksComponent } from './module/books/books.component';
import { AuthGuardService as AuthGuard  } from '../app/shared/service/auth-guard.service';

const routes: Routes = [
  { path: '', redirectTo:'books', pathMatch: 'full' },
  { path: 'books', component: BooksComponent, canActivate: [AuthGuard] },
  { path: 'authors', component: AuthorsComponent, canActivate: [AuthGuard] },
  { path: 'account', component: AccountComponent },
  { path: '**', component: AccountComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
