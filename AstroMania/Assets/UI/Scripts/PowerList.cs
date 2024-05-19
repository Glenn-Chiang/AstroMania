using UnityEngine;

public class PowerList : MonoBehaviour
{
    [SerializeField] private PowerManager powerManager;
    [SerializeField] private Transform listContent;
    [SerializeField] private ItemSlot itemSlotPrefab;

    private void OnEnable()
    {
        foreach (var power in powerManager.Powers)
        {
            var slot = Instantiate(itemSlotPrefab, listContent);
            slot.NameText.text = power.Name;
            slot.Image.sprite = power.Sprite;
            slot.Image.preserveAspect = true;
            slot.DescriptionText.text = power.Description;
        }
    }
}