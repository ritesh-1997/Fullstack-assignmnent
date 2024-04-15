# FRONT END

cd angular
npm i
npm run start

cd backend
docker network create -d bridge my-network



docker build -t backend4 .
 1085  docker run -p 5152:80 -v ./mydatabase.db:/app/Data backend4