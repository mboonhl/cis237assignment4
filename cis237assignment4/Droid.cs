using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //Abstract class that implements the IDroid interface
    abstract class Droid : IDroid, IComparable
    {
        //some protected variables for the class
        protected string material;
        protected string model;
        protected string color;

        protected decimal baseCost;
        protected decimal totalCost;

        //The public property for TotalCost
        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        //Constructor that takes the main 3 parameters shared amongst all 4 types of droids
        public Droid(string Material, string Model, string Color)
        {
            this.material = Material;
            this.model = Model;
            this.color = Color;

            CalculateTotalCost();
        }

        //Virtual method that can be overridden in the derived classes if needed.
        //This implementation calculates the cost based on the material used for the droid
        protected virtual void CalculateBaseCost()
        {
            switch (this.material)
            {
                case "Carbonite":
                    this.baseCost = 100.00m;
                    break;

                case "Vanadium":
                    this.baseCost = 120.00m;
                    break;

                case "Quadranium":
                    this.baseCost = 150.00m;
                    break;

                default:
                    this.baseCost = 50.00m;
                    break;
            }
        }

        //Abstract method that MUST be overriden in the derived class to calculate the total cost
        public abstract void CalculateTotalCost();

        //Overriden toString method that will return a string representing the basic information for any droid
        public override string ToString()
        {
            return "Material: " + this.material + Environment.NewLine +
                    "Model: " + this.model + Environment.NewLine +
                    "Color: " + this.color + Environment.NewLine;
        }

        public virtual int CompareTo(Droid _droid)
        {
            if (_droid==null)
            {
                return 1;
            }

            return TotalCost.CompareTo(_droid.TotalCost);
        }
    }
}
