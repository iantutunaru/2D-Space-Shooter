using System.Collections;
using UnityEngine;

namespace Shaders
{
    public class DamageFlash : MonoBehaviour
    {
        [ColorUsage(true, true)]
        [SerializeField] private Color flashColor = Color.white;
        [SerializeField] private float flashDuration = 0.25f;
    
        private SpriteRenderer[] _spriteRenderers;
        private Material[] _materials;
        private Coroutine _damageFlashCoroutine;
        private float _currentFlashAmount = 0f;
    
        private static readonly int FlashColor = Shader.PropertyToID("_FlashColor");
        private static readonly int FlashAmount = Shader.PropertyToID("_FlashAmount");

        private void Awake()
        {
            _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        
            Init();
        }

        private void OnEnable()
        {
            _currentFlashAmount = 0f;
            SetFlashAmount(_currentFlashAmount);
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void Init()
        {
            _materials = new Material[_spriteRenderers.Length];

            for (int i = 0; i < _spriteRenderers.Length; i++)
            {
                _materials[i] = _spriteRenderers[i].material;
            }
        }

        public void CallDamageFlash()
        {
            _damageFlashCoroutine = StartCoroutine(DamageFlasher());
        }

        private IEnumerator DamageFlasher()
        {
            SetFlashColor();
        
            var elapsedTime = 0f;

            while (elapsedTime < flashDuration)
            {
                elapsedTime += Time.deltaTime;
            
                _currentFlashAmount = Mathf.Lerp(1f, 0f, (elapsedTime / flashDuration));
                SetFlashAmount(_currentFlashAmount);
            
                yield return null;
            }
        }

        private void SetFlashColor()
        {
            foreach (var material in _materials)
            {
                material.SetColor(FlashColor, flashColor);
            }
        }

        private void SetFlashAmount(float flashAmount)
        {
            foreach (var material in _materials)
            {
                material.SetFloat(FlashAmount, flashAmount);
            }
        }
    }
}
