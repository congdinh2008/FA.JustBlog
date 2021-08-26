import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss'],
})
export class CategoryListComponent implements OnInit {
  public title: string = 'Categories';
  public categories!: any[];
  private url: string = 'https://localhost:44340/api/categories';

  constructor(private httpClient: HttpClient) {}

  ngOnInit(): void {
    this.getCategories().subscribe((data) => {
      this.categories = data;
      console.log(this.categories);
    });
  }

  private getCategories(): Observable<any> {
    return this.httpClient.get(this.url);
  }

  public createNewCategory() {
    let category = {
      id: uuidv4(),
      name: 'Category 07',
      urlSlug: 'category-07',
      description: 'Category 07',
    };

    this.httpClient.post(this.url, category).subscribe((data) => {
      console.log(data);
      this.getCategories().subscribe((data) => {
        this.categories = data;
        console.log(this.categories);
      });
    });
  }
}
