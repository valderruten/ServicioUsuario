using System.Data.Entity;
using ServicioUsuario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioUsuario
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UsuarioService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UsuarioService.svc o UsuarioService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UsuarioService : IUsuarioService
    {
        public bool Actualizar(string Nombre, string FechaNacimiento, string Sexo)
        {
            bool Result = false;
            Usuario usuario = new Usuario
            {
                nombre = Nombre,
                FechaNacimiento = DateTime.Parse(FechaNacimiento),
                sexo = Sexo
            };
            using (BD_TESTFINALEntities bd=new BD_TESTFINALEntities())
            {
                bd.Entry(usuario).State = EntityState.Modified;
                Result= bd.SaveChanges()>0;
            }
            return Result;
        }

        

        public bool Agregar(string Nombre, string FechaNacimiento, string Sexo)
        {
            bool Result = false;
            Usuario usuario = new Usuario
            {
                nombre = Nombre,
                FechaNacimiento = DateTime.Parse(FechaNacimiento),
                sexo = Sexo
            };
            using (BD_TESTFINALEntities bd = new BD_TESTFINALEntities())
            {
                bd.Usuarios.Add(usuario);

                Result = bd.SaveChanges() > 0;
            }
            return Result;
        }
  

        public Usuario Buscar(string Nombre)
        {
        using (BD_TESTFINALEntities bd = new BD_TESTFINALEntities())
        {
            return bd.Usuarios.Find(Nombre);
        }
        }

        public List<Usuario> Consultar()
        {
            using (BD_TESTFINALEntities bd = new BD_TESTFINALEntities())
            {
                return bd.Usuarios.ToList();
            }
        }

        public bool Eliminar(string Nombre)
        {
            bool Result = false;
            using(BD_TESTFINALEntities bd=new BD_TESTFINALEntities())
            {
                Usuario usuario = bd.Usuarios.Find (Nombre);    
                bd.Usuarios.Remove(usuario);
                Result=bd.SaveChanges()>0;
            }
            return Result;
        }
    }
}
