export interface IKendoResource {
    [key: string]: string;
}

export class NDDI18nKendoTranslationGridServiceConfig {
    public static resources: IKendoResource = {
        noRecords: 'Nenhum registro encontrado.',
        pagerFirstPage: 'Ir para a primeira página',
        pagerPreviousPage: 'Ir para a página anterior',
        pagerNextPage: 'Ir para a próxima página',
        pagerLastPage: 'Ir para a última página',
        pagerPage: 'Página',
        pagerOf: 'de',
        pagerItems: 'itens',
        pagerItemsPerPage: 'itens por página',
    };
}

export class NDDI18nKendoTranslationTimePickerServiceConfig {
    public static resources: IKendoResource = {
        accept: 'Concluir',
        acceptLabel: 'Concluir',
        cancel: 'Cancelar',
        cancelLabel: 'Cancelar',
        now: 'ATUAL',
        nowLabel: 'Hora atual',
        toggle: 'Abrir/fechar relógio',
    };
}

export class NDDI18nKendoTranslationDatePickerServiceConfig {
    public static resources: IKendoResource = {
        today: 'HOJE',
        toggle: 'Abrir/fechar calendário',
    };
}
