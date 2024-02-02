using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// GameControl sınıfı, oyunun genel kontrolünü sağlar.
public class GameControl : MonoBehaviour
{
    // Kazanma paneli nesnesi.
    public GameObject winpanel;

    // Bitiş çizgisi nesnesi.
    public GameObject finishLine;

    // Balon sayılarının ebeveyni.
    public GameObject BalonNumberParent;

    // İhtiyaç duyulan balon sayısı.
    public int NeedBaloon;

    // Statik olarak kullanılacak balon sayısı.
    public static int BalonCount;

    // Oyunun bitip bitmediğini kontrol eden değişken.
    private bool isFinished = false;

    // Rect transform bileşeni.
    private RectTransform rect;

    // Awake metodu, oyun başladığında çalışır.
    private void Awake()
    {
        // Balon sayısını ihtiyaç duyulan balon sayısıyla eşleştir.
        BalonCount = NeedBaloon;
    }

    // Update metodu, her frame'de çalışır.
    void Update()
    {
        // Eğer BalonNumberParent nesnesinin altındaki balon sayısı ihtiyaç duyulan balon sayısına eşitse ve oyun bitmemişse.
        if (BalonNumberParent.transform.childCount == BalonCount && !isFinished)
        {
            // Oyun bitmiş olarak işaretle.
            isFinished = true;

            // Kazanma panelini ve bitiş çizgisini etkinleştir.
            winpanel.SetActive(true);
            finishLine.SetActive(true);

            // BalonNumberParent'ın üstündeki Rigidbody2D bileşeninin gravityScale değerini -20 yap.
            BalonNumberParent.transform.GetComponentInParent<Rigidbody2D>().gravityScale = -20;

            // Rect transform bileşenini BalonNumberParent'ın üstündeki bir bileşen olarak al.
            rect = BalonNumberParent.transform.GetComponentInParent<RectTransform>();

            // CallFunc metodunu 1 saniye sonra çağır.
            Invoke(nameof(CallFunc), 1f);
        }
    }

    // CallFunc metodunu çağıran metod.
    void CallFunc()
    {
        // BalonNumberParent'ın üstündeki FallNumber sınıfının CallNumber metodunu çağır.
        BalonNumberParent.transform.GetComponentInParent<FallNumber>().CallNumber();
    }
}
