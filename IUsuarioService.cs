using ServicioUsuario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioUsuario
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuarioService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        bool Actualizar(string Nombre, string FechaNacimiento, string Sexo);

        [OperationContract]
        bool Agregar(string Nombre, string FechaNacimiento, string Sexo);

        [OperationContract]
        Usuario Buscar(string Nombre);
        [OperationContract]
        List<Usuario> Consultar();
        [OperationContract]
        bool Eliminar(string Nombre);
    }
}
