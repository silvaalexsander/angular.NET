import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorsField } from 'src/app/helpers/ValidatorsField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  form!: FormGroup;

  constructor(private fb: FormBuilder,) {
   }

  ngOnInit(): void {
    this.validation();
  }

  private validation(): void{
    const formOptions: AbstractControlOptions = {
      validators: ValidatorsField.MustMatch('senha', 'confirm')
    };

    this.form = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(15)]],
      sobrenome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email]],
      usuario: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(15)]],
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
