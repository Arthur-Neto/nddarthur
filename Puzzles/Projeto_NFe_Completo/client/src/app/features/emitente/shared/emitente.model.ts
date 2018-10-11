import { Endereco } from './../../../shared/models/endereco/endereco.model';
import { Documento } from './../../../shared/models/documento/documento.model';

export class Emitente {
    public id: number;
    public nomeFantasia: string;
    public razaoSocial: string;
    public cnpj: Documento;
    public inscricaoEstadual: string;
    public inscricaoMunicipal: string;
    public endereco: Endereco;
}

export class EmitenteDeleteCommand {
    public emitenteIds: number[];

    constructor(emitentes: Emitente[]) {
        this.emitenteIds = emitentes.map((p: Emitente) => p.id);
    }
}
