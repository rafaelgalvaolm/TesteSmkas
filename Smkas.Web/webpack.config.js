const path = require('path');

module.exports = {
    mode: 'development',
    watch: false,
    devtool: 'source-map',
    entry: {
        site: './src/index.ts',
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            },
            {
                test: /\.css$/,
                use: ['style-loader', 'css-loader'],
            },
            {
                test: /\.(eot|woff(2)?|ttf|otf|svg)$/i,
                type: 'asset'
            },
            {
                test: /\.less$/i,
                use: [
                    "style-loader",
                    "css-loader",
                    "less-loader",
                ]
            },
            {
                test: /\.ico$/,
                use: 'file-loader?name=[name].[ext]'
            }
        ]
    },
    resolve: {
        extensions: ['.ts', '.js', '.css'],
        alias: {
            'font-awesome-css': 'font-awesome/css/font-awesome.css',
            'jquery-ui-css': 'jquery-ui-dist/jquery-ui.min.css',
            'uikit-css': 'uikit/dist/css/uikit.css',
            'less': '../../styles/index.less',
            'jquery-ui': 'jquery-ui-dist/jquery-ui',
            '@assets': path.resolve(__dirname, 'src/assets')
        }
    },
    output: {
        filename: '[name].entry.js',
        path: path.resolve(__dirname, 'wwwroot', 'dist'),
        library: ['smkas', '[name]'],
    }
};
