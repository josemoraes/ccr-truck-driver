using System;
namespace truckapp01.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Plate { get; set; }
        public string Password { get; set; }
        public bool Term { get; set; }
    }
}
