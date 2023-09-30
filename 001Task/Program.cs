using _001Task.Data;

await using var dataContext = new DataContext();

//1
//Напишите запрос LINQ, чтобы получить всех людей, живущих в городе с населением более 3 человек.
//Write a LINQ query to retrieve all the people who live in a city with a population greater than 3 

    var list1 = dataContext.Peoples.Select(p => p).Where(p => p.City.Population >= 3000000).ToList();
    // list1.ForEach(e => Console.WriteLine(e.FirstName));

//2
//Получите все города со средней численностью населения в соответствующей стране
//Retrieve all cities with their respective country's average population

    var list2 = dataContext.Countries.Select(c => new
        { AvaragePopulation = c.Cities.Average(city => city.Population) , Country = c.Name}).ToList();
    // list2.ForEach(c => Console.WriteLine(c.AvaragePopulation + "," + c.Country));

//3
//Получите города с самым высоким населением в каждой стране
//Retrieve the cities with the highest population in each country

    var list3 = dataContext.Cities.Select(c => c).OrderByDescending(e => e.Population).ToList();
    // list3.ForEach(e => Console.WriteLine(e.Name + " " + e.Population));

//4
//Получите среднее население городов в каждой стране
//Retrieve the average population of cities in each country

    var list4 = dataContext.Countries.Select(c => new
        { AvaragePopulation = c.Cities.Average(city => city.Population) , Country = c.Name}).ToList();
    // list4.ForEach(c => Console.WriteLine(c.AvaragePopulation + "," + c.Country));

//5
//Получить все города, в которых есть человек по имени "Марк".
//Retrieve all cities that have a person with by name "Mark"

    var list5 = dataContext.Cities.Select(c => c).Where(x => x.Peoples.Any(p => p.FirstName == "Mark")).ToList();
    // list5.ForEach(x => Console.WriteLine(x.Name));

//6
//Получить всех людей вместе с соответствующими названиями городов и стран
//Retrieve all people along with their associated city and country names

    var list6 = dataContext.Peoples.Select(p => new {Id = p.Id, FirstName = p.FirstName, LastName = p.LastName, Age = p.Age, City = p.City.Name, Country = p.City.Country.Name }).ToList();
    // list6.ForEach(e => Console.WriteLine(e.FirstName + ", " + e.City + ", " + e.Country));

//7
//Получите все города вместе с соответствующими названиями стран, используя свойство навигации
//Retrieve all cities along with their associated country names using a navigation property

    var list7 = dataContext.Cities.Select(c => new { CityName = c.Name, CountryName = c.Country.Name }).ToList();
    list7.ForEach(c => Console.WriteLine(c.CityName + " " + c.CountryName));

//8
//Получить всех людей вместе с связанными с ними городом и страной.
//Retrieve all people along with their associated city and country 

    var list8 = dataContext.Peoples.Select(p => new {Id = p.Id, FirstName = p.FirstName, LastName = p.LastName, Age = p.Age, City = p.City.Name, Country = p.City.Country.Name }).ToList();
    // list8.ForEach(e => Console.WriteLine(e.FirstName + ", " + e.City + ", " + e.Country));

//9
//Получить всех людей, живущих в "USA".
//Retrieve all people living in  "USA".

    var list9 = dataContext.Peoples.Select(p => p).Where(p => p.City.Country.Name == "USA").ToList();
    // list9.ForEach(p => Console.WriteLine(p.FirstName));

//10
//Получить всех людей вместе с соответствующим населением города и страны
//Retrieve all people along with their associated city and country populations 

    var list10 = dataContext.Peoples.Select(p => new {Id = p.Id, FirstName = p.FirstName, LastName = p.LastName, Age = p.Age, CityPopulation = p.City.Population, CountryPopulation = p.City.Country.Cities.Sum(e => e.Population) }).ToList();
    // list10.ForEach(e => Console.WriteLine(e.FirstName + ", " + e.CityPopulation + ", " + e.CountryPopulation));
