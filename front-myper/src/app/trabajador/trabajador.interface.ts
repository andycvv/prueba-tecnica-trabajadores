export interface TrabajadorDTO {
  id: number;
  tipoDocumento: string;
  numeroDocumento: string;
  nombres: string;
  sexo: string;
  departamento: string;
  provincia: string;
  distrito: string;
}

export interface TrabajadorCreacionDTO {
  tipoDocumento: string;
  numeroDocumento: string;
  nombres: string;
  sexo: string;
  departamentoId: number;
  provinciaId: number;
  distritoId: number;
}