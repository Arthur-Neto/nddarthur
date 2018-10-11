
export class NotaFiscal {
    public id: number;
    public transportador: string;
    public destinatario: string;
    public emitente: string;
    public naturezaOperacao: string;
    public dataEntrada: Date;
    public dataEmissao: Date;
    public chaveAcesso: string;
    public valorTotalIcms: number;
    public valorTotalIpi: number;
    public valorTotalProdutos: number;
    public valorTotalFrete: number;
    public valorTotalImposto: number;
    public valorTotalNota: number;
}

export class NotaFiscalExcluirComando {
    public notaFiscalIds: number[];

    constructor(notaFiscais: NotaFiscal[]) {
        this.notaFiscalIds = notaFiscais.map((p: NotaFiscal) => p.id);
    }
}

export class NotaFiscalEditComando {
    public id: number;
    public transportador: string;
    public destinatario: string;
    public emitente: string;
    public naturezaOperacao: string;
    public dataEntrada: Date;
    public dataEmissao: Date;
    public chaveAcesso: string;
    public valorTotalIcms: number;
    public valorTotalIpi: number;
    public valorTotalProdutos: number;
    public valorTotalFrete: number;
    public valorTotalImposto: number;
    public valorTotalNota: number;

    constructor(notaFiscal: NotaFiscal) {
        this.id = notaFiscal.id;
        this.transportador = notaFiscal.transportador;
        this.destinatario = notaFiscal.destinatario;
        this.emitente = notaFiscal.emitente;
        this.naturezaOperacao = notaFiscal.naturezaOperacao;
        this.dataEntrada = notaFiscal.dataEntrada;
        this.dataEmissao = notaFiscal.dataEmissao;
        this.chaveAcesso = notaFiscal.chaveAcesso;
        this.valorTotalIcms = notaFiscal.valorTotalIcms;
        this.valorTotalIpi = notaFiscal.valorTotalIpi;
        this.valorTotalProdutos = notaFiscal.valorTotalProdutos;
        this.valorTotalFrete = notaFiscal.valorTotalFrete;
        this.valorTotalImposto = notaFiscal.valorTotalImposto;
        this.valorTotalNota = notaFiscal.valorTotalNota;
    }
}

export class NotaFiscalCriarComando {
    public codigo: string;
    public transportador: string;
    public destinatario: string;
    public emitente: string;
    public naturezaOperacao: string;
    public dataEntrada: Date;
    public dataEmissao: Date;
    public chaveAcesso: string;
    public valorTotalIcms: number;
    public valorTotalIpi: number;
    public valorTotalProdutos: number;
    public valorTotalFrete: number;
    public valorTotalImposto: number;
    public valorTotalNota: number;

    constructor(notaFiscal: NotaFiscal) {
        this.transportador = notaFiscal.transportador;
        this.destinatario = notaFiscal.destinatario;
        this.emitente = notaFiscal.emitente;
        this.naturezaOperacao = notaFiscal.naturezaOperacao;
        this.dataEntrada = notaFiscal.dataEntrada;
        this.dataEmissao = notaFiscal.dataEmissao;
        this.chaveAcesso = notaFiscal.chaveAcesso;
        this.valorTotalIcms = notaFiscal.valorTotalIcms;
        this.valorTotalIpi = notaFiscal.valorTotalIpi;
        this.valorTotalProdutos = notaFiscal.valorTotalProdutos;
        this.valorTotalFrete = notaFiscal.valorTotalFrete;
        this.valorTotalImposto = notaFiscal.valorTotalImposto;
        this.valorTotalNota = notaFiscal.valorTotalNota;
    }
}
