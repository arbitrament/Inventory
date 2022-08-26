using UnityEngine;

namespace Refactoring
{
    public class Character : MonoBehaviour
    {
        private Inventory<Item> _itemInventory;
        private Inventory<Weapon> _weaponInventory;
        private Inventory<Armor> _armorInventory;

        private void Awake()
        {
            _itemInventory = new Inventory<Item>(10);
            _weaponInventory = new Inventory<Weapon>(1);
            _armorInventory = new Inventory<Armor>(1);
        }

        public void OnItemTook(Item item)
        {
            _itemInventory.Put(new Cell<Item>(item, 1));
        }

        public void OnWeaponTook(Weapon weapon)
        {
            _weaponInventory.Put(new Cell<Weapon>(weapon, 1));
        }

        public void OnArmorTook(Armor armor)
        {
            _armorInventory.Put(new Cell<Armor>(armor, 1));
        }
    }
}