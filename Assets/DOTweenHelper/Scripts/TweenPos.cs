using UnityEngine;
using DG.Tweening;
using BSB.DOTWeenHelper;

public class TweenPos : TweenModule 
{
    [Header("Tween Pos Values")]
    public bool localTween = true;

	public enum TweenTypes { MoveTo, MoveFrom, MoveBy };
	public TweenTypes tweenType;

	public Vector3 endValue;	//set in inspector


    private void Awake()
    {
        base.originVal = localTween ? this.transform.localPosition : this.transform.position;
    }

    public override void ResetToOrigin()
    {
        if (localTween)
            this.transform.localPosition = base.originVal;
        else
            this.transform.position = base.originVal;
    }

	public override void TweenIn()
	{
        base.TweenIn();

        ResetToOrigin();

        if (tweenType == TweenTypes.MoveTo)
        {
            if (localTween)
            {
                this.transform.DOLocalMove(endValue, base.tweenInDuration).SetAs(base.tParams);
            }
            else
            {
                this.transform.DOMove(endValue, base.tweenInDuration).SetAs(base.tParams);
            }
        }
        else if (tweenType == TweenTypes.MoveFrom)
        {
            if (localTween)
            {
                this.transform.DOLocalMove(endValue, base.tweenInDuration).SetAs(base.tParams).From();
            }
            else
            {
                this.transform.DOMove(endValue, base.tweenInDuration).SetAs(base.tParams).From();
            }
        }
        else if (tweenType == TweenTypes.MoveBy)
        {
            if (localTween)
            {
                this.transform.DOLocalMove(base.originVal + endValue, base.tweenInDuration).SetAs(base.tParams);
            }
            else
            {
                this.transform.DOMove(base.originVal + endValue, base.tweenInDuration).SetAs(base.tParams);
            }
        }

    }

    public override void TweenOut()
    {
        base.TweenOut();

        if (tweenType == TweenTypes.MoveTo || tweenType == TweenTypes.MoveBy)
        {
            if (localTween)
            {
                this.transform.DOLocalMove(base.originVal, base.tweenOutDuration).SetAs(base.tParams);
            }
            else
            {
                this.transform.DOMove(base.originVal, base.tweenOutDuration).SetAs(base.tParams);
            }
        }
        else if (tweenType == TweenTypes.MoveFrom)
        {
            if (localTween)
            {
                this.transform.DOLocalMove(endValue, base.tweenOutDuration).SetAs(base.tParams).From();
            }
            else
            {
                this.transform.DOMove(endValue, base.tweenOutDuration).SetAs(base.tParams).From();
            }
        }

    }

}
