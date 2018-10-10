import { RowArgs, PagerSettings, SelectableSettings } from '@progress/kendo-angular-grid';
import { SortDescriptor, State } from '@progress/kendo-data-query';

export interface IGridUtilsSortCustom {
    field: string;
    sortByProperty: string;
}

export class GridUtilsComponent {
    public selectedRows: RowArgs[] = [];
    public customSortFields: IGridUtilsSortCustom[] = [];
    public state: State = {
        skip: 0,
        take: 50,
    };
    public pageableSettings: PagerSettings = {
        info: true,
        // tslint:disable-next-line:no-magic-numbers
        pageSizes: [10, 20, 50, 100],
        previousNext: true,
    };

    public selectableSettings: SelectableSettings = {
        checkboxOnly: false,
        mode: 'multiple',
    };

    protected getSelectedEntities(): any {
        return this.selectedRows.map((row: RowArgs) => row.dataItem);
    }

    protected updateSelectedRows(rows: RowArgs[], isSelected: boolean): any {
        rows.forEach((r: RowArgs) => {
            const indexArray: number = this.selectedRows.findIndex((value: any) => value.index === r.index);

            if (isSelected && indexArray < 0) {
                this.selectedRows.push(r);
            } else if (!isSelected && indexArray >= 0) {
                this.selectedRows.splice(indexArray, 1);
            }
        });
    }

    protected createFormattedState(): State {
        // Fazemos isso pora criar um novo objeto sem associação ao antigo
        // O novo estado não deve estar relacionado com o antigo
        // Por isso {...state} não é adequado nesse caso
        const newState: State = JSON.parse(JSON.stringify(this.state));
        if (this.state.sort) {
            this.customizeSort(newState.sort, this.customSortFields);
        }

        return newState;
    }

    protected customizeSort(sort: SortDescriptor[], customSort: IGridUtilsSortCustom[]): void {
        // Itera cada opção de sort procurando no array de colunas a config correspondente
        // Ou seja, obtém a config da coluna que foi clicada pelo usuário
        sort.map((sort: SortDescriptor) => {
            customSort.map((custom: IGridUtilsSortCustom) => {
                // Se houver uma propriedade customizada para ordenação
                // Substitui no array
                // Se não houver, será a propriedade field (que já está em sortOption.field)
                if (custom.field === sort.field) {
                    sort.field = custom.sortByProperty;
                }
            });
        });
    }
}
