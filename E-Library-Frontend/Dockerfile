# Build
FROM node:10-alpine as build-step
RUN mkdir -p /app

WORKDIR /app

COPY package.json /app

RUN npm install

COPY . /app

RUN npm run build --prod

# Start

FROM nginx:1.19.4-alpine

COPY --from=build-step /app/dist/e-library-frontend /usr/share/nginx/html