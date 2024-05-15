using UnityEngine;
using UnityEngine.UI;

public class StatusEffectDisplayer : MonoBehaviour
{
    [SerializeField] private StatusEffectManager effectManager;
    [SerializeField] private Image iconPrefab; // The status effect icon is displayed in the image component of this prefab

    private void Start()
    {
        effectManager.EffectAdded += OnEffectAdded;
        effectManager.EffectRemoved += OnEffectRemoved;
    }

    private void OnEffectAdded(object sender, StatusEffectData statusEffect)
    {
        var icon = Instantiate(iconPrefab, transform);
        icon.sprite = statusEffect.Icon;
    }
    private void OnEffectRemoved(object sender, StatusEffectData statusEffect)
    {

    }
}