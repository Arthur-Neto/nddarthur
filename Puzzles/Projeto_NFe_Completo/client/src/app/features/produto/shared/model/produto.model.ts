const valorAliquotaIPI: number = 0.1;
const valorAliquotaICMS: number = 0.04;

export class Produto {
    public id: number;
    public codigo: string;
    public valor: number;
    public descricao: string;
    public aliquotaIPI: number;
    public aliquotaICMS: number;
    public quantidade: number;

    constructor() {
        this.aliquotaICMS = valorAliquotaICMS;
        this.aliquotaIPI = valorAliquotaIPI;
    }
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
    public aliquotaIPI: number;
    public aliquotaICMS: number;
    public quantidade: number;

    constructor(produto: Produto) {
        this.id = produto.id;
        this.codigo = produto.codigo;
        this.valor = produto.valor;
        this.descricao = produto.descricao;
        this.aliquotaIPI = produto.aliquotaIPI;
        this.aliquotaICMS = produto.aliquotaICMS;
        this.quantidade = produto.quantidade;
    }
}

export class ProdutoCriarComando {
    public codigo: string;
    public valor: number;
    public descricao: string;
    public aliquotaIPI: number;
    public aliquotaICMS: number;
    public quantidade: number;

    constructor(produto: Produto) {
        this.codigo = produto.codigo;
        this.valor = produto.valor;
        this.descricao = produto.descricao;
        this.aliquotaIPI = produto.aliquotaIPI;
        this.aliquotaICMS = produto.aliquotaICMS;
        this.quantidade = produto.quantidade;
    }
}
