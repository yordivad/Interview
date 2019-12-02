# Makefile

DBC="$(shell printenv ConnectionStrings__default | tr -d \\n | base64 -w 0 )"
KEY="$(shell printenv AppSettings__secret | tr -d \\n | base64 -w 0)"
ELURL="$(shell printenv ELASTIC__URL | tr -d \\n | base64 -w 0)"
ELUSR="$(shell printenv ELASTIC__USER |  tr -d \\n | base64 -w 0)"
ELPWD="$(shell printenv ELASTIC__PASSWORD |  tr -d \\n | base64 -w 0)"
VERSION="$(shell dotnet gitversion /showvariable NuGetVersion)"

.PHONY: clean build test coverage migrate deploy


build:
ifeq ($(TRAVIS_PULL_REQUEST), false)
	@dotnet cake ./csharp/build.cake
else
	@dotnet cake ./csharp/build.cake --target=check
endif

# Building web
	yarn --cwd ui/web install
	yarn --cwd ui/web build
	yarn --cwd ui/web lint

# Building mobile
	yarn --cwd ui/mobile install
	yarn --cwd ui/mobile build
	yarn --cwd ui/mobile test

test:
	@dotnet cake ./csharp/build.cake --target=test

coverage:
	@./codecov  -t $(INTERVIEW_TOKEN)

migrate:
ifeq ($(TRAVIS_PULL_REQUEST), false)
	@dotnet cake ./csharp/build.cake --target=migrate
endif

deploy:
ifeq ($(TRAVIS_PULL_REQUEST), false)

	@dotnet cake ./csharp/build.cake --target=deploy

	@docker login -u roygi -p $(APIKEY) roygi-docker-mdocker.bintray.io

	[ -d $(HOME)/.kube ] || mkdir -p $(HOME)/.kube
	@cp ./k8s/template/config.yml $(HOME)/.kube/config
	@cp ./k8s/template/secret.yml ./k8s

	@sed -i "s|{{DB_CONNECTION}}|$(DBC)|g" ./k8s/secret.yml
	@sed -i "s|{{SECRET}}|$(KEY)|g" ./k8s/secret.yml
	@sed -i "s|{{ELASTIC_URL}}|$(ELURL)|g" ./k8s/secret.yml
	@sed -i "s|{{ELASTIC_USER}}|$(ELUSR)|g" ./k8s/secret.yml
	@sed -i "s|{{ELASTIC_PASSWORD}}|$(ELPWD)|g" ./k8s/secret.yml

	@sed -i "s|{{cluster}}|$(CLUSTER)|g" ${HOME}/.kube/config
	@sed -i "s|{{server}}|$(SERVER)|g" ${HOME}/.kube/config
	@sed -i "s|{{user}}|$(USER)|g" ${HOME}/.kube/config
	@sed -i "s|{{token}}|$(TOKEN)|g" ${HOME}/.kube/config
	@sed -i "s|{{certificate}}|$(CERTIFICATE)|g" ${HOME}/.kube/config

	@kubectl config use-context $(CLUSTER)

	[ -d .skaffold ] || mkdir .skaffold
	@skaffold build -f skaffold.k8s.yaml --file-output .skaffold/build-$(VERSION).json
	@skaffold deploy -f skaffold.k8s.yaml -a .skaffold/build-$(VERSION).json --status-check

endif