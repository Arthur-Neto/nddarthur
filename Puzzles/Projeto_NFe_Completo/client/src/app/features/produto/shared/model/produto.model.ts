export class Produto {
    public id: number;
    public codigo: string;
    public valor: number;
    public descricao: string;
    public aliquotaIpi: number;
    public aliquotaIcms: number;
}

export class ProdutoExcluirComando {
    public produtoIds: number[];

    constructor(produtos: Produto[]) {
        this.produtoIds = produtos.map((p: Produto) => p.id);
    }
}

export class ProdutoEditComando {
    public id: number;
    public codigo: string;
    public valor: number;
    public descricao: string;
    public aliquotaIpi: number;
    public aliquotaIcms: number;

    constructor(produto: Produto) {
        this.id = produto.id;
        this.codigo = produto.codigo;
        this.valor = produto.valor;
        this.descricao = produto.descricao;
        this.aliquotaIpi = produto.aliquotaIpi;
        this.aliquotaIcms = produto.aliquotaIcms;
    }
}

export class ProdutoCriarComando {
    public codigo: string;
    public valor: number;
    public descricao: string;
    public aliquotaIpi: number;
    public aliquotaIcms: number;

    constructor(produto: Produto) {
        this.codigo = produto.codigo;
        this.valor = produto.valor;
        this.descricao = produto.descricao;
        this.aliquotaIpi = produto.aliquotaIpi;
        this.aliquotaIcms = produto.aliquotaIcms;
    }
}
