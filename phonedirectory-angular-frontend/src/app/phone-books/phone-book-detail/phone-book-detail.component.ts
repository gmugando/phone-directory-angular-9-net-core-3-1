import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PhonebookService } from 'src/app/shared/phonebook.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'phone-book-detail',
  templateUrl: './phone-book-detail.component.html',
  styleUrls: ['./phone-book-detail.component.scss'],
})
export class PhoneBookDetailComponent implements OnInit {
  constructor(
    public service: PhonebookService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) form.resetForm();
    this.service.formData = {
      PhoneBookId: null,
      PhoneBookName: '',
    };
  }

  onSubmit(form: NgForm) {
    if (form.value.PhoneBookId == null) this.insertRecord(form);
    else this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.post(form.value).subscribe(
      (res) => {
        this.toastr.success('Inserted successfully', 'Phonebook Manager');
        this.resetForm(form);
        this.service.refreshList();
      },
      (err) => {
        this.toastr.success(
          'Error adding phonebook. Please try again  later.',
          'Phonebook Manager'
        );
        console.log(err);
      }
    );
  }

  updateRecord(form: NgForm) {
    this.service.update(form.value).subscribe(
      (res) => {
        this.toastr.info('Updated successfully', 'Phonebook Manager');
        this.resetForm(form);
        this.service.refreshList();
      },
      (err) => {
        this.toastr.success(
          'Error updating phonebook. Please try again  later.',
          'Phonebook Manager'
        );
        console.log(err);
      }
    );
  }
}
