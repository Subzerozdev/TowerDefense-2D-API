# ==========================
# Stage 1: Build
# ==========================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy file .csproj để restore riêng (tận dụng cache)
COPY TowerDefense-2D-API/TowerDefense-2D-API.csproj TowerDefense-2D-API/
RUN dotnet restore "TowerDefense-2D-API/TowerDefense-2D-API.csproj"

# Copy toàn bộ source vào container
COPY . .

# Build và publish ra thư mục /app
WORKDIR /src/TowerDefense-2D-API
RUN dotnet publish -c Release -o /app

# ==========================
# Stage 2: Run
# ==========================
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .

# Render cung cấp PORT qua biến môi trường -> ASP.NET phải lắng nghe đúng cổng này
ENV ASPNETCORE_URLS=http://+:${PORT}

# Expose PORT (Render tự inject biến này khi chạy)
EXPOSE ${PORT}

ENTRYPOINT ["dotnet", "TowerDefense-2D-API.dll"]
