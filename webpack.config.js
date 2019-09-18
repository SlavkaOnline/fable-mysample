var path = require("path");

module.exports = {
	mode: "development",
	entry: "./fable-mysample.fsproj",
	output: {
		path: path.join(__dirname, "./public"),
		filename: "bundle.js",
	},
	devServer: {
		contentBase: "./public",
		port: 8080,
	},
	module:{
		rules: [{
			test: /\.fs(x|proj)?$/,
			use: "fable-loader"
		},
		{
			test: /\.s?[ac]ss$/,
			use: [
			'style-loader',
			'css-loader',
			'sass-loader',
			]
		},
		{
			test: /\.css$/,
			use: ['style-loader', 'css-loader']
		},
		{
			test: /\.(png|jpg|jpeg|gif|svg|woff|woff2|ttf|eot)(\?.*$|$)/,
			use: ["file-loader"]
		}],
	},
	externals: {
		"React": "react",
		"ReactDOM": "react-dom",
	}
}
