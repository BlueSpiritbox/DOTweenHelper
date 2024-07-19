using UnityEngine;
using DG.Tweening;
using BSB.DOTWeenHelper;

public class TweenScale : TweenModule
{
    [Header("Tween Scale Values")]
    [SerializeField] Vector3 startScale = new Vector3(0.001f, 0.001f, 0.001f);

    [SerializeField] Vector3 scaleUpVector = Vector3.one;

    [Space]
    [SerializeField] bool scaleX = true;
    [SerializeField] bool scaleY = true;
    [SerializeField] bool scaleZ = true;

    [Space]
    [SerializeField] bool originTo = false;

    private void Awake()
    {
        base.originVal = this.transform.localScale;
    }

    public override void ResetToOrigin()
    {
        this.transform.localScale = base.originVal;
    }

    public override void TweenIn()
    {
        base.TweenIn();

        if (originTo)
            ResetToOrigin();
        else
            this.transform.localScale = new Vector3(
                scaleX ? startScale.x : base.originVal.x, 
                scaleY ? startScale.y : base.originVal.y, 
                scaleZ ? startScale.z : base.originVal.z);

        this.transform.DOScale(scaleUpVector, base.tweenInDuration).SetAs(base.tParams);
    }

    public override void TweenOut()
    {
        base.TweenOut();

        this.transform.DOScale(startScale, base.tweenOutDuration).SetAs(base.tParams);
    }

}
