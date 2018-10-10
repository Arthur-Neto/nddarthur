export class Destinatario {
    public id: number;
    public nomeRazaoSocial: string;
    public inscricaoEstadual: string;
}

export class DestinatarioExcluirComando {
    public destinatarioIds: number[];

    constructor(destinatarios: Destinatario[]) {
        this.destinatarioIds = destinatarios.map((p: Destinatario) => p.id);
    }
}

export class DestinatarioEditComando {
    public id: number;

    constructor(destinatario: Destinatario) {
        this.id = destinatario.id;
    }
}

export class DestinatarioCriarComando {
    public nomeRazaoSocial: string;

    constructor(destinatario: Destinatario) {
        this.nomeRazaoSocial = destinatario.nomeRazaoSocial;
    }
}
