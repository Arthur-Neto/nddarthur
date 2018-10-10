function NDDConfigFormatterPlugin(options) {
    this.options = options;
}

NDDConfigFormatterPlugin.prototype.apply = function (compiler) {
    var self = this;
    var entry = this.options.entry;
    var fullFileName = entry + '.bundle.js';
    var keyConfigStart = this.options.keyConfigStart || '// ## Start Config File';
    var keyConfigEnd = this.options.keyConfigStart || '//## End Config File';

    validate();
    initialize();

    function validate() {
        if (!self.options.entry) {
            throw new Error('Webpack Clean Bootstrap: Defina o atributo \'entry\' nas configurações do NDDConfigFormatterPlugin');
        }
    }

    function initialize() {
        if (self.options.isDev) {
            return;
        }
        compiler.plugin('emit', function (compilation, callback) {
            for (var assetName in compilation.assets) {
                if (~assetName.indexOf(entry)) {
                    let content = getContent(compilation, assetName);
                    // Insert this list into the webpack build as a new file asset
                    compilation.assets[fullFileName] = {
                        source: function () {
                            return content;
                        },
                        size: function () {
                            return content.length;
                        }
                    };
                    // Dele old asset
                    delete compilation.assets[assetName];
                    delete compilation.assets[assetName + '.map'];
                    // update references in chuncks
                    updateChuncks(compilation);
                    break;
                }
            }

            callback();
        });
    }

    function updateChuncks(compilation) {
        for (var chunk in compilation.chunks) {
            let newChunkFilesList = [];
            compilation.chunks[chunk].files.forEach(file => {
                if (~file.indexOf('.map')) {
                    return;
                } else if (~file.indexOf(entry)) {
                    newChunkFilesList.push(fullFileName);
                } else {
                    newChunkFilesList.push(file);
                }
            });
            compilation.chunks[chunk].files = newChunkFilesList;
        }
    }

    function getContent(compilation, assetName) {
        let content = compilation.assets[assetName].source();
        let indexStart = content.indexOf(keyConfigStart);
        let indexEnd = content.indexOf(keyConfigEnd);
        return content.slice(indexStart, indexEnd + keyConfigEnd.length);
    }
};

module.exports = NDDConfigFormatterPlugin;