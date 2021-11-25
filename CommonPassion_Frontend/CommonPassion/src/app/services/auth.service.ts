import { Injectable, Testability } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { LoginComponent } from '../components/login/login.component';
import { Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loginPath = environment.apiUrl + '/identity/login';
  private registerPath = environment.apiUrl + '/identity/register';

  constructor(private http : HttpClient) {
   }

   login(data:any) : Observable<any>{
     return this.http.post(this.loginPath, data);
   }

   register(data:any) :Observable<any>{
     return this.http.post(this.registerPath, data);
   }

   saveToken(token: any){
     localStorage.setItem('token', token);
   }

   getToken(){
     return localStorage.getItem('token');
   }
}
