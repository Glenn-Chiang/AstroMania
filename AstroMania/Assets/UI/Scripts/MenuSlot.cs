using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuSlot : MonoBehaviour
{
    [field: SerializeField] public Image Image { get; private set; }
    [field: SerializeField] public TMP_Text NameText { get; private set; }
    [field: SerializeField] public Button Button { get; private set; }
    [field: SerializeField] public TMP_Text DescriptionText { get; private set; }
}