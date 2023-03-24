import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/model/Evento';
import { EventoService } from 'src/app/services/evento.service';


@Component({
  selector: 'app-envento-detelhe',
  templateUrl: './envento-detelhe.component.html',
  styleUrls: ['./envento-detelhe.component.scss']
})
export class EnventoDetelheComponent implements OnInit {
  evento = {} as Evento;
  form!: FormGroup;
  estadoSalvar = 'post';

  get f(): any{
    return this.form.controls;
  }

  get bsConfig(): any{
    return {isAnimated: true,
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY hh:mm a',
      containerClass: 'theme-default',
      showWeekNumbers: false,

      };
  }

  reset(): void{
    this.form.reset();
  }

  constructor(private fb: FormBuilder,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private eventoService: EventoService,
    private toastr: ToastrService)
    {
      this.localeService.use('pt-br');
    }

    ngOnInit() {
      this.carregarEvento();
      this.validation();
    }


    public carregarEvento(): void{
      
      const eventoIdParam = this.router.snapshot.paramMap.get('id');
      if (eventoIdParam !== null){
        this.estadoSalvar = 'put';
        this.eventoService.getEventoById(+eventoIdParam).subscribe(
          {
            next: (evento: Evento) => {
              this.evento = {...evento};
              this.form.patchValue(this.evento);
            },
            error: (error: any) => {console.error(error); this.toastr.error('Erro ao tentar carregar evento', 'Erro'); },
            complete: () => {console.log('Carregado com sucesso'); }
          }
        );
      }
    }

    public salvarEvento(): void{
      if (this.form.valid){

         this.estadoSalvar === 'post'
          ? this.evento = {...this.form.value}
          : this.evento = {id: this.evento.id, ...this.form.value};

        this.eventoService[this.estadoSalvar](this.evento).subscribe(
          {
            next: (evento: Evento) => {this.toastr.success('Evento salvo com sucesso', 'Sucesso'); },
            error: (error: any) => {console.error(error); this.toastr.error('Erro ao tentar salvar evento', 'Erro'); },
            complete: () => {}
          }
        );
      }
    }

  private validation(): void{
    this.form = this.fb.group({
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      dataEvento: ['', [Validators.required]],
      qtdPessoa: ['', [Validators.required,]],
      telefone: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(11)]],
      email: ['', [Validators.required, Validators.email]],
      imagemURL: ['', [Validators.required,]],
    });
  }

}
