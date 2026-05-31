using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Manager.Classes
{
    public class Item
    {
        private string _name = "";
        private int _quantity;
        private double _price;
        private int _id;

        public int Id { 
            get => _id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("ID cannot be negative.");
                }
                _id = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }
                _name = value;
            }
        }
        public int Quantity
        {
            get => _quantity;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be negative.");
                }
                _quantity = value;
            }
        }
        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                _price = value;
            }
        }
    }
}