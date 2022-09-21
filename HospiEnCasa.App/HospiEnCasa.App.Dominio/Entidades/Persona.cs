namespace HospiEnCasa.App.Dominio
{
    public  class Persona
    {
        // identificar las propiedades (atributos) de la clase
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroTelefono { get; set; }
        public Genero Genero { get; set; }
    }
}