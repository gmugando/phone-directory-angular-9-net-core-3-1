import { PhoneBook } from './phonebook.model';

export class Entry {
  EntryId: number;
  PhoneBookId: number;
  Name: string;
  PhoneNumber: string;
  // PhoneBook: PhoneBook;
}

export class EntryList {
  totalItems: number;
  items: Entry[];
  // PhoneBook: PhoneBook;
}
