import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorsField } from 'src/app/helpers/ValidatorsField';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  form!: FormGroup;

  constructor(private fb: FormBuilder) {
   }

  ngOnInit() {
    this.validation();
  }

  private validation(): void{

    const formOptions: AbstractControlOptions = {
      validators: ValidatorsField.MustMatch('senha', 'confirm')
    };

    this.form = this.fb.group({
      titulo: ['', [Validators.required,]],
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(15)]],
      sobrenome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email]],
      telefone: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(11)]],
      funcao: ['', [Validators.required]],
      descricao: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(150)]],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      confirm: ['', [Validators.required, Validators.minLength(6)]],
    },
    formOptions
    );
  }

  get f(): any{
    return this.form.controls;
  }

  reset(): void{
    this.form.reset();
  }

}
