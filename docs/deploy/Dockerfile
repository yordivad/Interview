FROM node:lts-alpine
RUN  npm install -g docsify-cli
COPY . /docs
EXPOSE 3000
CMD ["docsify", "serve", "docs"]
