using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSApiRestPractice.Domain {

    [Table("client")]
    public class Client {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("clientId")]
        [Required]
        public int ClientId { get; set; }

        [Column("firstName")]
        [Required(ErrorMessage = "Error, introduce a first name")]
        public string FirstName { get; set; }

        [Column("lastName")]
        [Required(ErrorMessage = "Error, introduce a last name")]
        public string LastName { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "Error, introduce an email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")]
        public string Email { get; set; }

        [Column("phoneNumber")]
        [Required(ErrorMessage = "Error, introduce a phone number")]
        public int PhoneNumber { get; set; }

        public Client() {

        }

        public Client(int clientId) {

            this.ClientId = clientId;

        }

        public Client(int clientId, string firstName, string lastName, string email, int phoneNumber) {

            this.ClientId = clientId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;

        }

        public Client(string firstName, string lastName, string email, int phoneNumber) {

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;

        }

        public Client(string firstName, string lastName) {

            this.FirstName = firstName;
            this.LastName = lastName;

        }

        public override bool Equals(object? obj) {
            return obj is Client client &&
                   ClientId == client.ClientId &&
                   FirstName == client.FirstName &&
                   LastName == client.LastName &&
                   Email == client.Email &&
                   PhoneNumber == client.PhoneNumber;
        }

        public override int GetHashCode() {
            return HashCode.Combine(ClientId, FirstName, LastName, Email, PhoneNumber);
        }

    }

}
