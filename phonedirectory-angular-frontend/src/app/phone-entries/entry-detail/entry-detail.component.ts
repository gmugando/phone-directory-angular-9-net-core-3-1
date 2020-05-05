import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EntryService } from 'src/app/shared/entry.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'entry-detail',
  templateUrl: './entry-detail.component.html',
  styleUrls: ['./entry-detail.component.scss'],
})
export class EntryDetailComponent implements OnInit {
  constructor(
    public service: EntryService,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.CurrentPhoneBookId = +params.get('id');
    });
    this.resetForm();
  }

  CurrentPhoneBookId: number;

  resetForm(form?: NgForm) {
    if (form != null) form.resetForm();
    this.service.formData = {
      EntryId: null,
      PhoneBookId: this.CurrentPhoneBookId,
      Name: '',
      PhoneNumber: '',
    };
  }

  onSubmit(form: NgForm) {
    form.value.PhoneBookId = this.CurrentPhoneBookId;
    if (form.value.EntryId == null) this.insertRecord(form);
    else this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.post(form.value).subscribe(
      (res) => {
        this.toastr.success('Inserted successfully', 'Phonebook Manager');
        this.resetForm(form);
        this.service.refreshList(this.CurrentPhoneBookId, '');
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
        this.service.refreshList(this.CurrentPhoneBookId, '');
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
