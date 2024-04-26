﻿



public enum ItemType
{
    WEAPON,
    ARMOR
}

internal class Item
{
    public string Name { get; }
    public string Desc { get; }

    public ItemType Type;

    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }

    public int Price { get; }

    public bool IsEquipped { get; private set; } //장착여부
    public bool IsPurchased { get; private set; } //구매여부

    public Item(string name, string desc, ItemType type, int atk, int def, int hp, int price, bool isEquipped = false, bool isPurchased = false) //기본값은 false(안낀거)로 수정
    {
        Name = name;
        Desc = desc;
        Type = type;
        Atk = atk;
        Def = def;
        Hp = hp;
        Price = price;
        IsEquipped = isEquipped;
        IsPurchased = isPurchased;
    }

    //
    internal void PrintItemStatDescription(bool withNumber = false, int idx = 0)
    {
        Console.Write("- ");
        if (withNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"{idx}");
            Console.ResetColor();
        }
        if (IsEquipped)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("E");
            Console.ResetColor();
            Console.Write("]");
            Console.Write(ConsoleUtility.PadRightForMixedText(Name, 16));
        }
        else Console.Write(ConsoleUtility.PadRightForMixedText(Name, 19)); //[E]가 3칸이기때문에 3칸추가

        Console.Write(" | ");

        if (Atk != 0) Console.Write($"공격력 {(Atk >= 0 ? "+" : "")}{ConsoleUtility.PadRightForMixedText(Atk.ToString(), 4)}");
        if (Def != 0) Console.Write($"방어력 {(Def >= 0 ? "+" : "")}{ConsoleUtility.PadRightForMixedText(Def.ToString(), 4)}");
        if (Hp != 0) Console.Write($"체 력 {(Hp >= 0 ? "+" : "")}{ConsoleUtility.PadRightForMixedText(Hp.ToString(), 4)}");

        Console.Write(" | ");

        Console.WriteLine(Desc);
    }

    internal void ToggleEquipStates()
    {
        IsEquipped = !IsEquipped;
    }

    internal void PrintStoreItemDescription(bool withNumber = false, int idx = 0)
    {
        Console.Write("- ");
        if (withNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"{idx}");
            Console.ResetColor();
        }
        else Console.Write(ConsoleUtility.PadRightForMixedText(Name, 19));

        Console.Write(" | ");

        if (Atk != 0) Console.Write($"공격력 {(Atk >= 0 ? "+" : "")}{ConsoleUtility.PadRightForMixedText(Atk.ToString(), 4)}");
        if (Def != 0) Console.Write($"방어력 {(Def >= 0 ? "+" : "")}{ConsoleUtility.PadRightForMixedText(Def.ToString(), 4)}");
        if (Hp != 0) Console.Write($"체 력 {(Hp >= 0 ? "+" : "")}{ConsoleUtility.PadRightForMixedText(Hp.ToString(), 4)}");

        Console.Write(" | ");

        Console.Write(ConsoleUtility.PadRightForMixedText(Desc, 50));

        Console.Write(" | ");
        if (IsPurchased)
        {
            Console.WriteLine("구매완료");
        }
        else
        {
            ConsoleUtility.PrintTextHighlights("", Price.ToString(), " G");
        }
    }

    internal void Purchase()
    {
        IsPurchased = true;
    }
}