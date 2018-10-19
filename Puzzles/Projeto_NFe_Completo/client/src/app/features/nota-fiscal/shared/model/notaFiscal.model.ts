import { Transportador } from 'src/app/features/transportador/shared/model/transportador.model';
import { Destinatario } from 'src/app/features/destinatario/shared/model/destinatario.model';
import { Emitente } from 'src/app/features/emitente/shared/emitente.model';
import { Produto } from 'src/app/features/produto/shared/model/produto.model';

export class NotaFiscal {
    public id: number;
    public transportadorId: number;
    public transportador: Transportador;
    public destinatarioId: number;
    public destinatario: Destinatario;
    public emitenteId: number;
    public emitente: Emitente;
    public produtos: Produto[];
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
    public transportador: Transportador;
    public destinatario: Destinatario;
    public emitente: Emitente;
    public produtos: Produto[];
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
        this.produtos = notaFiscal.produtos;
    }
}

export class NotaFiscalAdicionarComando {
    public id: number;
    public transportadorId: number;
    public destinatarioId: number;
    public emitenteId: number;
    public produtos: Produto[];
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
        this.transportadorId = notaFiscal.transportadorId;
        this.destinatarioId = notaFiscal.destinatarioId;
        this.emitenteId = notaFiscal.emitenteId;
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
        this.produtos = notaFiscal.produtos;
    }
}
