import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { TrabajadorCreacionDTO, TrabajadorDTO } from './trabajador.interface';

@Injectable({
  providedIn: 'root'
})
export class TrabajadorService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl + '/trabajadores'

  public getAll() {
    return this.http.get<TrabajadorDTO[]>(this.baseUrl);
  }

  public getById(id: number) {
    return this.http.get<TrabajadorDTO[]>(`${this.baseUrl}/${id}`);
  }

  public create(trabajador: TrabajadorCreacionDTO) {
    return this.http.post(this.baseUrl, trabajador);
  }

  public update(id: number, trabajador: TrabajadorCreacionDTO) {
    return this.http.put(`${this.baseUrl}/${id}`,  trabajador)
  }
  
  public delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
