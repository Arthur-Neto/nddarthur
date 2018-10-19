import { TipoDocumento } from './documento.enum';

export class Documento {
    public id?: number;
    public numero: string;
    public tipo: TipoDocumento;

    constructor(numero: string, tipo: TipoDocumento) {
        this.numero = numero;
        this.tipo = tipo;
    }
}
