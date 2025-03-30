OtusDictionary dictionary = new OtusDictionary();

// Добавление элементов
dictionary.Add(0, "One");
dictionary.Add(1, "Two");
dictionary.Add(33, "ThirtyThree"); // Коллизия с ключом 1

// Получение элементов
Console.WriteLine(dictionary.Get(1)); // One
Console.WriteLine(dictionary.Get(2)); // Two
Console.WriteLine(dictionary.Get(33)); // ThirtyThree

// Использование индексатора
dictionary[4] = "Four";
Console.WriteLine(dictionary[4]); // Four

// Обновление значения через индексатор
dictionary[1] = "UpdatedOne";
Console.WriteLine(dictionary[1]); // UpdatedOne

// Попытка добавить null
try
{
    dictionary.Add(5, null);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.Message); // Значение не может быть null.
}
