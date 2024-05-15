using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectDisplayer : MonoBehaviour
{
    [SerializeField] private StatusEffectManager effectManager;
    [SerializeField] private Image iconPrefab; // The status effect icon is displayed in the image component of this prefab
    [SerializeField] private float gap;
    private float IconWidth => iconPrefab.rectTransform.rect.width;
    private Dictionary<StatusEffectData, Image> effectIcons = new();

    private void Start()
    {
        effectManager.EffectAdded += OnEffectAdded;
        effectManager.EffectRemoved += OnEffectRemoved;
    }

    private void OnEffectAdded(object sender, StatusEffectData statusEffect)
    {
        var icon = Instantiate(iconPrefab, transform);
        var iconXPos = transform.position.x + effectIcons.Count * (IconWidth + gap);
        var iconPos = new Vector3(iconXPos, transform.position.y);
        icon.transform.position = iconPos;  
        icon.sprite = statusEffect.Icon;
        effectIcons.Add(statusEffect, icon);
    }
    private void OnEffectRemoved(object sender, StatusEffectData statusEffect)
    {
        var icon = effectIcons[statusEffect];
        Destroy(icon.gameObject);
        effectIcons.Remove(statusEffect);
    }
}