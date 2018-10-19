import { Endereco } from 'src/app/features/endereco/shared/model/endereco.model';
import { Documento } from 'src/app/shared/models/documento/documento.model';

export class Destinatario {
    public id?: number;
    public nomeRazaoSocial: string;
    public inscricaoEstadual?: string;

    public endereco?: Endereco;

    public documento?: Documento;
}

export class DestinatarioExcluirComando {
    public destinatarioIds: number[];

    constructor(destinatarios: Destinatario[]) {
        this.destinatarioIds = destinatarios.map((p: Destinatario) => p.id);
    }
}

export class DestinatarioEditarComando {
    public id: number;
    public nomeRazaoSocial: string;
    public inscricaoEstadual: string;

    public endereco: Endereco;

    public documento: Documento;

    constructor(destinatario: Destinatario) {
        this.id = destinatario.id;
        this.nomeRazaoSocial = destinatario.nomeRazaoSocial;
        this.inscricaoEstadual = destinatario.inscricaoEstadual;
        this.endereco = destinatario.endereco;
        this.documento = destinatario.documento;
    }
}

export class DestinatarioAdicionarComando {
    public nomeRazaoSocial: string;
    public inscricaoEstadual: string;

    public endereco: Endereco;

    public documento: Documento;

    constructor(destinatario: Destinatario) {
        this.nomeRazaoSocial = destinatario.nomeRazaoSocial;
        this.inscricaoEstadual = destinatario.inscricaoEstadual;
        this.endereco = destinatario.endereco;
        this.documento = destinatario.documento;
    }
}
