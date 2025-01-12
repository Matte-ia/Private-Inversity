using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the GOV.UK login page"); // Welcome message

        Login();

        List<string> searchHistory = new List<string>(); // Create a new list to store the search history

        while (true) // Infinite loop for search and logout
        {
            PerformSearch(searchHistory);

            PrintSearchHistory(searchHistory);

            ClearSearchHistory(searchHistory);

            if (Logout())
            {
                break; // Exit the program
            }
        }
    }

    static void Login()
    {
        Console.WriteLine("Enter your username:");
        string username = Console.ReadLine(); // Read the username from the user

        string password; // Declare a variable to store the password
        while (true) // Infinite loop
        {
            Console.WriteLine("Enter your password:");
            password = Console.ReadLine(); // Read the password from the user

            Console.WriteLine("Re-enter your password:");
            string reenteredPassword = Console.ReadLine(); // Read the re-entered password from the user

            if (password == reenteredPassword) // If the password and re-entered password match
            {
                break; // Exit the loop
            }
            else // If the password and re-entered password do not match
            {
                Console.WriteLine("Passwords do not match. Please try again."); // Error message
            }
        }
    }

    static void PerformSearch(List<string> searchHistory)
    {
        while (true) // Infinite loop for search functionality
        {
            Console.WriteLine(); // Empty line
            Console.WriteLine("Please enter in the search bar what you are looking for:"); // Search message
            string search = Console.ReadLine(); // Read the search query from the user

            searchHistory.Add(search); // Add the search query to the search history list

            // Call the search function
            List<string> searchResults = Search(search);

            // Print the search results
            Console.WriteLine("Search results:");
            foreach (string result in searchResults)
            {
                Console.WriteLine(result);
            }

            string response; // Declare a variable to store the response from the user
            while (true) // Infinite loop for search again prompt
            {
                Console.WriteLine("Do you want to search for something else? (yes/no)"); // Ask user if they want to search again
                response = Console.ReadLine(); // Read the response from the user

                if (response.ToLower() == "yes" || response.ToLower() == "no") // If the response is "yes" or "no"
                {
                    break; // Exit the loop
                }
                else // If the response is neither "yes" nor "no"
                {
                    Console.WriteLine("Invalid response. Please enter 'yes' or 'no'."); // Error message
                }
            }

            if (response.ToLower() == "no") // If the user does not want to search again
            {
                break; // Exit the search loop
            }
        }
    }

    static List<string> Search(string query)
    {
        // Implement your search logic here
        // For demonstration purposes, we'll return a list of dummy search results
        List<string> results = new List<string>
        {
            "Result 1 for " + query,
            "Result 2 for " + query,
            "Result 3 for " + query
        };

        return results;
    }

    static void PrintSearchHistory(List<string> searchHistory)
    {
        // Print the search history
        Console.WriteLine("Search history:");
        foreach (string item in searchHistory) // Loop through each item in the search history list
        {
            Console.WriteLine(item); // Print the item
        }
    }

    static void ClearSearchHistory(List<string> searchHistory)
    {
        while (true) // Infinite loop for clearing search history
        {
            Console.WriteLine("Do you want to clear your search history? (yes/no)"); // Ask user if they want to clear the search history
            string clearResponse = Console.ReadLine(); // Read the response from the user

            if (clearResponse.ToLower() == "yes") // If the response is "yes"
            {
                searchHistory.Clear(); // Clear the search history list
                Console.WriteLine("Search history cleared."); // Confirmation message
                break; // Exit the loop
            }
            else if (clearResponse.ToLower() == "no") // If the response is "no"
            {
                break; // Exit the loop
            }
            else // If the response is neither "yes" nor "no"
            {
                Console.WriteLine("Invalid response. Please enter 'yes' or 'no'."); // Error message
            }
        }
    }

    static bool Logout()
    {
        while (true) // Infinite loop for logout prompt
        {
            Console.WriteLine("Do you want to log out? (yes/no)"); // Ask user if they want to log out
            string logoutResponse = Console.ReadLine(); // Read the response from the user

            if (logoutResponse.ToLower() == "yes") // If the response is "yes"
            {
                Console.WriteLine("You have been logged out."); // Logout message
                return true; // Indicate that the user wants to log out
            }
            else if (logoutResponse.ToLower() == "no") // If the response is "no"
            {
                Console.WriteLine("You are still logged in."); // Stay logged in message
                return false; // Indicate that the user does not want to log out
            }
            else // If the response is neither "yes" nor "no"
            {
                Console.WriteLine("Invalid response. Please enter 'yes' or 'no'."); // Error message
            }
        }
    }
}
