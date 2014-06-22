﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region Metadatos de relaciones en EDM

[assembly: EdmRelationshipAttribute("CAPTasksModel", "FK_Carpetas_Usuarios", "Usuarios", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(CAPTasksMVC.Models.Usuarios), "Carpetas", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(CAPTasksMVC.Models.Carpetas), true)]
[assembly: EdmRelationshipAttribute("CAPTasksModel", "FK_Tareas_Carpetas", "Carpetas", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(CAPTasksMVC.Models.Carpetas), "Tareas", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(CAPTasksMVC.Models.Tareas), true)]
[assembly: EdmRelationshipAttribute("CAPTasksModel", "FK_Tareas_Usuarios", "Usuarios", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(CAPTasksMVC.Models.Usuarios), "Tareas", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(CAPTasksMVC.Models.Tareas), true)]

#endregion

namespace CAPTasksMVC.Models
{
    #region Contextos
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    public partial class CAPTasksEntities : ObjectContext
    {
        #region Constructores
    
        /// <summary>
        /// Inicializa un nuevo objeto CAPTasksEntities usando la cadena de conexión encontrada en la sección 'CAPTasksEntities' del archivo de configuración de la aplicación.
        /// </summary>
        public CAPTasksEntities() : base("name=CAPTasksEntities", "CAPTasksEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto CAPTasksEntities.
        /// </summary>
        public CAPTasksEntities(string connectionString) : base(connectionString, "CAPTasksEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto CAPTasksEntities.
        /// </summary>
        public CAPTasksEntities(EntityConnection connection) : base(connection, "CAPTasksEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Métodos parciales
    
        partial void OnContextCreated();
    
        #endregion
    
        #region Propiedades de ObjectSet
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        public ObjectSet<Carpetas> Carpetas
        {
            get
            {
                if ((_Carpetas == null))
                {
                    _Carpetas = base.CreateObjectSet<Carpetas>("Carpetas");
                }
                return _Carpetas;
            }
        }
        private ObjectSet<Carpetas> _Carpetas;
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        public ObjectSet<Tareas> Tareas
        {
            get
            {
                if ((_Tareas == null))
                {
                    _Tareas = base.CreateObjectSet<Tareas>("Tareas");
                }
                return _Tareas;
            }
        }
        private ObjectSet<Tareas> _Tareas;
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        public ObjectSet<Usuarios> Usuarios
        {
            get
            {
                if ((_Usuarios == null))
                {
                    _Usuarios = base.CreateObjectSet<Usuarios>("Usuarios");
                }
                return _Usuarios;
            }
        }
        private ObjectSet<Usuarios> _Usuarios;

        #endregion

        #region Métodos AddTo
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Carpetas. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToCarpetas(Carpetas carpetas)
        {
            base.AddObject("Carpetas", carpetas);
        }
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Tareas. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToTareas(Tareas tareas)
        {
            base.AddObject("Tareas", tareas);
        }
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Usuarios. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToUsuarios(Usuarios usuarios)
        {
            base.AddObject("Usuarios", usuarios);
        }

        #endregion

    }

    #endregion

    #region Entidades
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="CAPTasksModel", Name="Carpetas")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Carpetas : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Carpetas.
        /// </summary>
        /// <param name="idCarpeta">Valor inicial de la propiedad IdCarpeta.</param>
        /// <param name="idUsuario">Valor inicial de la propiedad IdUsuario.</param>
        /// <param name="nombre">Valor inicial de la propiedad Nombre.</param>
        /// <param name="descripcion">Valor inicial de la propiedad Descripcion.</param>
        public static Carpetas CreateCarpetas(global::System.Int32 idCarpeta, global::System.Int32 idUsuario, global::System.String nombre, global::System.String descripcion)
        {
            Carpetas carpetas = new Carpetas();
            carpetas.IdCarpeta = idCarpeta;
            carpetas.IdUsuario = idUsuario;
            carpetas.Nombre = nombre;
            carpetas.Descripcion = descripcion;
            return carpetas;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 IdCarpeta
        {
            get
            {
                return _IdCarpeta;
            }
            set
            {
                if (_IdCarpeta != value)
                {
                    OnIdCarpetaChanging(value);
                    ReportPropertyChanging("IdCarpeta");
                    _IdCarpeta = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("IdCarpeta");
                    OnIdCarpetaChanged();
                }
            }
        }
        private global::System.Int32 _IdCarpeta;
        partial void OnIdCarpetaChanging(global::System.Int32 value);
        partial void OnIdCarpetaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 IdUsuario
        {
            get
            {
                return _IdUsuario;
            }
            set
            {
                OnIdUsuarioChanging(value);
                ReportPropertyChanging("IdUsuario");
                _IdUsuario = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IdUsuario");
                OnIdUsuarioChanged();
            }
        }
        private global::System.Int32 _IdUsuario;
        partial void OnIdUsuarioChanging(global::System.Int32 value);
        partial void OnIdUsuarioChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                OnNombreChanging(value);
                ReportPropertyChanging("Nombre");
                _Nombre = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Nombre");
                OnNombreChanged();
            }
        }
        private global::System.String _Nombre;
        partial void OnNombreChanging(global::System.String value);
        partial void OnNombreChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                OnDescripcionChanging(value);
                ReportPropertyChanging("Descripcion");
                _Descripcion = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Descripcion");
                OnDescripcionChanged();
            }
        }
        private global::System.String _Descripcion;
        partial void OnDescripcionChanging(global::System.String value);
        partial void OnDescripcionChanged();

        #endregion

    
        #region Propiedades de navegación
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("CAPTasksModel", "FK_Carpetas_Usuarios", "Usuarios")]
        public Usuarios Usuarios
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Usuarios>("CAPTasksModel.FK_Carpetas_Usuarios", "Usuarios").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Usuarios>("CAPTasksModel.FK_Carpetas_Usuarios", "Usuarios").Value = value;
            }
        }
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Usuarios> UsuariosReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Usuarios>("CAPTasksModel.FK_Carpetas_Usuarios", "Usuarios");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Usuarios>("CAPTasksModel.FK_Carpetas_Usuarios", "Usuarios", value);
                }
            }
        }
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("CAPTasksModel", "FK_Tareas_Carpetas", "Tareas")]
        public EntityCollection<Tareas> Tareas
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Tareas>("CAPTasksModel.FK_Tareas_Carpetas", "Tareas");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Tareas>("CAPTasksModel.FK_Tareas_Carpetas", "Tareas", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="CAPTasksModel", Name="Tareas")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Tareas : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Tareas.
        /// </summary>
        /// <param name="idTarea">Valor inicial de la propiedad IdTarea.</param>
        /// <param name="idCarpeta">Valor inicial de la propiedad IdCarpeta.</param>
        /// <param name="idUsuario">Valor inicial de la propiedad IdUsuario.</param>
        /// <param name="nombre">Valor inicial de la propiedad Nombre.</param>
        /// <param name="prioridad">Valor inicial de la propiedad Prioridad.</param>
        /// <param name="estado">Valor inicial de la propiedad Estado.</param>
        public static Tareas CreateTareas(global::System.Int32 idTarea, global::System.Int32 idCarpeta, global::System.Int32 idUsuario, global::System.String nombre, global::System.Int16 prioridad, global::System.Int16 estado)
        {
            Tareas tareas = new Tareas();
            tareas.IdTarea = idTarea;
            tareas.IdCarpeta = idCarpeta;
            tareas.IdUsuario = idUsuario;
            tareas.Nombre = nombre;
            tareas.Prioridad = prioridad;
            tareas.Estado = estado;
            return tareas;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 IdTarea
        {
            get
            {
                return _IdTarea;
            }
            set
            {
                if (_IdTarea != value)
                {
                    OnIdTareaChanging(value);
                    ReportPropertyChanging("IdTarea");
                    _IdTarea = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("IdTarea");
                    OnIdTareaChanged();
                }
            }
        }
        private global::System.Int32 _IdTarea;
        partial void OnIdTareaChanging(global::System.Int32 value);
        partial void OnIdTareaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 IdCarpeta
        {
            get
            {
                return _IdCarpeta;
            }
            set
            {
                OnIdCarpetaChanging(value);
                ReportPropertyChanging("IdCarpeta");
                _IdCarpeta = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IdCarpeta");
                OnIdCarpetaChanged();
            }
        }
        private global::System.Int32 _IdCarpeta;
        partial void OnIdCarpetaChanging(global::System.Int32 value);
        partial void OnIdCarpetaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 IdUsuario
        {
            get
            {
                return _IdUsuario;
            }
            set
            {
                OnIdUsuarioChanging(value);
                ReportPropertyChanging("IdUsuario");
                _IdUsuario = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IdUsuario");
                OnIdUsuarioChanged();
            }
        }
        private global::System.Int32 _IdUsuario;
        partial void OnIdUsuarioChanging(global::System.Int32 value);
        partial void OnIdUsuarioChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                OnNombreChanging(value);
                ReportPropertyChanging("Nombre");
                _Nombre = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Nombre");
                OnNombreChanged();
            }
        }
        private global::System.String _Nombre;
        partial void OnNombreChanging(global::System.String value);
        partial void OnNombreChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                OnDescripcionChanging(value);
                ReportPropertyChanging("Descripcion");
                _Descripcion = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Descripcion");
                OnDescripcionChanged();
            }
        }
        private global::System.String _Descripcion;
        partial void OnDescripcionChanging(global::System.String value);
        partial void OnDescripcionChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FechaFin
        {
            get
            {
                return _FechaFin;
            }
            set
            {
                OnFechaFinChanging(value);
                ReportPropertyChanging("FechaFin");
                _FechaFin = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FechaFin");
                OnFechaFinChanged();
            }
        }
        private Nullable<global::System.DateTime> _FechaFin;
        partial void OnFechaFinChanging(Nullable<global::System.DateTime> value);
        partial void OnFechaFinChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 Prioridad
        {
            get
            {
                return _Prioridad;
            }
            set
            {
                OnPrioridadChanging(value);
                ReportPropertyChanging("Prioridad");
                _Prioridad = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Prioridad");
                OnPrioridadChanged();
            }
        }
        private global::System.Int16 _Prioridad;
        partial void OnPrioridadChanging(global::System.Int16 value);
        partial void OnPrioridadChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 Estado
        {
            get
            {
                return _Estado;
            }
            set
            {
                OnEstadoChanging(value);
                ReportPropertyChanging("Estado");
                _Estado = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Estado");
                OnEstadoChanged();
            }
        }
        private global::System.Int16 _Estado;
        partial void OnEstadoChanging(global::System.Int16 value);
        partial void OnEstadoChanged();

        #endregion

    
        #region Propiedades de navegación
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("CAPTasksModel", "FK_Tareas_Carpetas", "Carpetas")]
        public Carpetas Carpetas
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Carpetas>("CAPTasksModel.FK_Tareas_Carpetas", "Carpetas").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Carpetas>("CAPTasksModel.FK_Tareas_Carpetas", "Carpetas").Value = value;
            }
        }
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Carpetas> CarpetasReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Carpetas>("CAPTasksModel.FK_Tareas_Carpetas", "Carpetas");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Carpetas>("CAPTasksModel.FK_Tareas_Carpetas", "Carpetas", value);
                }
            }
        }
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("CAPTasksModel", "FK_Tareas_Usuarios", "Usuarios")]
        public Usuarios Usuarios
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Usuarios>("CAPTasksModel.FK_Tareas_Usuarios", "Usuarios").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Usuarios>("CAPTasksModel.FK_Tareas_Usuarios", "Usuarios").Value = value;
            }
        }
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Usuarios> UsuariosReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Usuarios>("CAPTasksModel.FK_Tareas_Usuarios", "Usuarios");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Usuarios>("CAPTasksModel.FK_Tareas_Usuarios", "Usuarios", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="CAPTasksModel", Name="Usuarios")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Usuarios : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Usuarios.
        /// </summary>
        /// <param name="idUsuario">Valor inicial de la propiedad IdUsuario.</param>
        /// <param name="nombre">Valor inicial de la propiedad Nombre.</param>
        /// <param name="apellido">Valor inicial de la propiedad Apellido.</param>
        /// <param name="email">Valor inicial de la propiedad Email.</param>
        /// <param name="contrasenia">Valor inicial de la propiedad Contrasenia.</param>
        /// <param name="estado">Valor inicial de la propiedad Estado.</param>
        /// <param name="fechaCreacion">Valor inicial de la propiedad FechaCreacion.</param>
        /// <param name="fechaActivacion">Valor inicial de la propiedad FechaActivacion.</param>
        /// <param name="codigoActivacion">Valor inicial de la propiedad CodigoActivacion.</param>
        public static Usuarios CreateUsuarios(global::System.Int32 idUsuario, global::System.String nombre, global::System.String apellido, global::System.String email, global::System.String contrasenia, global::System.Int16 estado, global::System.DateTime fechaCreacion, global::System.DateTime fechaActivacion, global::System.String codigoActivacion)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.IdUsuario = idUsuario;
            usuarios.Nombre = nombre;
            usuarios.Apellido = apellido;
            usuarios.Email = email;
            usuarios.Contrasenia = contrasenia;
            usuarios.Estado = estado;
            usuarios.FechaCreacion = fechaCreacion;
            usuarios.FechaActivacion = fechaActivacion;
            usuarios.CodigoActivacion = codigoActivacion;
            return usuarios;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 IdUsuario
        {
            get
            {
                return _IdUsuario;
            }
            set
            {
                if (_IdUsuario != value)
                {
                    OnIdUsuarioChanging(value);
                    ReportPropertyChanging("IdUsuario");
                    _IdUsuario = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("IdUsuario");
                    OnIdUsuarioChanged();
                }
            }
        }
        private global::System.Int32 _IdUsuario;
        partial void OnIdUsuarioChanging(global::System.Int32 value);
        partial void OnIdUsuarioChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                OnNombreChanging(value);
                ReportPropertyChanging("Nombre");
                _Nombre = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Nombre");
                OnNombreChanged();
            }
        }
        private global::System.String _Nombre;
        partial void OnNombreChanging(global::System.String value);
        partial void OnNombreChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Apellido
        {
            get
            {
                return _Apellido;
            }
            set
            {
                OnApellidoChanging(value);
                ReportPropertyChanging("Apellido");
                _Apellido = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Apellido");
                OnApellidoChanged();
            }
        }
        private global::System.String _Apellido;
        partial void OnApellidoChanging(global::System.String value);
        partial void OnApellidoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Contrasenia
        {
            get
            {
                return _Contrasenia;
            }
            set
            {
                OnContraseniaChanging(value);
                ReportPropertyChanging("Contrasenia");
                _Contrasenia = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Contrasenia");
                OnContraseniaChanged();
            }
        }
        private global::System.String _Contrasenia;
        partial void OnContraseniaChanging(global::System.String value);
        partial void OnContraseniaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 Estado
        {
            get
            {
                return _Estado;
            }
            set
            {
                OnEstadoChanging(value);
                ReportPropertyChanging("Estado");
                _Estado = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Estado");
                OnEstadoChanged();
            }
        }
        private global::System.Int16 _Estado;
        partial void OnEstadoChanging(global::System.Int16 value);
        partial void OnEstadoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime FechaCreacion
        {
            get
            {
                return _FechaCreacion;
            }
            set
            {
                OnFechaCreacionChanging(value);
                ReportPropertyChanging("FechaCreacion");
                _FechaCreacion = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FechaCreacion");
                OnFechaCreacionChanged();
            }
        }
        private global::System.DateTime _FechaCreacion;
        partial void OnFechaCreacionChanging(global::System.DateTime value);
        partial void OnFechaCreacionChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime FechaActivacion
        {
            get
            {
                return _FechaActivacion;
            }
            set
            {
                OnFechaActivacionChanging(value);
                ReportPropertyChanging("FechaActivacion");
                _FechaActivacion = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FechaActivacion");
                OnFechaActivacionChanged();
            }
        }
        private global::System.DateTime _FechaActivacion;
        partial void OnFechaActivacionChanging(global::System.DateTime value);
        partial void OnFechaActivacionChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String CodigoActivacion
        {
            get
            {
                return _CodigoActivacion;
            }
            set
            {
                OnCodigoActivacionChanging(value);
                ReportPropertyChanging("CodigoActivacion");
                _CodigoActivacion = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("CodigoActivacion");
                OnCodigoActivacionChanged();
            }
        }
        private global::System.String _CodigoActivacion;
        partial void OnCodigoActivacionChanging(global::System.String value);
        partial void OnCodigoActivacionChanged();

        #endregion

    
        #region Propiedades de navegación
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("CAPTasksModel", "FK_Carpetas_Usuarios", "Carpetas")]
        public EntityCollection<Carpetas> Carpetas
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Carpetas>("CAPTasksModel.FK_Carpetas_Usuarios", "Carpetas");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Carpetas>("CAPTasksModel.FK_Carpetas_Usuarios", "Carpetas", value);
                }
            }
        }
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("CAPTasksModel", "FK_Tareas_Usuarios", "Tareas")]
        public EntityCollection<Tareas> Tareas
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Tareas>("CAPTasksModel.FK_Tareas_Usuarios", "Tareas");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Tareas>("CAPTasksModel.FK_Tareas_Usuarios", "Tareas", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
