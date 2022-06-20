namespace CloudCustomers.Services.Models
{
    /// <summary>
    /// To mark directions for delivery on
    /// </summary>
    public class Address
    {
        /// <summary>
        /// A thoroughfare especially in a city, town, or village that is wider than an alley or lane and that usually includes sidewalks
        /// </summary>
        public string? Street { get; set; }

        /// <summary>
        /// An inhabited place of greater size, population, or importance than a town or village
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// A number that identifies a particular postal delivery area in the U.S.
        /// </summary>
        public string? ZipCode { get; set; }
    }
}