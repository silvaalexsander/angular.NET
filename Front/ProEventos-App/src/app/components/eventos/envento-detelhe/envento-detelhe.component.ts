import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-envento-detelhe',
  templateUrl: './envento-detelhe.component.html',
  styleUrls: ['./envento-detelhe.component.scss']
})
export class EnventoDetelheComponent implements OnInit {

  form!: FormGroup;

  get f(): any{
    return this.form.controls;
  }
  constructor(private fb: FormBuilder,
    ) { }

  ngOnInit() {
    this.validation();
  }

  private validation(): void{
    this.form = this.fb.group({
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      dataEvento: ['', [Validators.required]],
      qtdPessoas: ['', [Validators.required,Validators.min(1), Validators.max(120000)]],
      telefone: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(11)]],
      email: ['', [Validators.required, Validators.email]],
      imagemURL: ['', [Validators.required,]],
    });
  }

  reset(): void{
    this.form.reset();
  }
}
