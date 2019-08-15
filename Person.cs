using System;

namespace Obligatorisk_oppgave1
{
	public class Person
	{
		public int Id;
		public int BirthYear;
		public string FirstName;
		public string LastName;
		public Person Mother;
		public Person Father;

		public void Show()
		{
			Console.WriteLine("| Id: " + Id + " | First Name: " + FirstName + " | Last Name: " + LastName + " | Birth: " + BirthYear + " | Father: " + Father.FirstName + " | Mother: " + Mother.FirstName + " |");
		}
	}
}
