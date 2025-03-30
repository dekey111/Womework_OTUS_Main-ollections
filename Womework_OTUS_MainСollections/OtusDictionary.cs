using System;
public class OtusDictionary
{
    private string[] _storage;
    private int _capacity;
    private int _count;

    public OtusDictionary()
    {
        _capacity = 32; // Начальный размер массива
        _storage = new string[_capacity];
        _count = 0;
    }

    /// <summary>
    /// Метод для вычисления хеш-функции
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    private int GetHash(int key)
    {
        return Math.Abs(key % _capacity);
    }

    /// <summary>
    /// Метод для добавления элемента
    /// </summary>
    /// <param name="key">Принимает "Ключ" </param>
    /// <param name="value">Принимает "Значвение" </param>
    /// <exception cref="ArgumentNullException">Возвращает если "Значение" == null</exception>
    /// <exception cref="ArgumentException">Возврашает если элемент с таким ключём уже есть</exception>
    public void Add(int key, string value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value), "Значение не может быть null.");
        }

        if (_count >= _capacity)
        {
            ResizeStorage();
        }

        int index = GetHash(key);

        // Проверка на коллизии
        while (_storage[index] != null)
        {
            if (_storage[index] == value)
            {
                throw new ArgumentException("Элемент с таким ключом уже существует.");
            }
            index = (index + 1) % _capacity; // Линейное пробирование
        }

        _storage[index] = value;
        _count++;
    }

    /// <summary>
    /// Метод для получения элемента
    /// </summary>
    /// <param name="key">Принимает "Ключ" словаря</param>
    /// <returns>Возвращает элемент</returns>
    public string Get(int key)
    {
        int index = GetHash(key);

        // Поиск элемента с учетом линейного пробирования
        while (_storage[index] != null)
        {
            if (_storage[index] != null)
            {
                return _storage[index];
            }
            index = (index + 1) % _capacity;
        }

        return null; // Если элемент не найден
    }

    /// <summary>
    /// Метод для увеличения размера массива
    /// </summary>
    private void ResizeStorage()
    {
        int newCapacity = _capacity * 2;
        string[] newStorage = new string[newCapacity];

        // Пересчет хешей и перенос элементов в новый массив
        for (int i = 0; i < _capacity; i++)
        {
            if (_storage[i] != null)
            {
                int newIndex = Math.Abs(i % newCapacity);
                while (newStorage[newIndex] != null)
                {
                    newIndex = (newIndex + 1) % newCapacity; // Линейное пробирование
                }
                newStorage[newIndex] = _storage[i];
            }
        }

        _storage = newStorage;
        _capacity = newCapacity;
    }

    /// <summary>
    /// Индексатор для работы с элементами
    /// </summary>
    /// <param name="key">Принимает "Ключ" словаря </param>
    /// <returns>Возвращает эемент словаря</returns>
    /// <exception cref="ArgumentNullException">Возвращает если "Ключ" == null </exception>
    public string this[int key]
    {
        get => Get(key);
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Значение не может быть null.");
            }

            int index = GetHash(key);

            // Поиск элемента с учетом линейного пробирования
            while (_storage[index] != null)
            {
                if (_storage[index] != null)
                {
                    _storage[index] = value;
                    return;
                }
                index = (index + 1) % _capacity;
            }

            // Если элемент не найден, добавляем новый
            Add(key, value);
        }
    }
}