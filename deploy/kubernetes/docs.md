aws ecr get-login

kubectl create secret docker-registry aws-ecr \
  --docker-server=SERVER \
  --docker-username=USER \
  --docker-password=PASSWORD \

# Secret configuration is in 64 encoding 
echo -n xxxx | base64
  

