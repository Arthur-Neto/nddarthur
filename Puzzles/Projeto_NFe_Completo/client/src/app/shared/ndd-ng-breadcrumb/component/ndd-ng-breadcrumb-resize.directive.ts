import { Output, Directive, ElementRef, EventEmitter, AfterViewInit, OnDestroy } from '@angular/core';

/**
 * Diretiva responsável for registrar o elemento DOM de breadcrumb
 * no componente pai, para efetuar os cáculos de redimensionamento.
 */
@Directive({
    selector: '[nddBreadcrumbResize]',
})
export class NDDBreadcrumbResizeDirective implements AfterViewInit, OnDestroy {
    @Output() public onEnterDOM: EventEmitter<ElementRef>;

    @Output() public onExitDOM: EventEmitter<ElementRef>;

    constructor(private el: ElementRef) {
        this.onEnterDOM = new EventEmitter<ElementRef>();
        this.onExitDOM = new EventEmitter<ElementRef>();
    }

    public ngAfterViewInit(): void {
        // Depois de a view ter sido exibida e os elementos resolvidos
        // Informa ao elemento pai da existencia desse elemento DOM
        // Importante relizar somente no ngAfterViewInit() pois precisar ter o elemento
        // Já resolvido, para calcular o redimensionamento
        this.onEnterDOM.emit(this.el);
    }

    public ngOnDestroy(): void {
        // Informa ao componente pai que esse elemento já não é mais exibido
        this.onExitDOM.emit(this.el);
    }
}
