import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EntryService } from 'src/app/shared/entry.service';
import { SearchCriteria } from 'src/app/shared/search.model';

@Component({
  selector: 'entry-search',
  templateUrl: './entry-search.component.html',
  styleUrls: ['./entry-search.component.scss'],
})
export class EntrySearchComponent implements OnInit {
  constructor(public service: EntryService, private route: ActivatedRoute) {
    this.formData = new SearchCriteria();
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.CurrentPhoneBookId = +params.get('id');
    });
  }

  formData: SearchCriteria;
  CurrentPhoneBookId: number;

  onSubmit(form: NgForm) {
    if (form.value.Name == null) console.log('no text');
    else console.log(form.value.Name);
    this.service.refreshList(this.CurrentPhoneBookId, form.value.Name);
  }
}
