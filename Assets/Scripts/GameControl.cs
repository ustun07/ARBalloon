using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject winpanel;
    public GameObject finishLine;
    public GameObject BalonNumberParent;
    public int NeedBaloon;
    public static int BalonCount;
    private bool isFinished = false;
    private RectTransform rect;
    private void Awake()
    {
        BalonCount = NeedBaloon;
    }
    void Update()
    {
        if(BalonNumberParent.transform.childCount== BalonCount && !isFinished)
        {
            isFinished = true;
            winpanel.SetActive(true);
            finishLine.SetActive(true);
            BalonNumberParent.transform.GetComponentInParent<Rigidbody2D>().gravityScale = -20;
            rect = BalonNumberParent.transform.GetComponentInParent<RectTransform>();
            Invoke(nameof(CallFunc), 1f);
        }
    }
    void CallFunc()  {    BalonNumberParent.transform.GetComponentInParent<FallNumber>().CallNumber();   }
}
