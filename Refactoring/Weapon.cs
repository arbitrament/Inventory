using UnityEngine;

namespace Refactoring
{ 
    public class Weapon : MonoBehaviour, IItem
    {
        [field: SerializeField] public int Id { get; private set; }
    }
}