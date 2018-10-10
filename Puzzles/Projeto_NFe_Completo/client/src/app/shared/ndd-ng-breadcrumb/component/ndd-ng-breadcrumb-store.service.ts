import { ElementRef, Injectable } from '@angular/core';
import { INDDBreadcrumb, INDDBreadcrumbMetadata } from './ndd-ng-breadcrumb.model';

/**
 * Serviço de armazenamento de elementos do ndd-ng-breadcrumb
 */
@Injectable()
export class NDDBreadcrumbStore {
    private breadcrumbs: INDDBreadcrumb[] = [];
    private breadcrumbsMetaData: INDDBreadcrumbMetadata[] = [];
    private breadcrumbsElements: ElementRef[] = [];
    private breadcrumbsFixed: ElementRef[] = [];

    /**
     * Método para adicionar um elemento na store
     *
     * @param element é a referência do elemento DOM do breadcrumb
     * @param isFixed  Indica,quando verdadeiro, que um elemento é o titulo/menu do breadcrumb
     */
    public add(element: ElementRef, isFixed: boolean = false): void {
        const store: ElementRef[] = isFixed ? this.breadcrumbsFixed : this.breadcrumbsElements;
        const index: number = store.indexOf(element);
        if (index > 0) return;
        store.push(element);
    }

    /**
     * Método para adicionar metadata na store
     *
     * @param metadata são os dados que serão substituidos no breadcrumb depois de carregado (async)
     */
    public addMetadata(metadata: INDDBreadcrumbMetadata): void {
        for (let i: number = 0; i < this.breadcrumbsMetaData.length; i++) {
            const storedMetadata: INDDBreadcrumbMetadata = this.breadcrumbsMetaData[i];
            if (storedMetadata.id === metadata.id) {
                this.breadcrumbsMetaData[i] = metadata;

                return;
            }
        }
        this.breadcrumbsMetaData.push(metadata);
    }

    /**
     * Método para limpar todas as referências do breadcrumb
     * @param isFixed indica, quando verdadeiro, que os titulos/menus armazenados devem ser apagados.
     */
    public clean(isFixed: boolean = false): void {
        if (isFixed) {
            this.breadcrumbsFixed = [];
        } else {
            this.breadcrumbsElements = [];
        }
    }

    /**
     * Método para definir uma lista de modelo de breadcrumb
     *
     * @param breadcrumbs  é um array de INDDBreadcrumb[] que representa o estado atual do breadcrumb
     *
     */
    public setBreadcrumbModel(breadcrumbs: INDDBreadcrumb[]): void {
        this.breadcrumbs = breadcrumbs;
    }

    /**
     * Método para remover um elemento na store
     *
     * @param element é a referência do elemento DOM do breadcrumb
     * @param isFixed  Indica,quando verdadeiro, que um elemento é o titulo/menu do breadcrumb
     */
    public remove(element: ElementRef, isFixed: boolean = false): void {
        const store: ElementRef[] = isFixed ? this.breadcrumbsFixed : this.breadcrumbsElements;
        const index: number = store.indexOf(element);
        if (index < 0) return;
        store.splice(index, 1);
    }

    /**
     * Método para remover um elemento na store
     *
     * @param element é a referência do elemento DOM do breadcrumb
     * @param isFixed  Indica,quando verdadeiro, que um elemento é o titulo/menu do breadcrumb
     */
    public removeMetadata(metadata: INDDBreadcrumbMetadata): void {
        let index: number = -1;
        const totalElements: number = this.breadcrumbsMetaData.length;
        for (let i: number = 0; i < totalElements; i++) {
            if (this.breadcrumbsMetaData[i].id === metadata.id) {
                index = i;
                break;
            }
        }
        if (index >= 0) {
            this.breadcrumbsMetaData.splice(index, 1);
        }
    }

    /**
     * Método para obter todas as referências dos elementos do breadcrumb.
     *
     * Segue a ordenação: do titulo, menu e depois elementos.
     */
    public getAllElements(): ElementRef[] {
        return this.breadcrumbsFixed.concat(this.breadcrumbsElements);
    }

    /**
     * Método para obter todos os modelos de breadcumb
     *
     */
    public getAllModels(): INDDBreadcrumb[] {
        // Retorna um novo array para ser manipulado, apontando para os mesmos objetos
        // Útil para reorganizar o breadcrumb
        return this.breadcrumbs.slice(0);
    }

    /**
     * Método para obter todos os modelos de breadcumb com novas referências de objetos
     *
     */
    public getAllModelsWithNewRef(): INDDBreadcrumb[] {
        // Precisamos gerar novos objetos para o angular refazer o breadcrumb
        // Se manter a mesma referência, ele identifica que não há mudanças e não refaz
        // Isso apenas no resize do window é necessário (queremos renderizar tudo novamente)
        return this.breadcrumbs.map((e: any) => {
            return { ...e };
        });
    }

    /**
     * Método para obter todos os meta-dados de breadcrumb
     *
     */
    public getAllMetadata(): INDDBreadcrumbMetadata[] {
        return this.breadcrumbsMetaData.slice(0);
    }

    /**
     * Método para obter apenas os elementos do breadcrumb sem os títulos e menus.
     */
    public getElements(): ElementRef[] {
        return this.breadcrumbsElements;
    }

    /**
   * Método para obter apenas os elementos de títulos e menus do breadcrumb.
   */
    public getElementsFixed(): ElementRef[] {
        return this.breadcrumbsFixed;
    }
}
