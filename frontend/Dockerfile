
# Build Stage for Angular
FROM node:latest AS build
WORKDIR /source
COPY . .
RUN npm install
RUN npm run build


# Serve Stage for Angular
FROM nginx:latest
COPY --from=build source/dist/frontend /usr/share/nginx/html



EXPOSE 80