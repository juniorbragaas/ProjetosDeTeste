import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cte',
  templateUrl: './cte.component.html'
})
export class CteComponent {
  public ctes: Cte[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Cte[]>(baseUrl + 'api/Ctes').subscribe(result => {
      this.ctes = result;
    }, error => console.error(error));
  }
}

interface Cte {
  codigo: number;
  numeroCte: string;
  icms: string;
  dataEnvio: string;
}
