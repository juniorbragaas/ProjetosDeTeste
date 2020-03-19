import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { CteComponent } from './cte/cte.component';
import { HistoricoComponent } from './historico/historico.component';
import { FaturaComponent } from './fatura/fatura.component';
import { OcorrenciaComponent } from './ocorrencia/ocorrencia.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    CteComponent,
        HistoricoComponent,
        FaturaComponent,
        OcorrenciaComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'cte', component: CteComponent },
        { path: 'historico', component: HistoricoComponent },
        { path: 'fatura', component: FaturaComponent },
        { path: 'ocorrencia', component: OcorrenciaComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
