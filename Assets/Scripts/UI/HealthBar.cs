using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        public Slider healthSlider;

        private void OnEnable()
        {
            PlayerHealth.HealthChanged += SetHealth;
            PlayerHealth.MaxHealthChanged += SetMaxHealth;
        }

        private void OnDisable()
        {
            PlayerHealth.HealthChanged -= SetHealth;
            PlayerHealth.MaxHealthChanged -= SetMaxHealth;
        }
    
        private void SetMaxHealth(float health)
        {
            healthSlider.maxValue = health;
            healthSlider.value = health;
        }
    
        private void SetHealth(float health)
        {
            healthSlider.value = health;
        }
    }
}
