using UnityEngine;

using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform handle;
    private Vector2 inputVector;

    public float Horizontal => inputVector.x;
    public float Vertical => inputVector.y;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out position
        );

        position.x = (position.x / ((RectTransform)transform).sizeDelta.x);
        position.y = (position.y / ((RectTransform)transform).sizeDelta.y);

        inputVector = new Vector2(position.x * 2, position.y * 2);
        inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

        handle.anchoredPosition = new Vector2(
            inputVector.x * ((RectTransform)transform).sizeDelta.x / 2,
            inputVector.y * ((RectTransform)transform).sizeDelta.y / 2
        );
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}