using UnityEngine;

namespace Refactoring
{
    public class Armor : MonoBehaviour, IItem
    {
        [field: SerializeField] public int Id { get; private set; }
    }
}
