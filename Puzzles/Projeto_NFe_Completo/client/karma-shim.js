Error.stackTraceLimit = Infinity;

// ES6 + reflect-metadata
require('core-js/client/shim');
require('reflect-metadata');

// zone.js
require('zone.js/dist/zone');
require('zone.js/dist/long-stack-trace-zone');
require('zone.js/dist/proxy');
require('zone.js/dist/sync-test');
require('zone.js/dist/jasmine-patch');
require('zone.js/dist/async-test');
require('zone.js/dist/fake-async-test');

// rxjs
require('rxjs/add/observable/of');
require('rxjs/add/observable/throw');
require('rxjs/add/observable/empty');
require('rxjs/add/operator/takeUntil');
require('rxjs/add/operator/map');
require('rxjs/add/operator/catch');

// Carrega os arquivos de teste no contexto.
const context = require.context('./src', true, /\.spec\.ts$/);
context.keys().map(context);

// Inicialização TestBed.
const coreTesting = require('@angular/core/testing');
const browserTesting = require('@angular/platform-browser-dynamic/testing');

coreTesting.TestBed.initTestEnvironment(
    browserTesting.BrowserDynamicTestingModule,
    browserTesting.platformBrowserDynamicTesting()
);