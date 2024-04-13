using System.ComponentModel.DataAnnotations;

namespace WebShopCart.Models;

public class Product 
{
    [Required]
    public string product_id { get; set; }
    
    public string product_category { get; set; }

    public string product_name { get; set; }

    public string brand { get; set; }

    public float price { get; set; }

	public string currency_id { get; set; }

    public string short_description { get; set; }

    public string long_description { get; set; }
}