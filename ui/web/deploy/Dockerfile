FROM node:lts-alpine as webbuilder

RUN mkdir   /app
COPY        . /app

WORKDIR     /app
RUN npm install -g @vue/cli
RUN npm install
RUN npm rebuild node-sass
RUN npm run build


FROM nginx:stable-alpine as web
COPY --from=webbuilder  /app/dist/ /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
