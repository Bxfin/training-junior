import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BlogCriteria, PagedResult, Blog } from './model';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  private apiUrl = 'https://localhost:44324/api';
  constructor(private http: HttpClient) { }

  get(id: number) {
    return this.http.get<Blog>(`${this.apiUrl}/blogs/${id}`);
  }

  getPaged(criteria: BlogCriteria) {
    return this.http.get<PagedResult<Blog>>(`${this.apiUrl}/blogs`, { params: <any>criteria} )
  }

  create(entry:Blog) {
    return this.http.post<number>(`${this.apiUrl}/blogs`, entry);
  }

  update(id:number, entry:Blog) {
    return this.http.put<number>(`${this.apiUrl}/blogs/${id}`, entry);
  }

  delete(id:number) {
    return this.http.delete<number>(`${this.apiUrl}/blogs/${id}`);
  }
}
