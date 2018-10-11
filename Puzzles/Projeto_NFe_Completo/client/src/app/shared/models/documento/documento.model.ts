import { TipoDocumento } from './documento.enum';

export class Documento {
    public id?: number;
    public numero: string;
    public tipo: TipoDocumento;
}
