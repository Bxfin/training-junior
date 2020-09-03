import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogService } from '../blog.service';
import { Blog } from '../model';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-blog-details',
  templateUrl: './blog-details.component.html',
  styleUrls: ['./blog-details.component.scss']
})
export class BlogDetailsComponent implements OnInit {

  id: number;
  isEdit: boolean = false;
  pageTitle: string;
  model: Blog;
  fg: FormGroup;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private blogService: BlogService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      let id = +params.id;
      if (id) {
        this.id = id;
        this.isEdit = true;
      }
      this.init();
    })
  }

  private init() {

    if (this.isEdit) {
      this.blogService.get(this.id).subscribe(r => {
        this.model = r;
        this.pageTitle = this.model.title;
        this.initForm();
      });
    } else {
      this.model = {
        id: 0,
        title: null,
        category: null,
        author: null
      }
      this.pageTitle = 'Create';
      this.initForm();
    }
  }

  private initForm() {
    this.fg = new FormGroup({
      id: new FormControl(this.model.id),
      title: new FormControl(this.model.title, Validators.required),
      author: new FormControl(this.model.author, Validators.required),
      category: new FormControl(this.model.category, Validators.required),
    });
  }

  submit() {
    const entry: Blog = this.fg.getRawValue();

    if(this.isEdit) {
      this.blogService.update(this.id, entry).subscribe(r=> {
        this.router.navigate(['/blogs']);
      });
    }else {
      this.blogService.create(entry).subscribe(r=> {
        this.router.navigate(['/blogs']);
      });
    }
  }
}
