using System.Collections;

//Setting up Dictionary
Dictionary<string, decimal> sevenEleven = new Dictionary<string, decimal>();
sevenEleven.Add("big gulp", 4.99M);
sevenEleven.Add("beef jerky", 2.99M);
sevenEleven.Add("skittles", 1.99M);
sevenEleven.Add("pizza slice", 2.50M);
sevenEleven.Add("chips", 1.00M);
sevenEleven.Add("popcorn", 1.50M);
sevenEleven.Add("chocolate", 1.75M);
sevenEleven.Add("hot dog", 2.00M);

List<string> ordered = new List<string>();

//Intro
Console.WriteLine("Welcome to Seven Eleven!");
Console.WriteLine("Please take a look at our available products.");
Console.WriteLine("");
Console.WriteLine("Item\t\tPrice");
Console.WriteLine("=====================");
decimal runningTotal = 0;
bool slurpee = true;

//Foreach to display items + prices to user
foreach(KeyValuePair<string, decimal> kvp in sevenEleven)
{
    Console.WriteLine($"{kvp.Key}    \t{kvp.Value}");
}

//Asking user to enter desired items
while (slurpee)
{
    Console.WriteLine("What item would you like to order?  Please enter option below.");
    //loops until user makes a valid selection
    while (true)
    {
        string choice = Console.ReadLine().ToLower().Trim();
        //Checking to see if user choice is available
        sevenEleven.ContainsKey(choice);
        if (sevenEleven.ContainsKey(choice))
        {
            //if valid
            Console.WriteLine($"{choice} is in stock and costs {sevenEleven[choice]}");
            //runningTotal += sevenEleven[choice];
            ordered.Add(choice);
            break;
        }
        else
        {
            //if invalid
            Console.WriteLine(" ");
            Console.WriteLine("Item\t\tPrice");
            Console.WriteLine("=====================");
            foreach (KeyValuePair<string, decimal> kvp in sevenEleven)
            {
                Console.WriteLine($"{kvp.Key}    \t{kvp.Value}");
            }
            Console.WriteLine("not in stock... please select again and make sure it's on the menu!");
        }
    }

    while (true)
    {
        Console.WriteLine("Would you like to purchase another item? y/n");
        string buyMore = Console.ReadLine().ToLower().Trim();
        if (buyMore == "y")
        {
            break;
        }
        else if(buyMore == "n")
        {
            slurpee = false;
            break;
        }
        else
        {
            Console.WriteLine("Please enter y/n.");
        }
    }
}

string mostExpensive = ordered[0];
string minPrice = ordered[0];
Console.WriteLine("Here is everything you ordered...");
for(int i = 0; i < ordered.Count; i++)
{
    Console.WriteLine($"{ordered[i]} costs {sevenEleven[ordered[i]]}");
    runningTotal += sevenEleven[ordered[i]];
    if (sevenEleven[ordered[i]] < sevenEleven[minPrice])
    {
        minPrice = ordered[i];
    }
    if (sevenEleven[ordered[i]] > sevenEleven[mostExpensive])
    {
        mostExpensive = ordered[i];
    }
}

Console.WriteLine($"Your total is: ${runningTotal}.  Your most expensive item was {mostExpensive} and cost ${sevenEleven[mostExpensive]}. Your least was {minPrice} and cost ${sevenEleven[minPrice]}. Thanks for coming to Seven Eleven!");