using NaughtyAttributes;
using UnityEngine;

public class Rulebook : MonoBehaviour
{
    [SerializeField] private WindowsContainer _container;

    [Button]
    private void ShowPicker()
    {
        _container.Change<ResponsesPickerWindow>();
    }

    [Button]
    private void ReturnBack()
    {
        _container.Back();
    }
}
