// Privadas
const NDDConfigFormatterPlugin = require('./src/utils/ndd-config-formatter-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const ExtractTextWebpackPlugin = require('extract-text-webpack-plugin');
const ForkTsCheckerWebpackPlugin = require('fork-ts-checker-webpack-plugin');
const HappyPack = require('happypack');
const HardSourceWebpackPlugin = require('hard-source-webpack-plugin');
const UglifyJSPlugin = require('uglifyjs-webpack-plugin');
const webpack = require('webpack');
const path = require('path');
const srcPath = path.resolve(__dirname, 'src')
const appPath = path.resolve(srcPath, 'app');
const publicPathName = 'assets/';
let isDevBuild;
let isDevRemoteBuild;
let isTestBuild;
let isPR;

// Globais
const DEV_METADATA = {
    // atributos para debug local
    API_URL_LOCAL: 'http://localhost:9005/',
    API_URL_AUTH: 'http://localhost:9001/',
     // build interno no formato de desenvolvimento
    API_URL_REMOTE: 'http://nddresearch-seed/api/',
    API_URL_AUTH_REMOTE: 'http://nddresearch-seed/auth/',
     // path dos arquivos do build de dev
    ASSETS_PATH: '',
     // ambiente (flag)
    ENV: 'development'
};

const PROD_METADATA = {
    // atributos para configurar o endpoint da api de produção
    API_URL: 'http://nddresearch-seed/api/',
    API_URL_AUTH: 'http://nddresearch-seed/auth/',
    // build interno no mesmo formato de produção
    API_URL_REMOTE: 'http://nddresearch-seed/api/',
    API_URL_AUTH_REMOTE: 'http://nddresearch-seed/auth/',
    // path dos arquivos do build de produção
    ASSETS_PATH: publicPathName,
    // ambiente (flag)
    ENV: 'production'
};

/* Métodos */
const getResolve = () => {
    const resolve = {
        alias: {
            core: path.join(appPath, 'core'),
            commons: path.join(appPath, 'commons'),
            shared: path.join(appPath, 'shared'),
            testing: path.join(srcPath, 'testing')
        },
        extensions: ['.ts', '.js']
    };

    return resolve;
}

const getPlugins = () => {
    const optionsHtmlWebpackPlugin = {
        inject: false,
        template: 'index.ejs',
        baseHref: '/',
        assetsPath: isDevBuild ? DEV_METADATA.ASSETS_PATH : PROD_METADATA.ASSETS_PATH,
        defaultCssTheme: isDevBuild ? DEV_METADATA.ASSETS_PATH : PROD_METADATA.ASSETS_PATH + 'default.css',
        title: 'Pkg Manager'
    };

    if (!isDevBuild) {
        optionsHtmlWebpackPlugin.filename = '../index.html'
    }

    const plugins = [
        new ForkTsCheckerWebpackPlugin({
            tsconfig: path.resolve("tsconfig.json"),
            tslint: path.resolve("tslint.json"),
            checkSyntacticErrors: true
        }),
        new HappyPack({
            id: 'ts',
            threads: 2,
            loaders: [{
                    path: 'ts-loader',
                    query: {
                        happyPackMode: true,
                        transpileOnly: true
                    }
                },
                {
                    loader: 'angular-router-loader',
                    options: {
                        debug: false,
                    }
                },
                'angular2-template-loader'
            ]
        }),
        new HappyPack({
            id: 'html',
            threads: 2,
            loaders: ['html-loader']
        }),
        new NDDConfigFormatterPlugin({
            entry: 'config',
            isDev: isDevBuild,
        }),
        new HtmlWebpackPlugin(optionsHtmlWebpackPlugin),
        new ExtractTextWebpackPlugin({
            filename: 'default.css',
            disable: isDevBuild
        }),
        new CopyWebpackPlugin(
            [{
                from: 'favicon.ico',
                to: isDevBuild ? './' : '../',
                copyUnmodified: true
            }]
        ),
        new webpack.ContextReplacementPlugin(
            /\@angular(\\|\/)core(\\|\/)esm5/,
            __dirname
        ),
        new webpack.DefinePlugin({
            // Url para o servidor
            API_URL: JSON.stringify(isDevRemoteBuild ? DEV_METADATA.API_URL_REMOTE :
                isDevBuild ? DEV_METADATA.API_URL_LOCAL :
                PROD_METADATA.API_URL),
            // Url para o ser
            API_URL_AUTH: JSON.stringify(isDevRemoteBuild ? DEV_METADATA.API_URL_AUTH_REMOTE :
                isDevBuild ? DEV_METADATA.API_URL_AUTH :
                PROD_METADATA.API_URL_AUTH),
            ENV: JSON.stringify(isDevBuild ? DEV_METADATA.ENV : PROD_METADATA.ENV),

        }),
        new webpack.LoaderOptionsPlugin({
            debug: isDevBuild || isDevRemoteBuild
        }),
    ];

    if (!isDevBuild) {
        plugins.push(new webpack.optimize.CommonsChunkPlugin({
            children: true,
            minChunks: 2
        }));
        plugins.push(new UglifyJSPlugin({
            sourceMap: false,
            parallel: true,
            exclude: /.*config.*/g
        }));
    }

    return plugins;
}

const getRules = () => {
    const rules = [{
            test: /\.html$/,
            use: ['happypack/loader?id=html']
        },
        {
            test: /\.ts$/,
            use: ['happypack/loader?id=ts']
        },
        {
            test: /\.font\.(js|json)$/,
            use: [
                'style-loader',
                'css-loader',
                'fontgen-loader'
            ]
        },
        {
            test: /\.css$/,
            use: ExtractTextWebpackPlugin.extract({
                fallback: 'style-loader',
                use: [{
                    loader: 'css-loader',
                    options: {
                        sourceMap: isDevBuild,
                        minimize: !isDevBuild
                    }
                }, ]
            })
        },
        {
            test: /\.scss$/,
            use: ExtractTextWebpackPlugin.extract({
                fallback: 'style-loader',
                use: [{
                        loader: 'css-loader',
                        options: {
                            sourceMap: isDevBuild,
                            minimize: !isDevBuild
                        }
                    },
                    'resolve-url-loader',
                    {
                        loader: 'sass-loader',
                        options: {
                            sourceMap: true,
                            includePaths: [path.join(appPath, 'shared/styles/')]
                        }
                    },
                    'import-glob-loader'
                ]
            })
        },
        {
            test: /\.(ttf|eot|svg|png|gif|jpg|jpeg|woff|woff2)(.*)$/,
            loader: 'url-loader',
            options: {
                limit: 1000
            }
        }
    ];

    return rules;
}

const getOutput = () => {
    const distPath = path.join(__dirname, 'dist');

    const output = {
        path: distPath,
        pathinfo: isDevBuild || isDevRemoteBuild,
        filename: '[name].[hash].bundle.js',
        chunkFilename: '[name].[chunkhash].chunk.js',
        publicPath: '/'
    };

    if (!isDevBuild) {
        output.publicPath = '/assets/';
        output.path = path.join(distPath, publicPathName);
    }

    return output;
}

/* Configurações webpack */

module.exports = (options) => {
    if (options) {
        isTestBuild = options.isTest;
        isDevBuild = options.isDev || options.isDevRemote || !!isTestBuild;
        isDevRemoteBuild = options.isDevRemote;
        isPR = options.isPR;
    }

    const config = {
        bail: !isDevBuild,
        context: srcPath,
        devServer: {
            contentBase: srcPath,
            historyApiFallback: isDevBuild || isDevRemoteBuild,
            noInfo: isDevBuild || isDevRemoteBuild,
            inline: isDevBuild || isDevRemoteBuild,
            port: 8081,
            stats: 'errors-only',
        },
        entry: {
            // Injeção dos bundles será feita conforme o algorirmo de ordenação
            config: './main-config.js',
            third: './vendor.ts',
            main: './main.ts'
        },
        module: {
            rules: getRules()
        },
        resolve: getResolve(),
        plugins: getPlugins(),
        watchOptions: {
            ignored: /node_modules/
        }
    };

    if (!isTestBuild) {
        config.devtool = isPR ? 'eval' : isDevBuild ? 'cheap-module-eval-source-map' : 'source-map';
        config.output = getOutput();
    } else {
        config.devtool = 'inline-source-map';
    }

    return config;
};
