# IngeneosTest
# Backend
Desarrollar Backend que cumpla con las siguientes condiciones:
  - Pueda ser ejecutado en Visual Studio 2019
  - Realice el consumo de la Api https://fakerestapi.azurewebsites.net/index.html 
  - Validar el consumo de los servicios con tokens JWT.

##### Alcance del Backend

  - Crear capa de datos que consumo informacion de una base de datos SQL Server
  - Crear capa logica de negocios para recuperar informacion de autores y libros.
  - Crear controlador que permita devolver informacion para multilpes autores y libros.
  - Crear funcionalidad que permita sincronizar la informacion de autores y libros.

# Frontend
  - Consumir los servicios del backend
  - Utilizar Prime NG o Bootstrap

##### Alcance del Frontend
  - Crear vista que permita realizar el consumo del servicio de sincronizacion. Mostrar modal que indique que el proceso ha finalizado.
  - Crear formulario de autenticacion de usuarios
  - Crear vista que permita consultar libros filtrados por autor y fecha de publicacion (fecha inicio y fin). Mostrar resultados sobre grid y permitir ordenar por cualquier columnas.
  - Permitir exportar la informacion de la grid a archivo excel.
