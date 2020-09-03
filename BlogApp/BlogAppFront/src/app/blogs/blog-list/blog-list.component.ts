import { Component, OnInit } from '@angular/core';
import { BlogService } from '../blog.service';
import { BlogCriteria, PagedResult, Blog } from '../model';

@Component({
  selector: 'app-blog-list',
  templateUrl: './blog-list.component.html',
  styleUrls: ['./blog-list.component.scss']
})
export class BlogListComponent implements OnInit {

  model: PagedResult<Blog>;
  private criteria:BlogCriteria = {};
  constructor(private blogService: BlogService) { }

  ngOnInit() {
    this.load();
  }

  private load() {
    this.blogService.getPaged(this.criteria).subscribe(r=> {
      this.model = r;
    });
  }

  delete(item: Blog){
    this.blogService.delete(item.id).subscribe(r=> {
      this.load();
    });
  }

}
