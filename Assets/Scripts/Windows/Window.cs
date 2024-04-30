using UnityEngine;

public abstract class Window : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);

        OnWindowShow();
    }

    protected virtual void OnWindowShow() { }

    public void Hide()
    {
        OnWindowHide();

        gameObject.SetActive(false);
    }

    protected virtual void OnWindowHide() { }
}

