/* Brie Prater
07/09/2020
CIS 353
Professor Cain
Assignment 6.2 B */

using System;
using System.Collections.Generic;
using System.Text;
namespace CIS353
{
	public class Book // Book class
	{
		string _title; // holds variables 
		string _author;
		double _price;
		int _numPages;
		public string Title // _title accessors
		{
			get { return _title; }
			set { _title = value; }
		}
		public string Author // _author accessors
		{
			get { return _author; }
			set { _author = value; }
		}
		public double Price // _price accesors
		{
			get { return _price; }
			set { _price = value; }
		}
		public int Pages // _numPages accessors
		{
			get { return _numPages; }
			set { _numPages = value; }
		}
		public void BookEx(string Title, double Price, int Pages) // method to determine if price ratio is correct, passes title, price and pages
		{
			if (Price > 0.10 * Pages) // flags books that have an invalid ratio
			{
				throw (new BookException("For " + Title + ", ratio is invalid. \n Price is $" + Price + " for " + Pages + " pages."));
				// throws exception message if ratio is invalid
			}
		}
	}
	public class BookException : Exception // exception class for BookException
	{
		public BookException(string message) : // derives exception with message
			base(message)
		{ }
		public class FormatException : Exception // exception class for FormatException
		{
			public FormatException(string message) : // derives exception with message
				base(message)
			{ }
		}
	}
	public class Test // Test Class
	{
		public static void Main(string[] args) // Main method
		{
			Object[] Books = new Object[5]; // creates object array with 5 indexes
			string Title = null; // Title variable set to null
			string Author = null; // Author variable set to null
			double Price = 0; // Price variable set to 0
			int Pages = 0; // Pages variable set to 0
			Book a = new Book(); // instantiates Book class
			for (int x = 0; x < Books.Length; x++) // for loop to fill all indexes in Books object array
			{
				try // code that may return an error
				{
					Console.WriteLine("Please enter book title: ");
					Title = Console.ReadLine(); // sets user input to Title
					Console.WriteLine("Please enter book author: ");
					Author = Console.ReadLine(); // sets user input to Author
					Console.WriteLine("Please enter book price: ");
					Price = Convert.ToDouble(Console.ReadLine()); // sets user input to Price
					Console.WriteLine("Please enter number of pages in book: ");
					Pages = Convert.ToInt32(Console.ReadLine()); // sets user input to Pages
					a.BookEx(Title, Price, Pages); // calls BookEx method and passes Title, Price, Pages variables
				}
				catch (FormatException e) // catches FormatException errors
				{
					Console.WriteLine(e.Message); // displays message indicating invalid format
					Price = 0; // sets Price to 0 to avoid storing information from previous inputs
					Pages = 0; // sets Pages to 0 to avoid storing information from previous inputs
				}
				catch (BookException e) // catches defined BookException errors
				{
					Console.WriteLine(e.Message); // displays message indicating ratio is invalid
					Price = 0.10 * Pages; // changes invalid price ratio to a valid price ratio
				}
				Books[x] = string.Format("{0} by {1} costs {2:C2} for {3} pages.", Title, Author, Price, Pages); 
				// stores string holding Title, Author, Price, Pages variables in Books index of for loop iteration
			}
			for (int x = 0; x < Books.Length; x++) // for loop to display all indexes of Books object array
			{
				Console.WriteLine(Books[x]); // displays strings that are stored in Books object array for index of for loop iteration
			}
		}
	}
}