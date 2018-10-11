export class Destinatario {
    public id: number;
    public nomeRazaoSocial: string;
    public inscricaoEstadual: string;

    public enderedoLogradouro: string;
    public enderecoNumero: number;
    public enderecoBairro: string;
    public enderecoMunicipio: string;
    public enderecoEstado: string;
    public enderecoPais: string;

    public documentoNumero: number;
    public documentoTipo: string;
}

export class DestinatarioExcluirComando {
    public destinatarioIds: number[];

    constructor(destinatarios: Destinatario[]) {
        this.destinatarioIds = destinatarios.map((p: Destinatario) => p.id);
    }
}

export class DestinatarioEditComando {
    public id: number;
    public nomeRazaoSocial: string;
    public inscricaoEstadual: string;

    public enderedoLogradouro: string;
    public enderecoNumero: number;
    public enderecoBairro: string;
    public enderecoMunicipio: string;
    public enderecoEstado: string;
    public enderecoPais: string;

    public documentoNumero: number;
    public documentoTipo: string;

    constructor(destinatario: Destinatario) {
        this.id = destinatario.id;
        this.nomeRazaoSocial = destinatario.nomeRazaoSocial;
        this.inscricaoEstadual = destinatario.inscricaoEstadual;
        this.enderecoBairro = destinatario.enderecoBairro;
        this.enderecoEstado = destinatario.enderecoEstado;
        this.enderecoMunicipio = destinatario.enderecoMunicipio;
        this.enderecoNumero = destinatario.enderecoNumero;
        this.enderecoPais = destinatario.enderecoPais;
        this.enderedoLogradouro = destinatario.enderedoLogradouro;
        this.documentoNumero = destinatario.documentoNumero;
        this.documentoTipo = destinatario.documentoTipo;
    }
}

export class DestinatarioCriarComando {
    public nomeRazaoSocial: string;
    public inscricaoEstadual: string;

    public enderedoLogradouro: string;
    public enderecoNumero: number;
    public enderecoBairro: string;
    public enderecoMunicipio: string;
    public enderecoEstado: string;
    public enderecoPais: string;

    public documentoNumero: number;
    public documentoTipo: string;

    constructor(destinatario: Destinatario) {
        this.nomeRazaoSocial = destinatario.nomeRazaoSocial;
        this.inscricaoEstadual = destinatario.inscricaoEstadual;
        this.enderecoBairro = destinatario.enderecoBairro;
        this.enderecoEstado = destinatario.enderecoEstado;
        this.enderecoMunicipio = destinatario.enderecoMunicipio;
        this.enderecoNumero = destinatario.enderecoNumero;
        this.enderecoPais = destinatario.enderecoPais;
        this.enderedoLogradouro = destinatario.enderedoLogradouro;
        this.documentoNumero = destinatario.documentoNumero;
        this.documentoTipo = destinatario.documentoTipo;
    }
}
