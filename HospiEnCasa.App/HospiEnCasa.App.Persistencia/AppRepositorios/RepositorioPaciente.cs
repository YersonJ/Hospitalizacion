using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        // campo propio tipo AppContext de la clase RepositorioPaciente
        private readonly AppContext _contexto;


        //creamos el constructor de RepositorioPaciente
        public RepositorioPaciente(AppContext _context)
        {
            _contexto = _context;
        }

        //Metodo para realizar el CRUD
        //Esto que aparece abajo es lo mismo decir: public Paciente AddPaciente(Paciente paciente){ aqui iria el codigo...}
        Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)
        {
            var pacienteAdicionado = _contexto.Pacientes.Add(paciente);
            _contexto.SaveChanges();
            return pacienteAdicionado.Entity;
        }

        //Metodo para eliminar un paciente
        //Esto es lo mismo, decir: public void Paciente (int Paciente){ aqui va el codigo...} 
        
        void IRepositorioPaciente.DeletePaciente(int idPaciente)
        {
            var pacienteEncontrado = _contexto.Pacientes.FirstOrDefault (p => p.Id == idPaciente);
            if (pacienteEncontrado == null) return;
            _contexto.Pacientes.Remove(pacienteEncontrado);
            _contexto.SaveChanges();

        //esto es lo mismo que las lineas anteriores
        // if (pacienteEncontrado != null)
        // {
        //        _contexto.Pacientes.Remove(pacienteEncontrado);
        //        _contexto.SaveChanges();
        // }
        // else
        // {
        //    return;
        // }
        }

        //Metodo para obtener todos los pacientes
        IEnumerable<Paciente> IRepositorioPaciente.GetAllPacientes()
        {
            return _contexto.Pacientes;
        }

         //Metodo para obtener un solo paciente
        Paciente IRepositorioPaciente.GetPaciente(int idPaciente)
        {
            return _contexto.Pacientes.FirstOrDefault (p => p.Id == idPaciente);
        }


        //Metodo para actualizar un paciente

        Paciente IRepositorioPaciente.UpdatePaciente(Paciente paciente)
        {
            var pacienteEncontrado = _contexto.Pacientes.FirstOrDefault( p => p.Id == paciente.Id );
            if (pacienteEncontrado != null )
            {
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.Apellido = paciente.Apellido;
                pacienteEncontrado.NumeroTelefono = paciente.NumeroTelefono;
                pacienteEncontrado.Genero = paciente.Genero;
                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Latitud = paciente.Latitud;
                pacienteEncontrado.Longitud = paciente.Longitud;
                pacienteEncontrado.Ciudad = paciente.Ciudad;
                pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
                pacienteEncontrado.Familiar = paciente.Familiar;
                pacienteEncontrado.Enfermera = paciente.Enfermera;
                pacienteEncontrado.Medico = paciente.Medico;
                pacienteEncontrado.Historia = paciente.Historia;
                _contexto.SaveChanges();
            }
            return pacienteEncontrado;
        }

        //Metodo para asignar un medico
        Medico IRepositorioPaciente.AsignarMedico(int idPaciente, int idMedico)
        {
            var pacienteEncontrado = _contexto.Pacientes.FirstOrDefault( p => p.Id == idPaciente );
            if (pacienteEncontrado != null)
            {
                var medicoEncontrado = _contexto.Medicos.FirstOrDefault( m => m.Id == idMedico );
                if (medicoEncontrado != null )
                {
                    pacienteEncontrado.Medico = medicoEncontrado;
                    _contexto.SaveChanges();
                }
                return medicoEncontrado;
            }
            return null;
        }
    }
}