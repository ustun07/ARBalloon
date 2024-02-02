using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// DragDrop sınıfı, nesnelerin sürüklenip bırakılma işlemlerini yönetir.
public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Sürükleme başladığında etkileşimde bulunan nesne.
    public static GameObject itemBeginDrag;

    // Sürükleme başladığında nesnenin başlangıç pozisyonu ve ebeveyni.
    private Vector3 startPosition;
    private Transform startParent;

    // Sürükleme başladığında çalışan metod.
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Sürüklenen nesneyi belirle.
        itemBeginDrag = gameObject;

        // Nesnenin başlangıç pozisyonunu ve ebeveynini kaydet.
        startPosition = transform.position;
        startParent = transform.parent;

        // Raycast'i engelle.
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    // Sürükleme sırasında çalışan metod.
    public void OnDrag(PointerEventData eventData)
    {
        // Nesnenin pozisyonunu fare pozisyonuna ayarla.
        transform.position = Input.mousePosition;
    }

    // Sürükleme bittiğinde çalışan metod.
    public void OnEndDrag(PointerEventData eventData)
    {
        // Sürüklenen nesne null yap ve raycast'i aktif hale getir.
        itemBeginDrag = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        // Eğer bırakılan nesne bir sayıysa.
        if (eventData.pointerEnter != null && eventData.pointerEnter.gameObject.CompareTag("Number"))
        {
            Debug.Log("Dropped on number true");

            // Nesneyi sayının altındaki alt nesne olarak ayarla.
            gameObject.transform.parent = eventData.pointerEnter.gameObject.transform.GetChild(0);

            // Nesneyi yerel pozisyonunu sıfırla.
            gameObject.transform.localPosition = new Vector2(0, 0);

            // Collider'ı devre dışı bırak.
            gameObject.GetComponent<Collider2D>().enabled = false;

            // Raycast hedefini devre dışı bırak.
            gameObject.GetComponent<Image>().raycastTarget = false;

            // Eğer sayının altındaki nesne sayısı bir veya daha fazlaysa.
            if (gameObject.transform.parent.childCount >= 1)
            {
                // Nesnenin açısını ayarla.
                gameObject.transform.eulerAngles = new Vector3(0, 0, -15 + -gameObject.transform.parent.childCount * 5);

                // Nesnenin yerel pozisyonunu ayarla.
                gameObject.transform.localPosition = new Vector2(-15, 0);
            }

            // Bırakılan nesnenin bağlı olduğu sayının ses bilgisini ayarla.
            eventData.pointerEnter.gameObject.GetComponent<FallNumber>().SetAudioInfo();
        }
        else
        {
            Debug.Log("Did not drop on number");

            // Eğer nesne sayı değilse, başlangıç pozisyonuna geri taşı.
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }
}
