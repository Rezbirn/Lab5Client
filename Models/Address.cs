using Lab5Client.Enums;


namespace Lab5Client.Models
{
    public class Address
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Country: {Country}, City: {City}, Street: {Street}, House Number: {HouseNumber}, Apartment Number: {ApartmentNumber}";
        }
    }
}
