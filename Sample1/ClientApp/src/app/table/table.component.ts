import { Component, OnInit } from '@angular/core';
import { FormComponent } from '../form/form.component';
import { DataServiceService } from '../data-service.service';
import { Articles } from '../articles';
import { Router } from '@angular/router';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  articleList: any[] = [];
  constructor(public dataService: DataServiceService,public router:Router) { }
  
  ngOnInit() {
    this.getArticles();
  }
  create() {
    this.router.navigate(['form']);
  }
  edit(id:number) {
    this.router.navigate(['form', id]);
  }
  getArticles() {
    this.dataService.getArticles().subscribe((res: any[]) => {
      this.articleList = res;
    })
  }
  delete(id:number) {
    this.dataService.deleteArticles(id).subscribe((res: any[]) => {
      this.articleList = res;
      alert("deleted");
      this.getArticles();
    })
  }
}
