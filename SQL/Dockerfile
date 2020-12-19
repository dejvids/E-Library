FROM mcr.microsoft.com/mssql/server:2019-CU8-ubuntu-16.04
 
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Test12345678
ENV MSSQL_PID=Developer
ENV MSSQL_TCP_PORT=1433 

COPY create_db.sql create.sql 
COPY test_data.sql data.sql

RUN (/opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" &&  /opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P Test12345678  -i create.sql

RUN (/opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" &&  /opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P Test12345678  -i data.sql