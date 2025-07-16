import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { DepartamentoDTO } from './departamento.interface';

@Injectable({
  providedIn: 'root'
})
export class DepartamentoService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl + '/departamentos'

  public getAll() {
    return this.http.get<DepartamentoDTO[]>(this.baseUrl);
  }
}
