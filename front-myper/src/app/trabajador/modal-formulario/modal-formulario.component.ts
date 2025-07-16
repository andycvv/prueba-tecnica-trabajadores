import { Component, EventEmitter, inject, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { TrabajadorService } from '../trabajador.service';
import { TrabajadorCreacionDTO, TrabajadorDTO, TrabajadorEditarDTO } from '../trabajador.interface';
import { DepartamentoService } from '../../departamento/departamento.service';
import { DepartamentoDTO } from '../../departamento/departamento.interface';
import { ProvinciaService } from '../../provincia/provincia.service';
import { ProvinciaDTO } from '../../provincia/provincia.interface';
import { DistritoService } from '../../distrito/distrito.service';
import { DistritoDTO } from '../../distrito/distrito.interface';

@Component({
  selector: 'app-modal-formulario',
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './modal-formulario.component.html',
  styleUrl: './modal-formulario.component.css'
})
export class ModalFormularioComponent implements OnInit, OnChanges {
  private trabajadorService = inject(TrabajadorService);
  private departamentoService = inject(DepartamentoService);
  private provinciaService = inject(ProvinciaService);
  private distritoService = inject(DistritoService);
  private fb = inject(FormBuilder);

  @Input({ required: true }) modo!: 'crear' | 'editar';
  @Input() trabajadorEditar?: TrabajadorEditarDTO;

  @Output() guardarCambios = new EventEmitter<void>();

  departamentos: DepartamentoDTO[] = [];
  provincias: ProvinciaDTO[] = [];
  distritos: DistritoDTO[] = [];

  formulario = this.fb.group({
    tipoDocumento: ['DNI', Validators.required],
    numeroDocumento: ['', Validators.required],
    nombres: ['', Validators.required],
    sexo: ['', Validators.required],
    departamentoId: [0, Validators.min(1)],
    provinciaId: [0, Validators.min(1)],
    distritoId: [0, Validators.min(1)],
  })

  ngOnInit(): void {
    this.departamentoService.getAll().subscribe(departamentos => {
      this.departamentos = departamentos;
    })

    this.provinciaService.getAll().subscribe(provincias => {
      this.provincias = provincias;
    })

    this.distritoService.getAll().subscribe(distritos => {
      this.distritos = distritos;
    })
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['trabajadorEditar'] && this.trabajadorEditar) {
      this.formulario.patchValue(this.trabajadorEditar);
    }
  }

  guardar() {
    if (this.formulario.invalid) return;

    const trabajador = this.formulario.value as TrabajadorCreacionDTO;
    if (this.modo === 'crear') {
      this.trabajadorService.create(trabajador).subscribe(() => {
        this.guardarCambios.emit();
      })
    } else {
      this.trabajadorService.update(this.trabajadorEditar!.id!, trabajador).subscribe(() => {
        this.guardarCambios.emit();
      })
    }
  }

  resetFormulario() {
    this.formulario.reset({
      tipoDocumento: 'DNI',
      numeroDocumento: '',
      nombres: '',
      sexo: '',
      departamentoId: 0,
      provinciaId: 0,
      distritoId: 0
    });
  }
}
