kubectl apply -f https://download.elastic.co/downloads/eck/1.0.0-beta1/all-in-one.yaml

kubectl get service melastic-es-http

PASSWORD=$(kubectl get secret melastic-es-elastic-user -o=jsonpath='{.data.elastic}' | base64 --decode)

curl -u "elastic:$PASSWORD" -k "https://localhost:9200"


kubectl get service melastic-kb-http


Use kubectl port-forward to access Kibana from your local workstation:

kubectl port-forward service/mkibana-kb-http 5601


https://github.com/elastic/cloud-on-k8s/tree/master/config/samples

kubectl apply -f https://download.elastic.co/downloads/eck/1.0.0-beta1/all-in-one.yaml