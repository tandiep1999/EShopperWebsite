using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebShopCart.Models;

[PrimaryKey(nameof(user_id),nameof(user_name),nameof(role))]
public class User 
{

    public string user_id { get; set; }
    
    [Required]
    public string user_name { get; set; }

    public string role {  get; set; }

    public string? first_name { get; set; } //nullable

    public string? last_name { get; set; } //nullable

	public string? created_at { get; set; } //nullable
}