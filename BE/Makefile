start:
	dotnet watch --launch-profile dev

build:
	dotnet build

test:
	dotnet test

docker:
	docker build -t server -f Dockerfile .

release:
	docker build --build-arg APP_VERSION=$(version) -t server -f Dockerfile .
	docker tag server groupcooked.azurecr.io/server:$(version)
	docker push groupcooked.azurecr.io/server:$(version)

new-migration:
	dotnet ef migrations add $(name) --verbose 

migration:
	dotnet ef database update

push-registries:
	docker tag server groupcooked.azurecr.io/server:$(version)
	docker push groupcooked.azurecr.io/server:$(version)

.PHONY: start build docker new-migration migration test release