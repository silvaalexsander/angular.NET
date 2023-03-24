import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/model/Evento';
import { EventoService } from 'src/app/services/evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {

  modalRef: BsModalRef | undefined;
  public eventos: Evento[] = [] ;
  public eventosFiltrados: any = [];
  public widthImg: number = 50;
  public marginImg: number = 2;
  public frase: string = '';
  isCollapsed: boolean = true;
  private _filtroLista: string = '';
  public eventoId: number = 0;

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
    private toastr: ToastrService,
    private router: Router
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

  openModal(event: any, template: TemplateRef<any>, eventoId: number): void {
    event.stopPropagation();
    this.eventoId = eventoId;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.eventoService.deleteEvento(this.eventoId).subscribe(
      {
        next: (result: any) => {
            console.log(result);
            this.toastr.success('Evento deletado com sucesso!', 'Sucesso!');
            this.getEventos();
         },
        error: (error: any) => {console.error(error); this.toastr.error('Erro ao tentar deletar evento', 'Erro'); },
        complete: () => {}
      }
    );

  }

  decline(): void {
    this.modalRef?.hide();
    this.toastr.error('Ação cancelada!', 'Cancelado!');
  }

  detalheEvento(id: number): void{
    this.router.navigate([`eventos/detalhe/${id}`]);
  }
}
