using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PanoramaElements : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] UIGroup;

    private Transform mainParent;
    private int length;

    public bool firstPoint=false;

    private void Awake()
    {
        length = UIGroup.Length;
    }
    private void Start()
    {
      
        mainParent = this.transform;
            
    }

    public void SetVisible(bool visible,float fadeTime)
    {
        if (visible)
        {
            StartCoroutine(Appear(fadeTime));
        }
        else
        {
            StartCoroutine(Fade(fadeTime));
        }
    }

    private IEnumerator Fade(float delay)
    {
        
        for (int i = 0; i < length; i++)
        {
            UIGroup[i].interactable = false;
            UIGroup[i].DOFade(0, delay).SetEase(Ease.Flash);    
        }

        yield return null;
    }
    private IEnumerator Appear(float delay)
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < length; i++)
        {
            UIGroup[i].DOFade(1, delay).SetEase(Ease.Flash);
          
        }


        yield return new WaitForSeconds(delay);
        for (int i = 0; i < length; i++)
        {
            UIGroup[i].interactable = true;
        }
        
    }
}

