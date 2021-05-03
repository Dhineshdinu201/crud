import { Component, OnInit, EventEmitter, Inject } from '@angular/core';
import { Articles } from '../articles';
import { DataServiceService } from '../data-service.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { FileUploader } from 'ng2-file-upload';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  articles: Articles = new Articles();
  uploader: FileUploader;
  url: string = "";
  id: number;
  isEdit: boolean = false;
  contactForm: FormGroup;
  constructor(public dataService: DataServiceService, private formBuilder: FormBuilder, private route: ActivatedRoute, @Inject('BASE_URL') public baseUrl: string) {
    this.uploader = new FileUploader({
      url: "api/Image",
      autoUpload: true,
      method: 'post',
      allowedFileType: ['image'],
      queueLimit:1
    });
    this.createContactForm();
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.uploader.onCompleteItem = (item: any, response: any, status: any, headers: any) => {
      let dataURL = JSON.parse(response);
      console.log(dataURL);
      this.articles.uploadURL = this.baseUrl+"uploads/img/" + dataURL.url;

    };
    if (this.id != undefined) {
      this.isEdit = true;
      this.dataService.getArticlesById(this.id).subscribe((res: Articles) => {
        this.articles = res;
        this.createContactForm();
      })
    }
    else {
      this.articles.title = "";
      this.articles.description = "";
      this.articles.overview = "";
      
    }
  }
  createContactForm() {
    this.contactForm = this.formBuilder.group({
      title: [this.articles.title,],
      description: [this.articles.description],
      overview: [this.articles.overview]
    });
  }
  onSubmit() {
    
    let data = this.contactForm.value;
    this.articles.title = data.title;
    this.articles.description = data.description;
    this.articles.overview = data.overview;
    this.articles.createdBy = "dhinesh";
    this.articles.status = true;
    this.articles.crateDate = new Date();
    if (this.isEdit == false) {
      this.dataService.postArticles(this.articles).subscribe((res: any[]) => {
        console.log(res);
      })
    }
    else {
      this.dataService.putArticles(this.id,this.articles).subscribe((res: any[]) => {
        console.log(res);
      })
    }
  }


}
