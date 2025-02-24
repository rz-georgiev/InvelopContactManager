namespace InvelopContactManager.Domain.Models
{
    public class Contact
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

        public Contact(
            string firstName,
            string surname,
            DateTime dob,
            string address,
            string phoneNumber,
            string iban)
        {
            SetContactData(firstName, surname, dob, address, phoneNumber, iban);
        }

        public void UpdateContact(string firstName,
            string surname,
            DateTime dob,
            string address,
            string phoneNumber,
            string iban)
        {
            SetContactData(firstName, surname, dob, address, phoneNumber, iban);
        }

        private void SetContactData(string firstName,
            string surname,
            DateTime dob,
            string address,
            string phoneNumber,
            string iban)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First Name is required!");
            if (string.IsNullOrWhiteSpace(surname)) throw new ArgumentException("Surname is required!");
            if (dob == DateTime.MinValue || dob > DateTime.UtcNow) throw new ArgumentException("Date Of Birth is required and should not be in the future!");
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentException("Address is required!");
            if (string.IsNullOrWhiteSpace(phoneNumber)) throw new ArgumentException("Phone Number is required!");
            if (string.IsNullOrWhiteSpace(iban)) throw new ArgumentException("Iban is required!");

            FirstName = firstName;
            Surname = surname;
            Dob = dob;
            Address = address;
            PhoneNumber = phoneNumber;
            Iban = iban;
        }
    }
}