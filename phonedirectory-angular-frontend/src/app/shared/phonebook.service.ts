import { Injectable } from '@angular/core';
import { PhoneBook } from './phonebook.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class PhonebookService {
  formData: PhoneBook;
  list: PhoneBook[];
  readonly rootURL = 'https://localhost:5001/api/phonebook';
  constructor(private http: HttpClient) {}

  post(formData: PhoneBook) {
    return this.http.post(this.rootURL, formData);
  }

  refreshList() {
    this.http
      .get(this.rootURL)
      .toPromise()
      .then((res) => {
        var phonebooks = res as PhoneBook[];
        var tempList = new Array<PhoneBook>();
        for (var i = 0; i < phonebooks.length; i++) {
          let ar = phonebooks[i];
          tempList.push({
            PhoneBookId: ar['phoneBookId'],
            PhoneBookName: ar['phoneBookName'],
          });
        }
        this.list = tempList; // res as PhoneBook[];
      });
  }

  update(formData: PhoneBook) {
    return this.http.put(this.rootURL + '/' + formData.PhoneBookId, formData);
  }

  delete(id: number) {
    return this.http.delete(this.rootURL + '/' + id);
  }
}
