using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        public Slider healthSlider;

        private void OnEnable()
        {
            Actions.Actions.HealthChanged += SetHealth;
            Actions.Actions.MaxHealthChanged += SetMaxHealth;
        }

        private void OnDisable()
        {
            Actions.Actions.HealthChanged -= SetHealth;
            Actions.Actions.MaxHealthChanged -= SetMaxHealth;
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
