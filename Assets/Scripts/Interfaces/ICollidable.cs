using UnityEngine;

namespace Interfaces
{
    public interface ICollidable
    {
        void OnTriggerEnter2D(Collider2D other);
    }
}