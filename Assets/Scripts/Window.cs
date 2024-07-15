using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _actionButton;
    
    private float _alphaMax = 1f;
    private float _alphaMin = 0f;
    
    public event UnityAction PlayButtonClicked;

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Open()
    {
        _windowGroup.alpha = _alphaMax;
        _windowGroup.blocksRaycasts = true;
        _actionButton.interactable = true;
    }

    public void Close()
    {
        _windowGroup.alpha = _alphaMin;
        _windowGroup.blocksRaycasts = false;
        _actionButton.interactable = false;
    }

    private void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }

}
