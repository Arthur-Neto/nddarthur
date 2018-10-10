import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Injectable, ElementRef } from '@angular/core';
import { ActivatedRoute, Router, PRIMARY_OUTLET, UrlSegment, NavigationEnd } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { INDDBreadcrumbOptions, INDDBreadcrumb, INDDBreadcrumbMetadata } from './ndd-ng-breadcrumb.model';
import { NDDBreadcrumbSizes, NDDBreadcrumbSelectors } from './ndd-ng-breadcrumb.enum';
import { NDDBreadcrumbStore } from './ndd-ng-breadcrumb-store.service';

/**
 * Serviço de gerenciamento de rotas para o ndd-ng-breadcrumb
 *
 */
@Injectable()
export class NDDBreadcrumbService {
    public onModelChange: Observable<INDDBreadcrumb[]>;
    private eventSubject: BehaviorSubject<INDDBreadcrumb[]> = new BehaviorSubject<INDDBreadcrumb[]>([]);

    constructor(private activatedRoute: ActivatedRoute, private router: Router, private store: NDDBreadcrumbStore) {
        this.onModelChange = this.eventSubject
            .map(() => this.getDataTree(this.activatedRoute.root))
            .do((model: INDDBreadcrumb[]) => this.store.setBreadcrumbModel(model))
            .map((model: INDDBreadcrumb[]) => this.mergeMetadata(model));
        // Veja mais em https://toddmotto.com/dynamic-page-titles-angular-2-router-events
        this.router.events
            .filter((event: any) => event instanceof NavigationEnd)
            .subscribe(() => this.eventSubject.next([]));
    }

    /**
    * Método para ler a árvore de roteamento e obter o modelo de breadcrumb.
    *
    * Observações importantes:
    *
    * obs1: Para ler as rotas, usamos o this.activatedRoute.root, pois é necessário ler desde a raiz até a ultima rota ativa
    * o @angular/router não atualiza automaticamente o objeto activatedRoute, que é injetado, quando muda de rota.
    * Ele apenas adiciona um filho (children) nele. Assim, é necessário ler toda a hierarquia para garantir que temos os dados
    * atualizados.
    *
    * obs2: Como é esperado que se possa usar a herença de parâmetros/dados/resolve, definida em
    * RouterModule pelo atributo paramsInheritanceStrategy: 'always', precisamos criar caches que armazenam os dados lidos
    * para garantir que não se repitam. Isso é percebido em this.getDataTree().
    *
    */
    public getDataTree(route: ActivatedRoute): INDDBreadcrumb[] {
        // Cache de dados usados (data) para comparar e garantir que não tem igual
        const usedDataCache: INDDBreadcrumbOptions[] = [];
        // Cache que monta a url completa da rota atual
        let urlCache: string = '/';
        // Modelo que será montado e exibido pelo breadcrumb
        const model: INDDBreadcrumb[] = [];
        // E dessa raiz, iteramos até a rota atual para montar o caminho
        while (route) {
            if (route.outlet !== PRIMARY_OUTLET) {
                route = route.firstChild;
                continue;
            }
            // Obtém os dados da rota que estamos iterando
            const data: INDDBreadcrumbOptions = route.snapshot.data[NDDBreadcrumbSelectors.options_selector];
            // Atualiza a url
            if (route.snapshot.url.length > 0) {
                urlCache += route.snapshot.url
                    .map((segment: UrlSegment) => segment.path)
                    .join('') + '/';
            }
            // Se a propriedade "data" dela não está no cache, precisamos adicionar no modelo (novos dados)
            if (data && usedDataCache.indexOf(data) < 0) {
                // Adiciona no cache para garantir que não vai ter outro igual
                usedDataCache.push(data);
                // Atualiza o modelo
                model.push(this.getBreadcrumbModel(data, urlCache));
            }
            // Vai para a proxima rota
            route = route.firstChild;
        }

        return model;
    }

    public setMetadata(metadata: INDDBreadcrumbMetadata): void {
        this.store.addMetadata(metadata);
        this.eventSubject.next([]);
    }

    /**
     * Método que transforma uma opção em modelo de breadcrumb
     *
     * @param data é a opção que configura o breadcrumb
     * @param url é a rota de direcionamento do breadcrumb do breadcrumb quando clicado
     */
    private getBreadcrumbModel(data: INDDBreadcrumbOptions, url: string): INDDBreadcrumb {
        return {
            id: data.breadcrumbId,
            label: data.breadcrumbLabel,
            url,
            sizeLimit: data.breadcrumbSizeLimit,
        };
    }

    private mergeMetadata(model: INDDBreadcrumb[]): INDDBreadcrumb[] {
        const metadata: INDDBreadcrumbMetadata[] = this.store.getAllMetadata();
        metadata.forEach((data: INDDBreadcrumbMetadata) => {
            let isInTree: boolean = false;
            for (const actualModel of model) {
                if (actualModel.id === data.id) {
                    actualModel.label = data.label;
                    actualModel.sizeLimit = data.sizeLimit;
                    isInTree = true;
                    break;
                }
            }
            if (!isInTree) {
                this.store.removeMetadata(data);
            }
        });

        return model;
    }
}

/**
 *
 * Serviço de gerenciamento do DOM par ao ndd-ng-breadcrumb
 *
 */
@Injectable()
export class NDDBreadcrumbDOMService {

    constructor(private breadcrumbStore: NDDBreadcrumbStore) {
    }

    /**
     * Método para obter a quantidade de elementos que deve ser removido para o breadcrumb
     * ficar menor ou igual à 100% da largura do elemento pai.
     *
     * @param refContent  É o container do ndd-ng-breadcrumb
     * @param expectedWidth É a largura esperada que o refContent tenha, ou seja, a largura do elemento pai
     * @param actualWidth É a largura atual do container
     */
    public getNumberElementsToRemove(refContent: any): number {
        let total: number = 0;
        let expectedWidth: number = refContent.offsetWidth - NDDBreadcrumbSizes.options_menu_width;
        const breadcrumbsFixed: ElementRef[] = this.breadcrumbStore.getElementsFixed();
        const breadcrumbs: ElementRef[] = this.breadcrumbStore.getElements().reverse();
        for (const breadFix of breadcrumbsFixed) {
            const breadWidth: number = this.getWidth(breadFix.nativeElement);
            if ((expectedWidth - breadWidth) >= 0) {
                expectedWidth -= breadWidth;
            }
        }
        for (const breadcrumb of breadcrumbs) {
            const breadWidth: number = this.getWidth(breadcrumb.nativeElement);
            if ((expectedWidth - breadWidth) >= 0) {
                expectedWidth -= breadWidth;
                total++;
            } else {
                break;
            }
        }

        return breadcrumbs.length - total;
    }

    /**
     * Método para obter a largura real de uma elemento do breadcrumb.
     *
     * É necessário realizar essa função pois se houver uma quebra de linha de um dos pseudo-elementos
     * a largura do step "quebrado", em offsetWidth, será de 100%. Dessa forma, os cálculos para redimensionamento indicarão
     * errado o número de elementos para remover com o objetivo de redimensionar.
     * O uso de white-space:nowrap produz efeitos visuais indesejados.
     *
     */
    private getWidth(element: any): number {
        const link: any = element.querySelector('a');
        if (!link || !link.offsetWidth) return 0;
        let width: number = 0;
        width = link.offsetWidth + NDDBreadcrumbSizes.padding_left + NDDBreadcrumbSizes.border;
        if (element.classList.contains('ndd-ng-breadcrumb__item--with-arrow')) {
            width += NDDBreadcrumbSizes.padding_right;
        }

        return width;
    }
}
