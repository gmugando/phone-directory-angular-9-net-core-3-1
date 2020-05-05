import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PhoneBooksComponent } from './phone-books/phone-books.component';
import { PhoneEntriesComponent } from './phone-entries/phone-entries.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'phonebooks' },
  { path: 'phonebooks', component: PhoneBooksComponent },
  { path: 'entries/:id', component: PhoneEntriesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
