using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemField : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Image _background;

    [SerializeField] private TMP_Text _valueField;
    [SerializeField] private string _value;
    [SerializeField] private string _type;

    public void Init(Sprite icon, string type, string value, bool selected = false)
    {
        _icon.sprite = icon;
        _background.enabled = selected;

        _valueField.text = type;
        _value = value;
        _type = type;
    }
}
