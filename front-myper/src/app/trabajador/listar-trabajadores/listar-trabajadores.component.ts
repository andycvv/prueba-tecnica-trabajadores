import { Component, inject, OnInit } from '@angular/core';
import { TrabajadorDTO } from '../trabajador.interface';
import { TrabajadorService } from '../trabajador.service';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-listar-trabajadores',
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './listar-trabajadores.component.html',
  styleUrl: './listar-trabajadores.component.css'
})
export class ListarTrabajadoresComponent implements OnInit {
  private trabajadorService = inject(TrabajadorService);

  trabajadores: TrabajadorDTO[] = []
  trabajadoresFiltrados: TrabajadorDTO[] = []

  ngOnInit(): void {
    this.trabajadorService.getAll().subscribe(trabajadores => {
      this.trabajadores = trabajadores;
      this.trabajadoresFiltrados = trabajadores;
    })
  }
}
