﻿namespace WebApplication4.Web.Models
{
	public class Product
	{
        public int Id { get; set; }

        public string? Name { get; set; }
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string Color { get; set; }

        public  DateTime PublishDate { get; set; }


        public bool IsPublish { get; set; }

        public string Expire { get; set; }


        public string Description { get; set; }





    }
}
