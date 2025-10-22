import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class Auth {
  private baseUrl = `${environment.apiUrl}/auth`;

  constructor(private http: HttpClient) { }

  register(user: any) {
    return this.http.post(`${this.baseUrl}/register`, user);
  }

  login(credential: any) {
    return this.http.post(`${this.baseUrl}/login`, credential);
  }
}
