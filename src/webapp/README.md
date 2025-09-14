# webapp

This is the (very basic) Front-end to the Camera Location API

## Recommended IDE Setup

[VSCode](https://code.visualstudio.com/) + [Volar](https://marketplace.visualstudio.com/items?itemName=Vue.volar) (and disable Vetur).

## Customize configuration

See [Vite Configuration Reference](https://vite.dev/config/).

## Project Setup

```sh
npm install
```

For authentication to work you need to setup a `.env` file with the following example properties:
```
VITE_AUTH0_DOMAIN=AUTH0-DOMAIN
VITE_AUTH0_CLIENT_ID=AUTH0-CLIENT-ID
VITE_AUTH0_CALLBACK_URL=http://localhost:5173/callback
VITE_API_SERVER_URL=http://localhost:5188
```

The above assumes you run this Vue app from the Dotnet WebAPI Project. Make the appropriate changes if not.

### Compile and Hot-Reload for Development

Output will be redirected to the wwwroot folder of the WebAPI for hosting.
Running
```sh
npm run watch
```
will allow you to run the WebAPI, host the Vue App and hot-reload any changes made to the Vue App.

### Compile and Minify for Production

Output will be directed to the wwwroot folder of the WebAPI for packaging.
```sh
npm run build
```

### Lint with [ESLint](https://eslint.org/)

```sh
npm run lint
```
