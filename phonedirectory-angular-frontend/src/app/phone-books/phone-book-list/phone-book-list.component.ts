import { Component, OnInit } from '@angular/core';
import { PhonebookService } from 'src/app/shared/phonebook.service';
import { PhoneBook } from 'src/app/shared/phonebook.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'phone-book-list',
  templateUrl: './phone-book-list.component.html',
  styleUrls: ['./phone-book-list.component.scss'],
})
export class PhoneBookListComponent implements OnInit {
  constructor(
    public service: PhonebookService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(phone: PhoneBook) {
    this.service.formData = Object.assign({}, phone);
    console.log(this.service.formData);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.delete(id).subscribe((res) => {
        this.service.refreshList();
        this.toastr.warning('Deleted successfully', 'Phonebook Register');
      });
    }
  }
}
