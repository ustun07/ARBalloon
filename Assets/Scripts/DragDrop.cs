using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeginDrag;
    private Vector3 startPosition;
    private Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeginDrag = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeginDrag = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (eventData.pointerEnter != null && eventData.pointerEnter.gameObject.CompareTag("Number"))
        {
            Debug.Log("Dropped on number true");
            gameObject.transform.parent = eventData.pointerEnter.gameObject.transform.GetChild(0);
            gameObject.transform.localPosition = new Vector2(0, 0);
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Image>().raycastTarget = false;
            if(gameObject.transform.parent.childCount >= 1)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, -15 + -gameObject.transform.parent.childCount*5);
                gameObject.transform.localPosition = new Vector2(-15, 0);
            }
            eventData.pointerEnter.gameObject.GetComponent<FallNumber>().SetAudioInfo();
        }
        else
        {
            Debug.Log("Did not drop on number");
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }
}