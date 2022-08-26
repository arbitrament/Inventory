using System;

namespace Refactoring
{
    public class Cell<TItem> where TItem : IItem
    {
        private TItem _item;

        public int Amount { get; private set; }

        public int ItemId => _item.Id;

        public Cell(TItem item, int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _item = item;
            Amount = amount;
        }

        public bool CanMerge(Cell<TItem> cell)
        {
            return ItemId == cell.ItemId;
        }

        public void Merge(Cell<TItem> cell)
        {
            if (CanMerge(cell) == false)
                throw new ArgumentOutOfRangeException(nameof(cell));

            Amount += cell.Amount;
        }
    }
}

