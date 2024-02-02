using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// FallNumber sınıfı, nesnelerin düşme işlemlerini yönetir.
public class FallNumber : MonoBehaviour
{
    // Ses kontrolü bileşeni.
    private AudioControl _audio;

    // Balonların ebeveyni.
    public GameObject BallonParent;

    // Fabrika nesnesi.
    public GameObject Factory;

    // Balon numarası.
    public int BaloonNumber;

    // İhtiyaç duyulan balon sayısı.
    public int NeedBaloonNumber;

    // 2D çarpışma algılandığında çalışan metod.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Eğer çarpışan nesne bir engelse.
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Balon ebeveynini ve fabrikayı etkinleştir.
            BallonParent.SetActive(true);
            Factory.SetActive(true);

            // Ses kontrolünü bul.
            _audio = FindObjectOfType<AudioControl>();

            // Balon numarasını çağır.
            CallNumber();

            // Bilgi çağır metodunu 1 saniye sonra çağır.
            Invoke(nameof(CallInfo), 1f);
        }

        // Eğer çarpışan nesne bitiş noktasıysa.
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Next Number");

            // Bir sonraki sahneye geç.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Sayıyı çağıran metod.
    public void CallNumber()
    {
        // Ses kontrolünden belirtilen balon numarasının bir eksiğini seslendir.
        _audio.BaloonNumber(BaloonNumber - 1);
    }

    // Bilgi çağır metodunu çağıran metod.
    public void CallInfo()
    {
        // Ses kontrolünden belirtilen ihtiyaç duyulan balon numarasının bir eksiğini seslendir.
        _audio.BaloonCount(NeedBaloonNumber - 1);
    }

    // Ses bilgisini ayarlayan metod.
    public void SetAudioInfo()
    {
        // Ses kontrolünden GameControl sınıfındaki BalonCount'tan, nesnenin altındaki balon sayısını çıkartıp bir eksiğini seslendir.
        int index = GameControl.BalonCount - gameObject.transform.GetChild(0).childCount - 1;
        _audio.BaloonCount(index);
    }
}
