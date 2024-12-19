FROM node:20-alpine

# Ustawiamy katalog roboczy w kontenerze
WORKDIR /app

# Kopiujemy pliki package.json i package-lock.json
COPY package*.json ./

# Instalujemy zależności projektu
RUN npm install

# Kopiujemy pozostałe pliki projektu do katalogu roboczego
COPY . .

# Eksponujemy port 8080
EXPOSE 8080

# Uruchamiamy aplikację
CMD ["npm", "run", "dev"]
