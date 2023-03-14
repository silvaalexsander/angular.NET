import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/model/Evento';
import { EventoService } from 'src/app/services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  modalRef: BsModalRef | undefined;
  public eventos: Evento[] = [] ;
  public eventosFiltrados: any = [];
  public widthImg: number = 50;
  public marginImg: number = 2;
  public frase: string = '';
  isCollapsed: boolean = true;
  private _filtroLista: string = '';


  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string}) => evento.tema.toLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLowerCase().indexOf(filtrarPor) !== -1);
  }
  constructor(
    private eventoService : EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService
    )
    { }

  public ngOnInit(): void {
    this.getEventos();
    this.mudaFrase();
  }

  public mudaFrase(): boolean{
    if(!this.isCollapsed){
      this.frase = 'Exibir';
      return true;
    }else{
      this.frase = 'Ocultar';
      return false;
    }
  }

  public getEventos(): void{
    this.eventoService.getEventos().subscribe(
      {next: (_eventos : Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: (error : any) => console.log(error)
  });

  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Evento deletado com sucesso!', 'Sucesso!');
  }

  decline(): void {
    this.modalRef?.hide();
    this.toastr.error('Ação cancelada!', 'Cancelado!');
  }

}
