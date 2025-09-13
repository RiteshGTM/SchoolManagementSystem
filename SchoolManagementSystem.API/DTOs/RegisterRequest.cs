using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SchoolManagementSystem.API.DTOs
{
    [DataContract, Serializable]
    public class RegisterRequest
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}