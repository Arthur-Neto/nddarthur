import { NgModule, ModuleWithProviders, Optional, SkipSelf } from '@angular/core';
import { NDDTitlebarGlobalConfig } from './ndd-ng-titlebar-config.model';

@NgModule({
    imports: [],
    exports: [],
    declarations: [],
})
export class NDDTitlebarGlobalConfigModule  {

    /**
     *  Garante que o NDDTitlebarGlobalConfigModule  é um singleton.
     * @param parentModule - É o NDDTitlebarGlobalConfigModule  do injetor global.Caso não tenha é null.
     */
    constructor(@Optional() @SkipSelf() parentModule: NDDTitlebarGlobalConfigModule ) {
        if (parentModule) {
            throw new Error(
                'NDDTitlebarGlobalConfigModule  is already loaded. Import it in the CoreModule only');
        }
    }

    /**
     * Realiza configurações iniciais.
     * @param config - Configurações globais do NDDTitleBar
     */
    public static forRoot(config: NDDTitlebarGlobalConfig): ModuleWithProviders {
        return {
            ngModule: NDDTitlebarGlobalConfigModule ,
            providers: [
                { provide: NDDTitlebarGlobalConfig, useValue: config },
            ],
        };
    }
}
