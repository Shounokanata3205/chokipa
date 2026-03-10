using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableFruit : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        image.raycastTarget = false; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        GameObject droppedObject = eventData.pointerCurrentRaycast.gameObject;

        if (droppedObject != null)
        {
            PigController pig = droppedObject.GetComponentInParent<PigController>();
            
            if (pig != null)
            {
                // 【ここがポイント！】自分の名前（Appleなど）をそのままブタに伝えます
                pig.EatFruit(gameObject.name);
                
                transform.position = startPosition;
                return;
            }
        }
        transform.position = startPosition;
    }
}