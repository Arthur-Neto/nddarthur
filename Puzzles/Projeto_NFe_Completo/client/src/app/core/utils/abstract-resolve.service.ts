import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Injectable } from '@angular/core';
import { Params, ActivatedRoute, Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';

/**
 * Serviço abstrato para interação entre componentes dependentes da resolução de dados
 *
 * Esse serviço provê métodos para ler da rota o id da entidade e também notificar os outros componentes
 * para que atualizem seus dados conforme essa chamada .
 *
*/
@Injectable()
export abstract class AbstractResolveService<T> implements Resolve<boolean> {
    /**
     * Observable que é emitido quando um componente que resolveu uma parâmetro de rota deseja informar ao demais
     * para que eles atualizem seus dados conforme essa nova chamada
     */
    public onChanges: Observable<T>;

    /**
     * Propriedade que indica qual o parâmetro deve ser lido das rotas. Esse parâmetro será passado quando invocar
     * o loadEntity()
     */
    public paramsProperty: string = '';

    /**
     * Propriedade que indica se é para utilizar uma rota específica durante o resolveFromRoute().
     *
     * É necessário criar esse indicador pois durante o resolve(), a rota atual ainda não está na árvore de ActivatedRoute
     * Assim, o getUpdatedActivatedRoute() não vai identificá-la. Por isso, temos que compartilhar, quando necessário,
     * o ActivatedRouteSnapshot do resolve().
     */
    private routeResoving: ActivatedRouteSnapshot;

    /**
     * Propriedade que é a origem dos nossos eventos de mudança.
     *
     * Como é um BehaviorSubject, ele também serve como nossa store.
     *
     */
    private changeSource: BehaviorSubject<T> = new BehaviorSubject<T>(null);

    constructor(private router: Router) {
        // Apenas invoca o evento se o changeSource já foi resolvido
        this.onChanges = this.changeSource
            .filter((value: T) => value !== null)
            .map((value: T) => this.formatValue(value));
    }

    /**
    * Método que obtém a entidade que está  com o identificador na rota.
    *
    * Esse método vai ler o identificar da rota, invocar o loadEntity() específico da entidade
    * que está sendo resolvida para realizar a chamada http com o service e assim quando disparado o
    * subscribe() ele consegue provêr os dados da entidade que está na rota.
    *
    * ATENÇÃO: Esse método não emite o onChanges.Ele é útil apenas quando queremos resolver os dados sem emitir para os demais
    * componentes. Para emitir, veja o resolveFromRouteAndNotify()
    *
    * @returns Um observable que quando emitido o subscribe() possui os dados da
    * entidade que está com o identificador na rota
    */
    public resolveFromRoute(): Observable<T> {
        let params: Observable<Params> = null;
        if (this.routeResoving) {
            params = Observable.of(this.routeResoving.params);
            this.routeResoving = null;
        } else {
            params = this.getUpdatedActivatedRoute().params;
        }

        return params
            .map((params: Params) => params[this.paramsProperty])
            .switchMap((entityId: number) => this.loadEntity(entityId));
    }

    /**
     * Método que obtém a entidade que está  com o identificador na rota e NOTIFICA os demais componentes.
     *
     * Esse método vai obter os dados da entidade que está com o identificador nas rotas usando o resolveFromRoute() (veja mais nesse método)
     * Entretanto, será emitido o evento da propriedade onChanges com os dados carregados, notificando todos os componentes que
     * dependem desses dados. Assim, todos podem se atualizar com a mesma chamada http.
     *
     * @returns esse método é void. Para obter os dados, faça o subscribe na propriedade onChanges.
     */
    public resolveFromRouteAndNotify(): void {
        // Limpa o valor do BehaviorSubject
        this.changeSource.next(null);
        // Resolve o valor
        this.resolveFromRoute()
            .take(1)
            .subscribe((response: T) => {
                this.changeSource.next(response);
            });
    }

    /**
     * Método que será invocado quando a rota estiver sendo resolvida.
     *
     * Esse método é responsável por invocar o resolveFromRouteAndNotify(); durante a resolução da rota.
     * Ele não tem o problema de ser bloqueante pois ele sempre retorna um Observable<boolean> já resolvido.
     *
     * @param route é a rota atual que está sendo resolvida
     */
    public resolve(route: ActivatedRouteSnapshot): Observable<boolean> {
        this.routeResoving = route;
        this.resolveFromRouteAndNotify();

        return Observable.of(true); // Retornamos um observable já resolvido para não bloquear as rotas.
    }

    /**
     * Método que retorna qual a rota está ativa no momento da execução.
     *
     * A propriedade this.route que é injetada usando a classe ActivatedRoute, é a rota ativa no momento
     * da criação desse service. Entretanto, como estamos trabalhando com singletons, a rota ativa pode mudar
     * e a instancia injetada não será atualizada. Ao invés disso, apenas 1 propriedade dela vai apontar para a nova
     * rota atual. Sendo assim, é necessário verificar essa árvore para obter a rota atual e acesso aos parâmetros e afins.
     */
    protected getUpdatedActivatedRoute(): ActivatedRoute {
        if (!this.router.routerState.root.children.length) {
            return this.router.routerState.root;
        }
        let activatedRoute: ActivatedRoute = this.router.routerState.root.children.shift();
        while (activatedRoute.children.length > 0) {
            activatedRoute = activatedRoute.children.shift();
        }

        return activatedRoute;
    }

    /**
     * Método que carrega uma entidade que está com o identificador nas rotas.
     *
     * Esse método deve ser reescrito para acessar o service específico correspondente ao da entidade
     * e realizar o carregamento dos dados. Por funcionar com streams, também pode utilizar os operadores .do()
     * para fazer funções específicas de cada entidade, como mapeamento para o breadcrumb.
     */
    protected abstract loadEntity(entityId: number): Observable<T>;

    /**
     * Método que cria um novo objeto com base no value.
     *
     * Ele é usado para não criar vinculo de referência entre os subscribers de onChanges,
     * pois a alteração do objeto em um subscriber, quando instância única, causa mudanças inesperadas
     * no outro subscriber. Esse método resolve esse problema.
     *
     * @param value é o valor para ser formatado
     */
    private formatValue(value: T): T {
        // tslint:disable-next-line:prefer-object-spread
        value = value instanceof Array ? Object.assign([], value) : Object.assign({}, value);

        return value;
    }
}
