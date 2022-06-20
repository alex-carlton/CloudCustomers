namespace CloudCustomers.Services.Models
{
    /// <summary>
    /// One that uses
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A word or phrase that constitutes the distinctive designation of a person or thing
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// A means or system for transmitting messages electronically (as between computers on a network)
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// To mark directions for delivery on
        /// </summary>
        public Address? Address { get; set; }
    }
}