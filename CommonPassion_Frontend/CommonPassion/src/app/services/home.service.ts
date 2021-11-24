import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class HomeService {
private homePath= environment+ '/home';

  constructor(private httpClient: HttpClient) { }


  
}
