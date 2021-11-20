namespace CommonPassion_Backend.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
       
    }
}
