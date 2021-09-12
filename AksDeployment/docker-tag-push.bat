REM Login manually "docker login my-container-registry.azurecr.io"

docker image tag app001-nearby-places-viewer:0.0.1 my-container-registry.azurecr.io/dep/app001:0.0.1
docker image tag service001-nearby-places-viewer:0.0.1 my-container-registry.azurecr.io/dep/service001:0.0.1
docker image tag service002-proxy:0.0.1 my-container-registry.azurecr.io/dep/service002:0.0.1

docker image push my-container-registry.azurecr.io/dep/app001:0.0.1
docker image push my-container-registry.azurecr.io/dep/service001:0.0.1
docker image push my-container-registry.azurecr.io/dep/service002:0.0.1
