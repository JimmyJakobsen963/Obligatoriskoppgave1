using System;
using System.Collections.Generic;
using System.Linq;
using Obligatorisk_oppgave1;

namespace ObligatoriskOppgave_1
{
	class Program
	{
		static void Main(string[] args)
		{
			var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
			var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
			var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
			var metteMarit = new Person { Id = 4, FirstName = "Mette-Marit", BirthYear = 1973 };
			var marius = new Person { Id = 5, FirstName = "Marius", LastName = "Borg Høiby", BirthYear = 1997 };
			var harald = new Person { Id = 6, FirstName = "Harald", BirthYear = 1937 };
			var sonja = new Person { Id = 7, FirstName = "Sonja", BirthYear = 1937 };
			var olav = new Person { Id = 8, FirstName = "Olav", BirthYear = 1903 };

			List<Person> personList;
			personList = new List<Person>(8) { sverreMagnus, ingridAlexandra, haakon, metteMarit, marius, harald, sonja, olav };

			sverreMagnus.Father = haakon;
			sverreMagnus.Mother = metteMarit;
			ingridAlexandra.Father = haakon;
			ingridAlexandra.Mother = metteMarit;
			metteMarit.Father = null;
			metteMarit.Mother = null;
			marius.Father = null;
			marius.Mother = metteMarit;
			haakon.Father = harald;
			haakon.Mother = sonja;
			sonja.Father = null;
			sonja.Mother = null;
			harald.Father = olav;
			harald.Mother = null;
			olav.Father = null;
			olav.Mother = null;

			var loop = true;
			while (loop == true)
			{
				var txt = Console.ReadLine();
				if (txt == "hjelp")
				{
					Console.WriteLine("liste => Lister av alle personer med id, fornavn, fødselsår, dødsår, navn og id på mor og far om det finnes registrert.");
					Console.WriteLine("vis => Viser IDen til en bestemt person med mor, far og barn.");
					Console.WriteLine("exit => Exits program.");
				}

				else if (txt == "liste")
				{
					foreach (var person in personList)
					{
						Console.Write($"Id: {person.Id}, Fornavn: {person.FirstName}");
						if (person.LastName != null) Console.Write($", Etternavn: {person.LastName}");
						Console.WriteLine($", Fødselsår: {person.BirthYear}");
						if (person.Father != null)
							Console.WriteLine($"FarId: {person.Father.Id}, FarNavn: {person.Father.FirstName}");
						if (person.Mother != null)
							Console.WriteLine($"MorId: {person.Mother.Id}, MorNavn: {person.Mother.FirstName}");
						Console.WriteLine();
					}
				}
				else if (txt == "vis")
				{
					Console.Write("Skriv Id: ");
					int id = Convert.ToInt32(Console.ReadLine());
					var person = personList.FirstOrDefault(p => p.Id == id);
					Console.Write($"Id: {person.Id}, Fornavn: {person.FirstName}");
					if (person.LastName != null) Console.Write($", Etternavn: {person.LastName}");
					Console.WriteLine($", Fødselsår: {person.BirthYear}");
					if (person.Father != null)
						Console.WriteLine($"FarId: {person.Father.Id}, FarNavn: {person.Father.FirstName}");
					if (person.Mother != null)
						Console.WriteLine($"MorId: {person.Mother.Id}, MorNavn: {person.Mother.FirstName}");

					foreach (var barn in personList)
					{
						if (barn.Father != null && barn.Father.Id == person.Id)
							Console.WriteLine($"BarnId : {barn.Id}, BarnNavn: {barn.FirstName}");
						if (barn.Mother != null && barn.Mother.Id == person.Id)
							Console.WriteLine($"BarnId : {barn.Id}, BarnNavn: {barn.FirstName}");
					}
					Console.WriteLine();
				}
				else if (txt == "Exit")
				{
					loop = false;
				}
			}
		}
	}
}

