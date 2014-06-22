CAPTasksMVC
===========

> Segundo trabajo práctico de Programación Web 3


# Especificación Funcional 


## 1) Registración de usuario

Al ingresar a la aplicación, un nuevo usuario podrá registrarse para comenzar a utilizarla. Una
vez registrado, el usuario recibirá un email de activación que contendrá el link donde se activará
su usuario registrado.
Los datos solicitados serán:
● Nombre. Máximo de 20 caracteres. Obligatorio.
● Apellido. Máximo de 20 caracteres. Obligatorio.
● Email. Máximo de 20 caracteres. Obligatorio.
○ Se deberá validar que el formato del dato ingresado sea un email.
● Contraseña. Máximo 20 caracteres. Obligatorio.
○ La contraseña al menos deberá contener 2 números y una letra mayúscula.
○ Deberá existir otro campo donde el usuario deba volver a ingresar la contraseña
para validar su correcta escritura.
○ Ambos campos de contraseña no deben ser visibles para el usuario sino que
deben enmascarar el valor correspondiente.
● Captcha. El usuario deberá ingresar el valor correcto para poder registrarse.
Validaciones:
● En caso de que ya exista un usuario registrado activo con el mismo email, se deberá
validar y mostrar un mensaje amigable que indique que el email ya existe.
● En caso de que ya exista un usuario registrado inactivo con el mismo email, se deberá
permitir la registración del usuario. Activando la registración ya existente y no duplicando
la registración del mismo. Se deberá actualizar los datos Nombre, Apellido y Contraseña.
El link de activación tendrá un tiempo de expiración. Si dicho tiempo se excede. el usuario no
podrá utilizarlo y deberá volver a registrarse. para recibir un nuevo email de activación. El
período de activación es de 15 minutos desde la registración.
Al momento de activarse un usuario, se deberá crear una carpeta “General” que será utilizada
por defecto en aquellas tareas que no se les asocie ninguna carpeta.


## 2) Login de usuario


El usuario podrá ingresar a la aplicación con su email y contraseña definidos en la registración.
Al ingresar en el top del sitio aparecerá un link/boton de logout que al clickearlo borrará los datos
de sesión y redirigirá a la página de Login.
Los datos solicitados serán:
● Email. Máximo de 20 caracteres. Obligatorio.
○ Se deberá validar que el formato del dato ingresado sea un email.
● Contraseña. Máximo 20 caracteres. Obligatorio.
○ El campo de contraseña no debe ser visible para el usuario sino que debe estar
enmascarado.
Validaciones:
● El usuario debe estar registrado en el sistema. Caso contrario, se deberá mostrar un
mensaje amigable “Verifique usuario y/o contraseña.”.
● El usuario debe estar activo. Caso contrario, se deberá mostrar un mensaje amigable
“Usuario inactivo.”.
● La contraseña debe coincidir con la que está registrada el usuario. Caso contrario, se
deberá mostrar un mensaje amigable “Verifique usuario y/o contraseña.”.


## 3) Crear Carpeta


Las carpetas se crearán para agrupar tareas. El uso de las mismas, al momento de crear una
tarea es opcional.
Los datos solicitados son:
● Nombre. Máximo de 20 caracteres. Obligatorio.
● Descripción. Máximo de 200 caracteres. Opcional.


## 4) Crear Tarea


Una vez logueado en la aplicación, el usuario podrá crear nuevas tareas dentro de la aplicación.
Los datos solicitados serán:
● Nombre. Máximo de 20 caracteres. Obligatorio.
● Descripción. Máximo de 200 caracteres. Opcional.
● Fecha Fin. Se deberá utilizar un control de MVC o jquery que permita utilizar fechas.
Opcional.
● Prioridad. Utilizar un control de MVC que permita listar items. Los elementos posibles
son: Alta, Media, Baja, Urgente. Opcional.
● Carpeta. Utilizar un control de MVC que permita listar las carpetas. Las carpetas posibles
se obtendrán dinámicamente. Opcional.
● Completada. Esta campo es un checkbox. Por default, las tareas no deberán estar
completas.
Por defecto todas las tareas tendrán una prioridad Baja.
Se permitirán crear tareas con igual nombre.
En caso de que el usuario no haya creado carpetas o no haya seleccionado ninguna, las tareas
se deberán asociar a una carpeta “General”.


## 5) Listar Tareas


El usuario al ingresar deberá tener un listado de las tareas (ordenada por fecha
descendentemente).
Deberá existir un checkbox que diga “incluir completadas:” que por defecto esta desmarcado y
un boton “Actualizar” que servirá como filtro de las tareas listadas.
La grilla contendrá las siguientes columnas:
1) Fecha
2) Nombre
3) Descripción
4) Prioridad
5) Carpeta
6) Completada
7) (*3) Acción. debe poseer un boton que diga “Completar”, el mismo marca la tarea como
Completada.


## 6) Modificar Tareas


El usuario al ingresar al listado de tareas podrá seleccionar modificar una tarea. Al seleccionarla
podrá modificar todos los datos de la misma. La modificación tendrá que aplicar las mismas
validaciones que en el caso de la creación de tarea.


## 7) Eliminar Tareas (*3)


El usuario al ingresar al listado de tareas podrá seleccionar eliminar una tarea. Al seleccionarla,
el usuario verá un cuadro de diálogo con una confirmación para validar que la acción que está
realizando es correcta. En caso de indicar que sí, la tarea se deberá eliminar de la carpeta en la
que se encuentra.
