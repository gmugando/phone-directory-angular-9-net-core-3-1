import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EntryService } from 'src/app/shared/entry.service';
import { ToastrService } from 'ngx-toastr';
import { Entry } from 'src/app/shared/entry.model';

@Component({
  selector: 'entry-list',
  templateUrl: './entry-list.component.html',
  styleUrls: ['./entry-list.component.scss'],
})
export class EntryListComponent implements OnInit {
  constructor(
    public service: EntryService,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.CurrentPhoneBookId = +params.get('id');
      this.service.refreshList(this.CurrentPhoneBookId, '');
    });
  }

  CurrentPhoneBookId: number;

  populateForm(entry: Entry) {
    this.service.formData = Object.assign({}, entry);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.delete(id).subscribe((res) => {
        this.service.refreshList(this.CurrentPhoneBookId, '');
        this.toastr.warning('Deleted successfully', 'Phonebook Register');
      });
    }
  }
}
