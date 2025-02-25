namespace InvelopContactManager.Domain.Models
{
    public class ContactResponseDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime Dob { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Iban { get; set; }

    }
}