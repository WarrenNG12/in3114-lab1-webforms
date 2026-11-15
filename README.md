# AcopioWeb – Laboratorio 1 (IN3114)

**Curso:** IN3114 Programación de Computadoras VI, III Cuatrimestre 226
**Estudiante:** [Warren Nieto Guadamuz
**Repositorio:** in3114-lab1-webforms

Aplicación web interna para la Asociación de Productores Agrícolas del Sur (APAS, organización ficticia). El personal de recepción registra las entregas de fruta de palma con datos validados, y la administración puede consultarlas todas.

## Tecnologías

- Visual Basic .NET
- ASP.NET Web Forms sobre .NET Framework 4.8.1
- ASP.NET Identity (autenticación y roles)
- Bootstrap 5.3.9 (instalado con NuGet)
- Git y GitHub

## Cómo ejecutar el proyecto

1. Clonar el repositorio y abrir la solución con Visual Studio.
2. Restaurar los paquetes NuGet si Visual Studio lo solicita.
3. Ejecutar con F5 (IIS Express).
4. Ingresar desde /Login.aspx con uno de los usuarios de prueba.

Los usuarios y roles se guardan en una base de datos local de Identity (LocalDB, archivo AcopioWeb.mdf dentro de App_Data). Esa base se crea sola la primera vez que se ejecuta la aplicación, por lo que el equipo necesita LocalDB, que normalmente viene con Visual Studio.

### Usuarios de prueba

Se crean automáticamente al iniciar la aplicación, si todavía no existen.

| Usuario (correo) | Rol | Contraseña inicial |
|---|---|---|
| admin@apas.local | Administrador | Acopio2026 |
| recepcion1@apas.local | Recepcion | Acopio2026 |
| recepcion2@apas.local | Recepcion | Acopio2026 |

## Estructura del proyecto

| Elemento | Qué hace |
|---|---|
| Models/Productor.vb | Catálogo fijo de productores |
| Models/Entrega.vb | Datos de una entrega |
| Models/CalculadoraPago.vb | Calcula el pago según peso y calidad |
| Models/AlmacenEntregas.vb | Almacena las entregas en memoria, compartido por todos los usuarios |
| Models/ContextoIdentity.vb | Conexión de Identity con su base de datos |
| Models/InicializadorIdentity.vb | Crea los roles y los usuarios de prueba |
| Startup.vb | Configura la autenticación con cookies |
| Global.asax.vb | Llama al inicializador de Identity al arrancar |
| Site.Master | Página maestra con Bootstrap, menú según el rol y cierre de sesión |
| Login.aspx | Inicio de sesión |
| Registrar.aspx | Registro de entregas (solo Recepcion) |
| Consultar.aspx | Consulta de entregas con GridView paginado (Recepcion y Administrador) |
| Web.config | Cadena de conexión y autorización por página |

## Reglas del negocio

- La boleta debe tener el formato B- seguido de seis dígitos y no puede repetirse.
- El peso neto es un número entero entre 100 y 30 000 kg.
- Pago = peso × precio por kilogramo.

| Calidad | Precio por kg |
|---|---|
| A | ₡95 |
| B | ₡80 |
| C | ₡60 |

- Cada entrega guarda el usuario que la registró.
- Las entregas se guardan solo en memoria, así que se pierden al detener la aplicación.

## Decisiones tomadas

- Identity se configuró desde cero para este laboratorio.
- Los usuarios y roles se guardan en la base de datos que usa Identity, y solo las entregas van en memoria
- En el catálogo de productores, el enunciado escribe el último código como P105 sin guion. Se usó P-105 para ser consistente con los otros cuatro.
- La autorización está declarada en Web.config (etiquetas location) y se verifica también en el código de cada página.

## Casos de prueba

| N.º | Acción | Resultado esperado |
|---|---|---|
| 1 | Sin ingresar, abrir la página de registro | Se redirige al inicio de sesión |
| 2 | Ingresar como recepcion1 con contraseña incorrecta | Mensaje genérico de error |
| 3 | Como recepcion1, registrar P-101, B-000123, 1500 kg, calidad A | Confirmación con pago de ₡142 500 |
| 4 | Registrar otra vez la boleta B-000123 | Se rechaza por boleta repetida |
| 5 | Registrar sin productor, boleta 123, 50 kg y sin calidad | Se muestran los cuatro errores |
| 6 | Registrar nueve entregas más y consultar | 8 filas y una segunda página |
| 7 | Como recepcion2, registrar una entrega y consultar | Solo aparece la entrega de recepcion2 |
| 8 | Ingresar como admin y abrir la consulta | Aparecen las entregas de todos y el menú no ofrece el registro |

Los ocho casos se probaron ejecutando la aplicación. También se comprobó que, sin entregas registradas, la consulta muestra el mensaje «No hay entregas registradas.».

## Declaración del uso de inteligencia artificial generativa

Utilicé Claude, como apoyo en este laboratorio, Me guio en algunos paso en los cual estaba perdido, me ayudo con errores que no entendia y me explico algunos conceptos que no entendia.