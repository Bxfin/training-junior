import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BlogCriteria, PagedResult, Blog } from './model';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  private apiUrl = 'https://localhost:44324/api';
  constructor(private http: HttpClient) { }

  getPaged(criteria: BlogCriteria) {
    return this.http.get<PagedResult<Blog>>(`${this.apiUrl}/blogs`, { params: <any>criteria} )
  }

  delete(id:number) {
    return this.http.delete<number>(`${this.apiUrl}/blogs/${id}`);
  }
}
