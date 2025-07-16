import { Component, inject, OnInit, ViewChild } from '@angular/core';
import { TrabajadorCreacionDTO, TrabajadorDTO, TrabajadorEditarDTO } from '../trabajador.interface';
import { TrabajadorService } from '../trabajador.service';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalFormularioComponent } from '../modal-formulario/modal-formulario.component';
import { Modal } from 'bootstrap';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-listar-trabajadores',
  imports: [
    ReactiveFormsModule,
    ModalFormularioComponent,
    FormsModule
  ],
  templateUrl: './listar-trabajadores.component.html',
  styleUrl: './listar-trabajadores.component.css'
})
export class ListarTrabajadoresComponent implements OnInit {
  private trabajadorService = inject(TrabajadorService);

  trabajadores: TrabajadorDTO[] = []
  trabajadoresFiltrados: TrabajadorDTO[] = []

  filtroSexo: '' | 'M' | 'F' = '';

  modoFormulario: 'crear' | 'editar' = 'crear';
  trabajadorSeleccionado: TrabajadorEditarDTO | null = null;

  @ViewChild(ModalFormularioComponent)
  modalFormularioComponent!: ModalFormularioComponent;

  ngOnInit(): void {
    this.listarTrabajadores();
  }

  listarTrabajadores() {
    this.trabajadorService.getAll().subscribe(trabajadores => {
      this.trabajadores = trabajadores;
      this.trabajadoresFiltrados = trabajadores;
    })
  }
  
  filtrarTrabajadores() {
    if (!this.filtroSexo) {
      this.trabajadoresFiltrados = [...this.trabajadores];
    } else {
      this.trabajadoresFiltrados = this.trabajadores.filter(t => t.sexo === this.filtroSexo);
    }
  }

  eliminar(id: number) {
    Swal.fire({
      title: "¿Está seguro de eliminar el registro?",
      text: "Esta acción no se puede revertir",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Sí, eliminar"
    }).then((result) => {
      if (result.isConfirmed) {
        this.trabajadorService.delete(id).subscribe(() => {
          this.listarTrabajadores();
          Swal.fire({
            title: "Eliminado!",
            text: "El trabajador ha sido eliminado.",
            icon: "success"
          });
        })
      }
    });
  }

  abrirModalCrear() {
    this.modoFormulario = 'crear';
    this.trabajadorSeleccionado = null;
    this.modalFormularioComponent.resetFormulario();

    const modal = document.getElementById('exampleModal')!;
    const instance = Modal.getOrCreateInstance(modal);
    instance.show();
  }

  abrirModalEditar(id: number) {
    this.modoFormulario = 'editar';
    this.trabajadorService.getById(id).subscribe(trabajador => {
      this.trabajadorSeleccionado = trabajador;

      const modal = document.getElementById('exampleModal')!;
      const instance = Modal.getOrCreateInstance(modal);
      instance.show();
    });
  }

  actualizarLista() {
    const modal = document.getElementById('exampleModal')!;
    const instance = Modal.getOrCreateInstance(modal);
    instance.hide();
    this.listarTrabajadores();
  }

}
