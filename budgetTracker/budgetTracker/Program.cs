
        // Prompt user for monthly budget
        Console.Write("Enter your monthly budget: ");
        // Using decimal for rounded value 
        decimal monthlyBudget;
        while (!decimal.TryParse(Console.ReadLine(), out monthlyBudget) || monthlyBudget <= 0)
        {
            Console.Write("Please enter a valid positive number for your monthly budget: ");
        }

        // List to store events and their costs
        List<(string eventName, decimal eventCost)> events = new List<(string, decimal)>();

        // Prompt for events and their costs until user is done
        string input;
        do
        {
            Console.Write("Enter the name of the event (or type 'done' to finish): ");
            input = Console.ReadLine().Trim();

            if (input.ToLower() != "done")
            {
                string eventName = input;
                decimal eventCost;
                Console.Write($"Enter the cost of '{eventName}': ");
                while (!decimal.TryParse(Console.ReadLine(), out eventCost) || eventCost < 0)
                {
                    Console.Write($"Please enter a valid non-negative number for the cost of '{eventName}': ");
                }

                // Add event and cost to list
                events.Add((eventName, eventCost));
            }

        } while (input.ToLower() != "done");

        // Calculate total expenses
        decimal totalExpenses = 0;
        foreach (var (eventName, eventCost) in events)
        {
            totalExpenses += eventCost;
        }

        // Display results
        Console.WriteLine("\nSummary:");
        Console.WriteLine($"Monthly Budget: ${monthlyBudget}");
        Console.WriteLine($"Total Expenses for Events:");

        foreach (var (eventName, eventCost) in events)
        {
            Console.WriteLine($"- {eventName}: ${eventCost}");
        }

        Console.WriteLine($"Total Expenses: ${totalExpenses}");

        // Check if expenses exceed budget
        if (totalExpenses > monthlyBudget)
        {
            Console.WriteLine($"You have exceeded your monthly budget by ${totalExpenses - monthlyBudget}.");
        }
        else
        {
            Console.WriteLine($"You have ${monthlyBudget - totalExpenses} left from your monthly budget.");
        }

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();