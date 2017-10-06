iwr https://localhost:44395/swagger/v1/swagger.json -o swagger.json -UseDefaultCredential

autorest --input-file=swagger.json --csharp --output-folder=simplechat_api --namespace=SimpleChat.Api.Client