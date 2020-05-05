import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-phone-entries',
  templateUrl: './phone-entries.component.html',
  styleUrls: ['./phone-entries.component.scss'],
})
export class PhoneEntriesComponent implements OnInit {
  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      var phoneBookId = params.get('id');
    });
  }
}
