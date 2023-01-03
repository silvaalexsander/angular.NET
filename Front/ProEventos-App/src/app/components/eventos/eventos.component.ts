import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  widthImg: number = 50;
  marginImg: number = 2;
  frase: string = '';
  isCollapsed: boolean = true;
  private _filtroLista: string = '';


  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string}) => evento.tema.toLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLowerCase().indexOf(filtrarPor) !== -1);
  }
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
    if(this.isCollapsed){
      this.frase = 'Mostrar Imagens';
    }else{
      this.frase = 'Esconder Imagens';
    }
  }

  public mudaFrase(){
    if(!this.isCollapsed){
      this.frase = 'Mostrar Imagens';
    }else{
      this.frase = 'Esconder Imagens';
    }
  }

  public getEventos(){
    this.http.get('https://localhost:7150/api/Evento').subscribe(
      response => {this.eventos = response; this.eventosFiltrados = this.eventos;},
      error => console.log(error)
    );

  }

}
