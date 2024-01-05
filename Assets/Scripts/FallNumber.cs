using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallNumber : MonoBehaviour
{
    private AudioControl _audio;
    public GameObject BallonParent;
    public GameObject Factory;
    public int BaloonNumber;
    public int NeedBaloonNumber;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            BallonParent.SetActive(true);
            Factory.SetActive(true);
            _audio = FindObjectOfType<AudioControl>();
            CallNumber();
            Invoke(nameof(CallInfo), 1f);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Nest Number");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void CallNumber()
    {
        _audio.BaloonNumber(BaloonNumber -1);
    }
    public void CallInfo()
    {
        _audio.BaloonCount(NeedBaloonNumber-1);
    }
    public void SetAudioInfo()
    {
        int index = GameControl.BalonCount - gameObject.transform.GetChild(0).childCount -1; 
        _audio.BaloonCount(index);
    }
}
