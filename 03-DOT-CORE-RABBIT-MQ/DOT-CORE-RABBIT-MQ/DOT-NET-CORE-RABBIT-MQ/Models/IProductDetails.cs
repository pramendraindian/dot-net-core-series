﻿namespace DOT_NET_CORE_RABBIT_MQ.Models
{
    public interface IProductDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
