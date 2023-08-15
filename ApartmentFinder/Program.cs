using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество этажей: ");
        int floorsNumber = int.Parse(Console.ReadLine());

        Console.Write("Введите количесто подъездов: ");
        int entrancesNumber = int.Parse(Console.ReadLine());

        Console.Write("Введите номер квартиры: ");
        int apartmentNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("\n\n" + FindApartmentLocation(floorsNumber, entrancesNumber, apartmentNumber));
    }

    static string FindApartmentLocation(int floorsNumber, int entrancesNumber, int apartmentNumber)
    {
        int apartmentsPerEntrance = 4 * floorsNumber;
        int totalApartments = apartmentsPerEntrance * entrancesNumber;

        if (apartmentNumber < 1 || apartmentNumber > totalApartments)
        {
            return "Такой квартиры нет";
        }

        int entranceNumber = (apartmentNumber - 1) / apartmentsPerEntrance + 1;
        int apartmentPositionWithinEntrance = (apartmentNumber - 1) % apartmentsPerEntrance;

        int floorWithinEntrance = apartmentPositionWithinEntrance / 4 + 1;
        int apartmentPosition = apartmentPositionWithinEntrance % 4 + 1;

        string apartmentPositionDescription = GetApartmentPositionDescription(apartmentPosition);

        return $"Этаж: {entranceNumber}, \nПодъезд: {floorWithinEntrance}, \nПозиция: {apartmentPositionDescription}";
    }

    private static string GetApartmentPositionDescription(int apartmentPosition)
    {
        switch (apartmentPosition)
        {
            case 1:
                return "Ближняя слева";
            case 2:
                return "Дальняя слева";
            case 3:
                return "Дальняя справа";
            case 4:
                return "Ближняя справа";
            default:
                //щютка
                return "Квартира в воздухе";
        }
    }
}