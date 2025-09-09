# Product Management

## Cómo correr el proyecto

### Backend (.NET API)
1. Clona el repositorio: `git clone <repo-url>`.
2. Abre la solución `ProductManagement.sln` en Visual Studio.
3. Configura la cadena de conexión en `ProductManagement.API/appsettings.json`.
4. Ejecuta el script `create_products.sql` para crear la tabla `Products` y datos de prueba.
5. (Opcional) Usa migraciones:
   - `dotnet ef migrations add InitialCreate --project ProductManagement.Infrastructure --startup-project ProductManagement.API`
   - `dotnet ef database update --project ProductManagement.Infrastructure --startup-project ProductManagement.API`
6. Ejecuta el API: `dotnet run --project ProductManagement.API`.
   - Endpoints en `https://localhost:7035/api/products` (usa Swagger en `/swagger`).

### Frontend (Angular)
1. Navega a la carpeta `ProductManagement.Frontend`.
2. Instala dependencias: `npm install`.
3. Asegúrate de que el backend esté corriendo.
4. Configura la URL del API en `src/environments/environment.ts` (`https://localhost:7035/api`).
5. Ejecuta el frontend: `ng serve`.
   - Accede en `http://localhost:4200`.

### Base de Datos
- Usa `create_products.sql` para crear la tabla `Products` en SQL Server.

## Estructura del Proyecto
- **ProductManagement.Domain**: Entidades y contratos.
- **ProductManagement.Application**: Lógica de negocio, servicios y DTOs.
- **ProductManagement.Infrastructure**: Persistencia (Entity Framework Core).
- **ProductManagement.API**: API REST.
- **ProductManagement.Frontend**: Frontend Angular con componentes standalone.

## Endpoints
- `GET /api/products?page={page}&pageSize={pageSize}`: Lista productos con paginación.
- `GET /api/products/{id}`: Obtiene un producto.
- `POST /api/products`: Crea un producto.
- `PUT /api/products/{id}`: Actualiza un producto.
- `DELETE /api/products/{id}`: Elimina un producto.


@dslopez0618