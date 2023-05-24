using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;

namespace HueFestival_OnlineTicket.Models
{
    public class ResetPasswordRequest
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Token { get; set; } = string.Empty;
        [System.ComponentModel.DataAnnotations.Required, MinLength(6, ErrorMessage = "at least 6 characters")]
        public string Password { get; set; } = string.Empty;
        [System.ComponentModel.DataAnnotations.Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
