import { Component,  Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';

import * as $ from 'jquery';
import 'datatables.net';
import 'datatables.net-bs4';


@Component({
  selector: 'app-hitorico',
  templateUrl: './historico.component.html'
})
export class HistoricoComponent {
  public historicos: Historico[];
  dataTable: any

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Historico[]>(baseUrl + 'api/Historico').subscribe(result => {
      this.historicos = result;
      

    }, error => console.error(error));
    const table: any = $('table');
    this.dataTable = table.DataTable();
  }
}

interface Historico {
  codigo: number;
  tipoEnvio: string;
  usuario: string;
  status: string;
  codigoRegistro: number;
  dataTarefa: string;
}
