# Use a lightweight Node.js image with version 20.12.2
FROM node:20.12.2-alpine AS builder

WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build
EXPOSE 4200
CMD ["npm", "start"]