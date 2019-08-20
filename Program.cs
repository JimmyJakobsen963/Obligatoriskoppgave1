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
			var none = new Person { Id = 1337, FirstName = "None", BirthYear = 1337 };

			List<Person> personList;
			personList = new List<Person>(8) { sverreMagnus, ingridAlexandra, haakon, metteMarit, marius, harald, sonja, olav };

			sverreMagnus.Father = haakon;
			sverreMagnus.Mother = metteMarit;
			ingridAlexandra.Father = haakon;
			ingridAlexandra.Mother = metteMarit;
			metteMarit.Father = none;
			metteMarit.Mother = none;
			marius.Father = none;
			marius.Mother = metteMarit;
			haakon.Father = harald;
			haakon.Mother = sonja;
			sonja.Father = none;
			sonja.Mother = none;
			harald.Father = olav;
			harald.Mother = none;
			olav.Father = none;
			olav.Mother = none;

			Console.WriteLine("Slektstre-program!");
			Console.WriteLine();
			Console.WriteLine("Skriv 'hjelp' for å få opp dine alternativer.");

			var loop = true;
			while (loop == true)
			{
				var txt = Console.ReadLine().ToLower();
				if (txt == "hjelp")
				{
					Console.WriteLine();
					Console.WriteLine("liste => Lister av alle personer med fornavn, fødselsår, dødsår, navn og id på mor og far om det finnes i registeret.");
					Console.WriteLine("vis => Viser IDen til en bestemt person med mor, far og barn.");
					Console.WriteLine("exit => Exits program.");
					Console.WriteLine();
				}
				else if (txt == "liste")
				{
					foreach (var person in personList)
					{
						person.Show();
					}
				}
				else if (txt == "vis")
				{
					Console.Write("Skriv Id: ");
					int id = Convert.ToInt32(Console.ReadLine());
					var person = personList.FirstOrDefault(p => p.Id == id);
					if (person != null)
					{
						person.Show();



						foreach (var barn in personList)
						{
							if (barn.Father != null && barn.Father.Id == person.Id)
								Console.WriteLine($"BarnId : {barn.Id}, BarnNavn: {barn.FirstName}");
							if (barn.Mother != null && barn.Mother.Id == person.Id)
								Console.WriteLine($"BarnId : {barn.Id}, BarnNavn: {barn.FirstName}");
						}
					}

					Console.WriteLine();
				}
				else if (txt == "exit")
				{
					loop = false;
				}
			}
		}
	}
}

