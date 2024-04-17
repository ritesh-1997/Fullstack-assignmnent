# FRONT END

cd angular
npm i
npm run start

# backend

cd backend
docker build -t backend .
docker run -p 5151:80 -v ./mydatabase.db:/app/Data backend
