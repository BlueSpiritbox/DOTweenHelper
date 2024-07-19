using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using BSB.DOTWeenHelper;

public class TweenAlpha : TweenModule 
{
    [Header("Tween Alpha Values")]
	public CanvasGroup canvasGroup;
	public Image image;
    public Text text;

	public float fromAlpha = 0f;
	public float toAlpha = 1f;

    private bool tempInteractableState;

    private void Awake()
    {
        if (canvasGroup != null)
            base.originVal = new Vector3(canvasGroup.alpha, 0, 0);
        else if (image != null)
            base.originVal = new Vector3(image.color.a, 0, 0);
        else if (text != null)
            base.originVal = new Vector3(text.color.a, 0, 0);

    }

    public override void OnDisable()
    {
        if (canvasGroup != null)
        {
            canvasGroup.interactable = tempInteractableState;
            canvasGroup.DOKill();
        }

        if (image != null)
            image.DOKill();

        if (text != null)
            text.DOKill();
    }

    public override void OnDestroy()
    {
        if (canvasGroup != null)
            canvasGroup.DOKill();

        if (image != null)
            image.DOKill();

        if (text != null)
            text.DOKill();
    }

    public override void ResetToOrigin()
    {
        if (canvasGroup != null)
            canvasGroup.alpha = base.originVal.x;
        else if (image != null)
            image.color = new Color(image.color.r, image.color.g, image.color.b, base.originVal.x);
        else if (text != null)
            text.color = new Color(text.color.r, text.color.g, text.color.b, base.originVal.x);
    }

    public override void TweenIn()
    {
        base.TweenIn();

        if (canvasGroup != null)
        {
            canvasGroup.DOKill();
            canvasGroup.alpha = fromAlpha;
            canvasGroup.DOFade(toAlpha, base.tweenInDuration).SetAs(base.tParams).OnComplete(FadeInCompleted);
            
            tempInteractableState = canvasGroup.interactable;
            canvasGroup.interactable = false;
        }
        if (image != null)
        {
            image.DOKill();
            image.color = new Color(image.color.r, image.color.g, image.color.b, fromAlpha);
            image.DOFade(toAlpha, base.tweenInDuration).SetAs(base.tParams).SetEase(base.tweenInEaseType);
        }
        if (text != null)
        {
            text.DOKill();
            text.color = new Color(text.color.r, text.color.g, text.color.b, fromAlpha);
            text.DOFade(toAlpha, base.tweenInDuration).SetAs(base.tParams).SetEase(base.tweenInEaseType);
        }

    }

    void FadeInCompleted()
    {
        if (canvasGroup != null)
        {
            canvasGroup.interactable = tempInteractableState;
        }
    }

    public override void TweenOut()
	{
        base.TweenOut();

		if (canvasGroup != null) {
            canvasGroup.DOFade(0f, base.tweenOutDuration).SetAs(base.tParams);
        }
		if (image != null) {
            image.DOFade(0f, base.tweenOutDuration).SetAs(base.tParams);
        }
        if (text != null)
        {
            text.DOFade(0f, base.tweenOutDuration).SetAs(base.tParams);
        }
    }

}
