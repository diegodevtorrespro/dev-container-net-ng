# Base .NET 8
FROM mcr.microsoft.com/devcontainers/dotnet:8.0

USER root

# Instalar Node, Angular e PostgreSQL
RUN apt-get update && \
    apt-get install -y curl gnupg postgresql postgresql-contrib postgresql-client && \
    curl -fsSL https://deb.nodesource.com/setup_18.x | bash - && \
    apt-get install -y nodejs && \
    npm install -g @angular/cli@16 && \
    rm -rf /var/lib/apt/lists/*

# Inicializar PostgreSQL e configurar usuário/senha e banco
RUN service postgresql start && \
    sudo -u postgres psql -c "ALTER USER postgres WITH PASSWORD 'postgres';" && \
    sudo -u postgres psql -c "CREATE DATABASE pedidos_db OWNER postgres;" || echo "Database already exists"

# Expor portas
EXPOSE 5000 4200 5432

# HTTPS para .NET
RUN dotnet dev-certs https

# Ajuste do pg_hba.conf no runtime e start do PostgreSQL
CMD sed -i "s/peer/md5/g" /etc/postgresql/*/main/pg_hba.conf && \
    sed -i "s/ident/md5/g" /etc/postgresql/*/main/pg_hba.conf && \
    service postgresql start && \
    tail -f /dev/null
