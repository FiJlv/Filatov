using CinemaAPI.Migrations;

namespace CinemaAPI.Models.ModelsForRequests
{
    public class AddBuyerRequest
    {
        private string email;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email
        {
            get { return email; }
            set
            {
                if (value.Contains('@'))
                    email = value;
                else
                    throw new ArgumentException("email must have an @ symbol");
            }
        }
    }
}
