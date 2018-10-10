const HtmlWebpackPlugin = require('html-webpack-plugin');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const ExtractTextWebpackPlugin = require('extract-text-webpack-plugin');
const ForkTsCheckerWebpackPlugin = require('fork-ts-checker-webpack-plugin');
const HappyPack = require('happypack');
const UglifyJSPlugin = require('uglifyjs-webpack-plugin');
const webpack = require('webpack');
const path = require('path');

/* Globais  */
const srcPath = path.resolve(__dirname, 'src')
const appPath = path.resolve(srcPath, 'app');
const publicPathName = 'assets/';
let isDevBuild = false;
debugger;
const DEV_METADATA = {
  // path dos arquivos do build de dev
  ASSETS_PATH: '',
  // ambiente (flag)
  ENV: 'development'
};
const PROD_METADATA = {
  // path dos arquivos do build de produção
  ASSETS_PATH: publicPathName,
  // ambiente (flag)
  ENV: 'production'
};


const getResolve = () => {
  const resolve = {
    alias: {
      core: path.join(appPath, 'core'),
      shared: path.join(appPath, 'shared'),
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
    title: 'Angular Pizza Creator',
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
    new webpack.LoaderOptionsPlugin({
      debug: isDevBuild
    }),
  ];
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
    pathinfo: isDevBuild,
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

const getOptimization = () => {
  const optimizationConfig = {
    splitChunks: {
      minChunks: 2
    },
    concatenateModules: true,
    minimizer: [new UglifyJSPlugin({
      sourceMap: false,
      parallel: true,
      exclude: /.*config.*/g
    })],
  };
  return isDevBuild ? {} : optimizationConfig;
}

/* Configurações webpack */

module.exports = (options) => {
  if (options) {
    isDevBuild = options.isDev;
  }

  const config = {
    bail: !isDevBuild,
    context: srcPath,
    mode: isDevBuild ? 'development' : 'production',
    devServer: {
      contentBase: srcPath,
      historyApiFallback: isDevBuild,
      noInfo: isDevBuild,
      inline: isDevBuild,
      port: 8081,
      stats: 'errors-only',
    },
    output: getOutput(),
    devtool: isDevBuild ? 'cheap-module-eval-source-map' : 'source-map',
    entry: {
      third: './vendor.ts',
      main: './main.ts'
    },
    module: {
      rules: getRules(),
    },
    resolve: getResolve(),
    plugins: getPlugins(),
    optimization: getOptimization(),
    watchOptions: {
      ignored: /node_modules/
    },
    performance: {
      hints: false,
    },
    stats: {
      warnings: false,
    }
  };
  return config;
};
