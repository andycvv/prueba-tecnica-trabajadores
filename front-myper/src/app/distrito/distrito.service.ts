import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { DistritoDTO } from './distrito.interface';

@Injectable({
  providedIn: 'root'
})
export class DistritoService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl + '/distritos'

  public getAll() {
    return this.http.get<DistritoDTO[]>(this.baseUrl);
  }
}
