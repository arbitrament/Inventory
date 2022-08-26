using UnityEngine;

namespace Refactoring
{
    public class Item : MonoBehaviour, IItem
    {
        [field: SerializeField] public int Id { get; private set; }
    }
}