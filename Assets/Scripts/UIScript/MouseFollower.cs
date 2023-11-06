using UnityEngine;
using Inventory.UI;

public class MouseFollower : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
    private Camera _mainCam;

    [SerializeField]
    private UIInventoryItem _item;

    public void Awake()
    {
        _canvas = transform.root.GetComponent<Canvas>();
        _item = GetComponentInChildren<UIInventoryItem>();
        _mainCam = Camera.main;
    }

    public void SetData(Sprite sprite, int quantity)
    {
        _item.SetData(sprite, quantity);
    }
    void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)_canvas.transform,
            Input.mousePosition,
            _canvas.worldCamera,
            out position
                );
        transform.position = _canvas.transform.TransformPoint(position);
    }
    
    public void Toggle(bool val)
    {
        Debug.Log($"Item toggled {val}");
        gameObject.SetActive(val);
    }
}
