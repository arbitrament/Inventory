namespace Inventory.OOP;

public enum ItemType
{
    Cobblestone,
    Dirt
}

public interface IItem
{
    ItemType Type { get; }
}

public class Item : IItem
{
    public ItemType Type { get; }

    public Item(ItemType type)
    {
        Type = type;
    }
}

public interface IReadOnlyCell<TItem>
{
    string Name { get; }
    int Quantity { get; }
}

public class Cell<TItem> : IReadOnlyCell<TItem> where TItem : IItem
{
    private readonly TItem _item;

    public string Name => _item.Type.ToString();

    public int Quantity { get; private set; }

    public ItemType ItemType => _item.Type;

    public Cell(TItem item, int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        _item = item ?? throw new ArgumentNullException(nameof(item));
        Quantity = amount;
    }

    public bool CanMerge(Cell<TItem> cell)
    {
        if (cell == null)
            throw new ArgumentNullException(nameof(cell));

        return ItemType == cell.ItemType;
    }

    public void Merge(Cell<TItem> cell)
    {
        if (cell == null)
            throw new ArgumentNullException(nameof(cell));

        if (CanMerge(cell) == false)
            throw new ArgumentOutOfRangeException(nameof(cell));

        Quantity += cell.Quantity;
    }
}

public class Inventory<TItem> where TItem : IItem
{
    private readonly List<Cell<TItem>> _cells;

    public IReadOnlyList<IReadOnlyCell<TItem>> Cells => _cells;

    public Inventory()
    {
        _cells = new List<Cell<TItem>>();
    }

    public void Put(Cell<TItem> cell)
    {
        if (cell == null)
            throw new ArgumentNullException(nameof(cell));

        foreach (var existingCell in _cells)
        {
            if (existingCell.CanMerge(cell))
            {
                existingCell.Merge(cell);
                return;
            }
        }

        _cells.Add(cell);
    }
}

// Tests
public class Program
{
    public static void Main()
    {
        var inventory = new Inventory<Item>();
        inventory.Put(new (new (ItemType.Cobblestone), 5));
        inventory.Put(new (new (ItemType.Dirt), 1));
        inventory.Put(new (new (ItemType.Cobblestone), 10));
        inventory.Put(new (new (ItemType.Dirt), 150));

        foreach (var cell in inventory.Cells)
        {
            Console.WriteLine($"{cell.Name}, {cell.Quantity}");
        }
    }
}