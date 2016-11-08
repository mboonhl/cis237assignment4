using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //Class Droid Collection implements the IDroidCollection interface.
    //All methods declared in the Interface must be implemented in this class 
    class DroidCollection : IDroidCollection
    {
        //Private variable to hold the collection of droids
        private IDroid[] droidCollection;
        //This array is used for the merge 
        private IDroid[] mergeDroidCollection = new IDroid[100];

        //Private variable to hold the length of the Collection
        private int lengthOfCollection;

        //Constructor that takes in the size of the collection.
        //It sets the size of the internal array that will be used.
        //It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            //Make new array for the collection
            droidCollection = new IDroid[sizeOfCollection];
            //set length of collection to 0
            lengthOfCollection = 0;
        }

        //The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Model, string Color, int NumberOfLanguages)
        {
            //If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                //Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                //of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Model, Color, NumberOfLanguages);
                //Increase the length of the collection
                lengthOfCollection++;
                //return that it was successful
                return true;
            }
            //Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        //The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        //The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The last method that must be implemented due to implementing the interface.
        //This method iterates through the list of droids and creates a printable string that could
        //be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            //Declare the return string
            string returnString = "";

            //For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                //If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    //Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    //the program will automatically know which version of CalculateTotalCost it needs to call based
                    //on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    //Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            //return the completed string
            return returnString;
        }

        public void PreLoadArray()
        {
            Add("Carbonite", "Protocol", "Red", 10);
            Add("Vanadium", "Protocol", "Blue", 20);
            Add("Quadranium", "Protocol", "Greem", 30);
            Add("Carbonite", "Utility", "Red", true, true, false);
            Add("Vanadium", "Utility", "Blue", false, false, true);
            Add("Quadranium", "Utility", "Greem", false, false, false);
            Add("Carbonite", "Janitor", "Red", true, true, true, true, false);
            Add("Vanadium", "Janitor", "Blue", false, false, false, false, false);
            Add("Quadranium", "Janitor", "Greem", true, false, true, false, true);
            Add("Carbonite", "Astromech", "Red", true, true, true, false, 22);
            Add("Vanadium", "Astromech", "Blue", false, false, true, false, 1);
            Add("Quadranium", "Astromech", "Greem", false, true, false, true, 33);
        }

        public void SortByType()
        {
            Stack<IDroid> protocolStack = new Stack<IDroid>();
            Stack<IDroid> astromechStack = new Stack<IDroid>();
            Stack<IDroid> utilityStack = new Stack<IDroid>();
            Stack<IDroid> janitorStack = new Stack<IDroid>();

            Queue<IDroid> idroidQueue = new Queue<IDroid>();

            for (int i = 0; i < lengthOfCollection; i++)
            {

                if (droidCollection[i] == typeof(ProtocolDroid))
                {
                    protocolStack.AddToFront(droidCollection[i]);
                }
                if (droidCollection[i] == typeof(UtilityDroid))
                {
                    utilityStack.AddToFront(droidCollection[i]);
                }
                if (droidCollection[i] == typeof(AstromechDroid))
                {
                    astromechStack.AddToFront(droidCollection[i]);
                }
                if (droidCollection[i] == typeof(JanitorDroid))
                {
                    janitorStack.AddToFront(droidCollection[i]);
                }
            }

            //Removes items from the stack and adds them to the queue in order by droid type
            while (astromechStack.Size > 0)
            {
                idroidQueue.AddToBack(astromechStack.RemoveFromFront());
            }
            while (janitorStack.Size > 0)
            {
                idroidQueue.AddToBack(janitorStack.RemoveFromFront());
            }
            while (protocolStack.Size > 0)
            {
                idroidQueue.AddToBack(protocolStack.RemoveFromFront());
            }
            while (utilityStack.Size > 0)
            {
                idroidQueue.AddToBack(utilityStack.RemoveFromFront());
            }
            
            //Adds sorted droids back into array
            for (int i = 0; i < lengthOfCollection; i++)
            {
                droidCollection[i] = idroidQueue.RemoveFromFront();
            }

        }

        private void Sort(IDroid[] input, int low, int high)
        {
            //When high is less than or equal to low the sort is done
            if (high <= low)
            {
                return;
                
            }
            else
            {
                int middle = low + (high - low)/2;

                Sort(input, low, middle);

                Sort(input, middle + 1, high);

                Merge(input, low, middle, high);
            }
        }

        public void SortByPrice()
        {
            Sort(droidCollection, 0, lengthOfCollection - 1);
        }

        private void Merge(IDroid[] input, int low, int middle, int high)
        {
            int _low = low;
            int _middle = middle + 1;

            for (int l = low; l <= high; l++)
            {
                mergeDroidCollection[l] = input[l];
            }

            for (int l = low; l <= high; l++)
            {
                //If low is greater than middle set middle to middle + 1
                if (_low > middle)
                {
                    input[l] = mergeDroidCollection[_middle++];
                }
                else if (_middle > high)
                {
                    input[l] = mergeDroidCollection[_low++];
                }
                else if (mergeDroidCollection[_middle].TotalCost > mergeDroidCollection[_low].TotalCost )
                {
                    input[l] = mergeDroidCollection[_middle++];
                }
                else
                {
                    input[l] = mergeDroidCollection[_low];
                }
            }
        }

    }
}
