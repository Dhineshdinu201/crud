import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Articles } from './articles';

@Injectable({
  providedIn: 'root'
})
export class DataServiceService {

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) { }
  getArticles() {
    return this.http.get(this.baseUrl + "api/Articles");
  }
  getArticlesById(id: number) {
    return this.http.get(this.baseUrl + "api/Articles/" + id);
  }
  postArticles(articles: Articles) {
    return this.http.post(this.baseUrl + "api/Articles", articles);
  }
  putArticles(id:number,articles: Articles) {
    return this.http.put(this.baseUrl + "api/Articles/" + id, articles);
  }
  deleteArticles(id: number) {
    return this.http.delete(this.baseUrl + "api/Articles/" + id);
  }
}
