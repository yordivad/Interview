
```nginx kibana```




server {  
  listen 443 ssl;
  
  ssl_certificate /etc/letsencrypt/live/kibana.mcode.ninja/fullchain.pem;
  ssl_certificate_key /etc/letsencrypt/live/kibana.mcode.ninja/privkey.pem;
  include /etc/letsencrypt/options-ssl-nginx.conf;
  ssl_dhparam /etc/letsencrypt/ssl-dhparams.pem;

  server_name kibana.mcode.ninja;

  location / {

    proxy_pass http://localhost:5601;
    proxy_http_version 1.1;
    proxy_set_header Upgrade $http_upgrade;
    proxy_set_header Connection 'upgrade';
    proxy_set_header Host $host;
    proxy_cache_bypass $http_upgrade;

  }

}

server {

  if ($host = kibana.mcode.ninja) {
    return 301 https://$host$request_uri;
  }

  listen 80;
  server_name kibana.mcode.ninja;
  return 404;
}


```

``` nginx elastic ```



server {

  listen 443 ssl; 
  ssl_certificate /etc/letsencrypt/live/elastic.mcode.ninja/fullchain.pem; 
  ssl_certificate_key /etc/letsencrypt/live/elastic.mcode.ninja/privkey.pem; 
  include /etc/letsencrypt/options-ssl-nginx.conf; 
  ssl_dhparam /etc/letsencrypt/ssl-dhparams.pem;
  server_name elastic.mcode.ninja;

  location / {
    proxy_set_header Host http://localhost:9200;
    proxy_http_version 1.1;
    proxy_set_header Upgrade $http_upgrade;
    proxy_set_header Connection 'upgrade';
    proxy_set_header Host $host;
    proxy_cache_bypass $http_upgrade;
  }

}

server {
  
    if ($host = elastic.mcode.ninja) {
        return 301 https://$host$request_uri;
    } 

    listen 80;
    server_name elastic.mcode.ninja;
    return 404;
}

````