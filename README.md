TestMillionAndUp

Requisitos Previos
.NET 6 SDK instalado en el servidor de despliegue.
SQL Server instalado en el servidor de despliegue.
Despliegue de la Base de Datos
Clonar este repositorio en el servidor de despliegue o copiar los archivos de la aplicación.

Crear una nueva base de datos en SQL Server. Puedes utilizar SQL Server Management Studio u otro cliente SQL para crearla.

Ejecutar el script SQL para crear las tablas necesarias en la base de datos. Puedes encontrar el script en Scripts/Script_DataBase.sql.

Actualizar la cadena de conexión en el archivo appsettings.json con la nueva cadena de conexión para la base de datos creada.

Despliegue de la Aplicación
Abrir una terminal o línea de comandos en el directorio raíz de la aplicación.

Ejecutar el siguiente comando para restaurar las dependencias de la aplicación:
dotnet restore

Ejecutar el siguiente comando para compilar la aplicación:
dotnet build

Ejecutar el siguiente comando para publicar la aplicación:
dotnet publish -c Release -o ./publish

Ir al directorio ./publish y ejecutar el siguiente comando para iniciar la aplicación:
dotnet NombreDeLaAplicacion.dll

La aplicación debería estar en funcionamiento en la dirección http://localhost:5000 o en el puerto especificado en el archivo appsettings.json.