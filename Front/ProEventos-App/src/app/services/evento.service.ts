import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../model/Evento';
import { take } from 'rxjs/operators';

@Injectable()
export class EventoService {

  baseUrl = 'https://localhost:7150/api/Eventos';
  constructor(private http : HttpClient) { }

  public getEventos(): Observable<Evento[]>{
    return this.http
    .get<Evento[]>(this.baseUrl)
    .pipe(take(1));
  }
  public getEventosByTema(tema: string): Observable<Evento[]>{
    return this.http
    .get<Evento[]>(`${this.baseUrl}/${tema}/tema`)
    .pipe(take(1));
  }
  public getEventoById(id : number): Observable<Evento>{
    return this.http
    .get<Evento>(`${this.baseUrl}/${id}`)
    .pipe(take(1));
  }
  public post(evento: Evento): Observable<any>{
    return this.http
    .post(this.baseUrl, evento)
    .pipe(take(1));
  }
  public put(evento: Evento): Observable<any>{
    return this.http
    .put(`${this.baseUrl}/${evento.id}`, evento)
    .pipe(take(1));
  }
  public deleteEvento(id: number): Observable<any>{
    return this.http
    .delete(`${this.baseUrl}/${id}`)
    .pipe(take(1));
  }
}
