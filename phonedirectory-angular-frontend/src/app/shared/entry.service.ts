import { Injectable } from '@angular/core';
import { Entry, EntryList } from './entry.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class EntryService {
  formData: Entry;
  list: Entry[];
  readonly rootURL = 'https://localhost:5001/api/entry';
  constructor(private http: HttpClient) {}

  post(formData: Entry) {
    return this.http.post(this.rootURL, formData);
  }

  refreshList(phoneBookId: number, nameFilter: string) {
    this.http
      .get(
        this.rootURL +
          `?PhoneBookId=${phoneBookId}&EntryName=${nameFilter}&Page=1&ItemsPerPage=100`
      )
      .toPromise()
      .then((res) => {
        var result = res as EntryList;
        var entries = result.items;
        var tempList = new Array<Entry>();
        for (var i = 0; i < entries.length; i++) {
          let ar = entries[i];
          tempList.push({
            EntryId: ar['entryId'],
            PhoneBookId: ar['phoneBookId'],
            Name: ar['name'],
            PhoneNumber: ar['phoneNumber'],
          });
        }
        this.list = tempList;
      });
  }

  update(formData: Entry) {
    return this.http.put(this.rootURL + '/' + formData.EntryId, formData);
  }

  delete(id: number) {
    return this.http.delete(this.rootURL + '/' + id);
  }
}
