import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { ActivatedRoute } from '@angular/router';
import { UserDetail } from '../models/user-detail';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  Url = `${environment.baseUrl}api/users/`;

  constructor(private http: HttpClient) {

  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.Url);
  }

  getUsersDetailed(id: number): Observable<UserDetail> {
    return this.http.get<UserDetail>(this.Url + id);
  }

  updateUser(id: number, userDetail: any) {
    return this.http.put(this.Url + id, userDetail);
  }

  exportExcel() {
    return this.http.get(this.Url + "exportexcel", {
      responseType: 'Blob' as 'json'
    });
  }

}
