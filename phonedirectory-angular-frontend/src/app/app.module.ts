import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PhoneBooksComponent } from './phone-books/phone-books.component';
import { PhoneEntriesComponent } from './phone-entries/phone-entries.component';
import { PhoneBookListComponent } from './phone-books/phone-book-list/phone-book-list.component';
import { PhoneBookDetailComponent } from './phone-books/phone-book-detail/phone-book-detail.component';
import { EntryListComponent } from './phone-entries/entry-list/entry-list.component';
import { EntryDetailComponent } from './phone-entries/entry-detail/entry-detail.component';

import { PhonebookService } from './shared/phonebook.service';
import { EntryService } from './shared/entry.service';
import { EntrySearchComponent } from './phone-entries/entry-search/entry-search.component';

@NgModule({
  declarations: [
    AppComponent,
    PhoneBooksComponent,
    PhoneEntriesComponent,
    PhoneBookListComponent,
    PhoneBookDetailComponent,
    EntryListComponent,
    EntryDetailComponent,
    EntrySearchComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ToastrModule.forRoot(),
  ],
  providers: [PhonebookService, EntryService],
  bootstrap: [AppComponent],
})
export class AppModule {}
