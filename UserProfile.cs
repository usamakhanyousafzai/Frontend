using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RaiseHope
{
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public List<string> DonationHistory { get; set; }
        public List<string> ReceivedFundsHistory { get; set; }

        public UserProfile()
        {
            DonationHistory = new List<string>();
            ReceivedFundsHistory = new List<string>();
        }
    }
}
