using System;
using System.Collections.Generic;

namespace Refactoring
{
    public class Inventory<TItem> where TItem : IItem
    {
        private int _maxAmountCells;

        private List<Cell<TItem>> _cells;

        public Inventory(int maxAmountCells)
        {
            _maxAmountCells = maxAmountCells;
            _cells = new List<Cell<TItem>>();
        }

        public void Put(Cell<TItem> cell)
        {
            if (_cells.Count + 1 > _maxAmountCells)
                throw new InvalidOperationException(nameof(Put));

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
}
