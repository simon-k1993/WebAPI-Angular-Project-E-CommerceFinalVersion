import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent {
  baseUrl = environment.apiUrl;
  validationErrors: string[] = [];

  constructor(private http: HttpClient,private toastr: ToastrService) {}

  get404Error() {
    this.http.get(this.baseUrl + 'products/42').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)           
    })
  }

  get500Error() {
    this.http.get(this.baseUrl + 'buggy/servererror').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)           
    })
  }

  get400Error() {
    this.http.get(this.baseUrl + 'buggy/badrequest').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)           
    })
  }

  get400ValidationError() {
    this.http.get(this.baseUrl + 'products/fortytwo').subscribe({
      next: response => console.log(response),
      error: (error: any) => {
        console.log(error);
  
        if (error.status === 400 && error.error.errors) {
         
          this.validationErrors = error.error.errors;
  
          
          this.toastr.error('Validation error. Please check the form.', 'Validation Error');
        } else {
          
          this.toastr.error('An error occurred. Please try again later.', 'Error');
        }
      },
    });
}}
