import { Endereco } from '../../endereco/shared/model/endereco.model';
import { Documento } from './../../../shared/models/documento/documento.model';

export class Emitente {
    public id?: number;
    public nomeFantasia?: string;
    public razaoSocial: string;
    public cnpj?: Documento;
    public inscricaoEstadual?: string;
    public inscricaoMunicipal?: string;
    public endereco?: Endereco;
}

export class EmitenteExcluirComando {
    public emitenteIds: number[];

    constructor(emitentes: Emitente[]) {
        this.emitenteIds = emitentes.map((p: Emitente) => p.id);
    }
}

export class EmitenteAdicionarComando {
    public nomeFantasia: string;
    public razaoSocial: string;
    public cnpj: Documento;
    public inscricaoEstadual: string;
    public inscricaoMunicipal: string;
    public endereco: Endereco;

    constructor(emitente: Emitente) {
        this.nomeFantasia = emitente.nomeFantasia;
        this.razaoSocial = emitente.razaoSocial;
        this.cnpj = emitente.cnpj;
        this.inscricaoEstadual = emitente.inscricaoEstadual;
        this.inscricaoMunicipal = emitente.inscricaoMunicipal;
        this.endereco = emitente.endereco;
    }
}

export class EmitenteEditarComando {
    public id: number;
    public nomeFantasia: string;
    public razaoSocial: string;
    public cnpj: Documento;
    public inscricaoEstadual: string;
    public inscricaoMunicipal: string;
    public endereco: Endereco;

    constructor(emitente: Emitente) {
        this.id = emitente.id;
        this.nomeFantasia = emitente.nomeFantasia;
        this.razaoSocial = emitente.razaoSocial;
        this.cnpj = emitente.cnpj;
        this.inscricaoEstadual = emitente.inscricaoEstadual;
        this.inscricaoMunicipal = emitente.inscricaoMunicipal;
        this.endereco = emitente.endereco;
    }
}
