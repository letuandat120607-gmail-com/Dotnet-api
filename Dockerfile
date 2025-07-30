FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Sử dụng image chính thức của .NET SDK để build ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

# Cập nhật và cài đặt các gói cần thiết (nếu cần)
RUN apt-get update && apt-get install -y curl

# Thiết lập thư mục làm việc
WORKDIR /src

# Sao chép file csproj và khôi phục các phụ thuộc
COPY ["BusinessObject/BusinessObject.csproj", "BusinessObject/"]
COPY ["billx/billx.csproj", "billx/"]
COPY ["Services/Services.csproj", "Services/"]
COPY ["DataAccessObject/DataAccessObject.csproj", "DataAccessObject/"]

RUN dotnet restore "BusinessObject/BusinessObject.csproj"
RUN dotnet restore "billx/billx.csproj"
RUN dotnet restore "Services/Services.csproj"
RUN dotnet restore "DataAccessObject/DataAccessObject.csproj"

# Sao chép tất cả các file
COPY . .

# Build tất cả các project
WORKDIR "/src/BusinessObject"
RUN dotnet build "BusinessObject.csproj" -c Release -o /app/build

WORKDIR "/src/billx"
RUN dotnet build "billx.csproj" -c Release -o /app/build

WORKDIR "/src/Services"
RUN dotnet build "Services.csproj" -c Release -o /app/build

WORKDIR "/src/DataAccessObject"
RUN dotnet build "DataAccessObject.csproj" -c Release -o /app/build

# Giai đoạn chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "billx.dll"]
