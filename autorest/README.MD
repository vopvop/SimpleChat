# Autorest
API codegen from Swagger JSON file
## How to
1. Install Autorest via NPM:
```
npm install -g autorest
```
2. Download and save (as swagger.json, for example) Swagger JSON file;
3. Execute Autorest:
```
autorest --input-file=swagger.json --csharp --output-folder=simplechat_api --namespace=SimpleChat.Api.Client
```
## Useful links
https://github.com/Azure/autorest/blob/master/docs/generating-a-client.md
