import { Endereco } from 'src/app/features/endereco/shared/model/endereco.model';
import { Documento } from 'src/app/shared/models/documento/documento.model';

export class Transportador {
    public id?: number;
    public nomeRazaoSocial: string;
    public inscricaoEstadual?: string;
    public responsabilidadeFrete?: boolean;

    public endereco?: Endereco;
    public documento?: Documento;
}

export class TransportadorExcluirComando {
    public transportadorIds: number[];

    constructor(transportadores: Transportador[]) {
        this.transportadorIds = transportadores.map((p: Transportador) => p.id);
    }
}

export class TransportadorEditarComando {
    public id: number;
    public nomeRazaoSocial: string;
    public inscricaoEstadual: string;
    public responsabilidadeFrete: boolean;
    public endereco: Endereco;
    public documento: Documento;

    constructor(transportador: Transportador) {
        this.id = transportador.id;
        this.nomeRazaoSocial = transportador.nomeRazaoSocial;
        this.inscricaoEstadual = transportador.inscricaoEstadual;
        this.responsabilidadeFrete = transportador.responsabilidadeFrete;
        this.documento = transportador.documento;
        this.endereco = transportador.endereco;
    }
}

export class TransportadorAdicionarComando {
    public nomeRazaoSocial: string;
    public inscricaoEstadual: string;
    public responsabilidadeFrete: boolean;
    public endereco: Endereco;
    public documento: Documento;

    constructor(transportador: Transportador) {
        this.nomeRazaoSocial = transportador.nomeRazaoSocial;
        this.inscricaoEstadual = transportador.inscricaoEstadual;
        this.responsabilidadeFrete = transportador.responsabilidadeFrete;
        this.documento = transportador.documento;
        this.endereco = transportador.endereco;
    }
}
