
using SmartContractValidator.Models;

string testString = "HelloWorld123";
string pattern = @"^[a-zA-Z0-9]*$";
int testItem = 5;
List<int> testCollection = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int min = 1;
int max = 2;

var contractValidator = new SmartContractValidator.Helpers.SmartContractValidator();

// Add validation points
//contractValidator.AddValidationPoint(() => !string.IsNullOrEmpty(testString));
//contractValidator.AddValidationPoint(() => System.Text.RegularExpressions.Regex.IsMatch(testString, pattern));
//contractValidator.AddValidationPoint(() => testCollection.Contains(testItem));
//contractValidator.AddValidationPoint(() => testItem >= min && testItem <= max);
//contractValidator.AddValidationPoint(() => testCollection.Distinct().Count() == testCollection.Count);


// Create two lists of Persona objects
List<Persona> personasList1 = new List<Persona>
{
    new Persona { Nombre = "John", Edad = 30 },
    new Persona { Nombre = "Jane", Edad = 25 },
    new Persona { Nombre = "Alice", Edad = 28 }
};

List<Persona> personasList2 = new List<Persona>
{
    new Persona { Nombre = "John", Edad = 30 },
    new Persona { Nombre = "Alice", Edad = 28 },
    new Persona { Nombre = "Jane", Edad = 25 },
   
    //new Persona { Nombre = "Bob", Edad = 35 }
};

contractValidator.AddValidationPoint(() =>
{
    if (personasList1.Count != personasList2.Count)
        return false;

    var sortedList1 = personasList1.OrderBy(p => p.Nombre).ThenBy(p => p.Edad).ToList();
    var sortedList2 = personasList2.OrderBy(p => p.Nombre).ThenBy(p => p.Edad).ToList();

    for (int i = 0; i < sortedList1.Count; i++)
    {
        if (sortedList1[i].Nombre != sortedList2[i].Nombre || sortedList1[i].Edad != sortedList2[i].Edad)
            return false;
    }

    return true;
});

// Validate the contract
bool isValid = contractValidator.Validate();

Console.WriteLine($"Validation result: {isValid}");

Console.ReadLine();