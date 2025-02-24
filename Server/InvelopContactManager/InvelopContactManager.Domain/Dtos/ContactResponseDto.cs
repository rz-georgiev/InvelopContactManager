namespace InvelopContactManager.Domain.Models
{
    public class ContactResponseDto
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string Surname { get; private set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime Dob { get; private set; }

        public string Address { get; private set; }

        public string PhoneNumber { get; private set; }

        public string Iban { get; private set; }

    }
}