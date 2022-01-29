import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ResultService {

  public sort: string;

  constructor() { }

  updateSort(sort:any)
  {
    this.sort=sort;
    console.log(this.sort);
  }

  returnSort() :string
  {
    
    return this.sort;
  }
}
