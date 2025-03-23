# codifico-sales

Pasos para configurar los proyectos

SQL Database
1. Tener una instancia de SQL
2. Abrir el SSMS y ejecutar el script sql-scripts/DBSetup.sql
3. Una vez completado ejecutar el script sql-scripts/view-procedure.sql

Web API .NET
1. Ejecutar el SalesDatePrediction.sln dentro de la carpeta SalesDatePrediction o abrir la carpeta SalesDatePrediction con Visual Studio con la opcion Abrir proyecto o solucion.
2. Modificar los datos de conexion al servidor de la base de datos en el archivo appsettings.json, revisar el nodo ConnectionStrings la propiedad SimpleStoreDb
3. Limpiar y compilar.

Angular WebApp
1. Asegurarse de que el Web API este ejecutandose.
2. Dentro de la carpeta de SalesWebApp ejecutar el comando npm install
3. Una vez terminado ejecutar el comando: ng serve

Grafico D3
1. En la carpeta d3 se encuentra un archivo index.html, abrirlo con navegador Chrome
2. Ingresar valores en el campo y pulsa el boton Update Data, para refrescar el componente y visualizar barras
