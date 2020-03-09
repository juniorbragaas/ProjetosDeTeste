import { Component,  Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';


import * as $ from 'jquery';
import 'datatables.net';
import dt from 'datatables.net-bs4';


@Component({
  selector: 'app-cte',
  templateUrl: './cte.component.html'
})
export class CteComponent {
  public ctes: any;
  public dataInicio = new Date(1900, 1, 1).toISOString().slice(0, 10); 
  public dataFim = new Date().toISOString().slice(0, 10); 
  dataTable: any;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Cte[]>(baseUrl + 'api/Cte/BuscarIntervaloData?datainicial='+this.dataInicio+'&&datafinal='+this.dataFim).subscribe(result => {
      this.ctes = result;
      //You'll have to wait that changeDetection occurs and projects data into 
      // the HTML template, you can ask Angular to that for you ;-)
     // this.chRef.detectChanges();

      // Now you can use jQuery DataTables :
      const table: any = $('table');
      this.dataTable = table.DataTable();
    }, error => console.error(error));
  }
}

interface Cte {
  codigo: number;
  numeroCte: string;
  numeroTentativasEnvio: number;
  dataEnvio: string;
  status: string;
}


