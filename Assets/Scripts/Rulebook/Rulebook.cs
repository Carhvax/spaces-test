using UnityEngine;

public class Rulebook : MonoBehaviour
{
    [SerializeField] private WindowsContainer _container;
    [SerializeField] private RulebookWindow _window;

    private void OnEnable()
    {
        _container.Init();
        _window.Show();
    }
}
