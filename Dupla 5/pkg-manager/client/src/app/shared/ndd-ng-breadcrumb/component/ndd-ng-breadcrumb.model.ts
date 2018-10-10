/**
 * Interface que indica as opção de configuração do breadcrumb pelas rotas
 */
export interface INDDBreadcrumbOptions {
    breadcrumbId?: string;
    breadcrumbLabel: string;
    breadcrumbSizeLimit: boolean;
    breadcrumbResolveProperty?: string,
}

/**
 * Interface que indica dados de configuração do breadcrumb
 */
export interface INDDBreadcrumbMetadata {
    id: string;
    label: string;
    sizeLimit: boolean;
}

/**
 * Interface que indica um elemento do modelo do breadcrumb
 */
export interface INDDBreadcrumb {
    id: string;
    label: string;
    url: string;
    sizeLimit: boolean;
}
