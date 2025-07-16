import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ProvinciaDTO } from './provincia.interface';

@Injectable({
  providedIn: 'root'
})
export class ProvinciaService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl + '/provincias'

  public getAll() {
    return this.http.get<ProvinciaDTO[]>(this.baseUrl);
  }
}
