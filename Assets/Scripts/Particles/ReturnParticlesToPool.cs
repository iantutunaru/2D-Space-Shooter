using Managers;
using UnityEngine;

namespace Particles
{
    public class ReturnParticlesToPool : MonoBehaviour
    {
        private void OnParticleSystemStopped()
        {
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
    }
}
