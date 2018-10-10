export class Transportador {
    public id: number;
    public nomeRazaoSocial: string;
    public inscricaoEstadual: string;
    public responsabilidadeFrete: boolean;
}

export class TransportadorExcluirComando {
    public transportadorIds: number[];

    constructor(transportadores: Transportador[]) {
        this.transportadorIds = transportadores.map((p: Transportador) => p.id);
    }
}

export class TransportadorEditComando {
    public id: number;
    public nomeRazaoSocial: string;
    public inscricaoEstadual: string;
    public responsabilidadeFrete: boolean;

    constructor(transportador: Transportador) {
        this.id = transportador.id;
        this.nomeRazaoSocial = transportador.nomeRazaoSocial;
        this.inscricaoEstadual = transportador.inscricaoEstadual;
        this.responsabilidadeFrete = transportador.responsabilidadeFrete;
    }
}

export class TransportadorCriarComando {
    public nomeRazaoSocial: string;
    public inscricaoEstadual: string;
    public responsabilidadeFrete: boolean;

    constructor(transportador: Transportador) {
        this.nomeRazaoSocial = transportador.nomeRazaoSocial;
        this.inscricaoEstadual = transportador.inscricaoEstadual;
        this.responsabilidadeFrete = transportador.responsabilidadeFrete;
    }
}
