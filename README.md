# NPO-ID Assignment
Everybody codes

# Camera Location API & CLI

Welkom bij Camera Location

In de uitwerking van de opdracht vind je de volgende zaken:

## CLI

Een krachtige command-line tool voor het zoeken naar een camera.
De Cli Solution file opent de projecten nodig voor de command-line tool.

De Cli maakt gebruik van de WebAPI voor het zoeken.
Het URL voor de Web API is in te stellen via een Environmnet variabele:
```shell
NPO_API_ENDPOINT
```

## WebApi

De WebAPI is het hart van de oplossing.
De Web Solution file opent de project voor de WebAPI.

Bij opstarten zal de WebAPI het bestand [camera_locations.csv](./NPO.WebApi.Data/camera_locations.csv) inladen naar een InMemory database voor gebruik.

Standaard luistert de WebAPI op http://localhost:5188

## WebApp

Er is een Vue JS webapp beschikbaar als onderdeel van de WebAPI. 
De build output van de Webapp is ingesteld om naar de `wwwroot` map van de WebApi te gaan. Op deze manier is de WebAPI en de front-end als één geheel te deployen.

Voor de WebApp is authenticatie ingeregeld via Auth0. Configuratie van Auth0 gaat via het aanmaken van een `.env` bestand in de map `webapp` met de volgende eigenschappen:

```
VITE_AUTH0_DOMAIN=
VITE_AUTH0_CLIENT_ID=
VITE_AUTH0_CALLBACK_URL=http://localhost:5173/#callback
VITE_API_SERVER_URL=http://localhost:5188/api
```

Voor het gebruik van authenticatie dient een Auth0 (gratis) te worden ingericht. Hierna kan het domein en de client ID worden ingevuld.

Lokaal opstarten met:
```shell
npm install
npm run dev
```
Hierna is de front-end te benaderen op http://localhost:5173


## En verder...



Helaas is de tijd erg kort en dat heeft zo zijn impact gehad:

- Authenticatie is enkel alleen in de Front-end geimplementeerd, waardoor de API gewoon te benaderen is.
- De front-end mist wat styling.
- De CLI werkt maar mist ook login functionaliteit voor gebruik met de API als daar authenticatie op staat.
- Unittests zijn niet volledig.
