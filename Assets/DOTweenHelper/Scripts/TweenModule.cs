using DG.Tweening;
using UnityEngine;

namespace BSB.DOTWeenHelper
{
    public class TweenModule : MonoBehaviour
    {
        [Header("Tween In")]
        public bool onEnableTweenIn = true;
        public Ease tweenInEaseType = Ease.OutCubic;

        public float tweenInDuration = 1f;
        public float tweenInDelay = 0f;

        [Header("Tween Out")]
        public Ease tweenOutEaseType = Ease.OutCubic;

        public float tweenOutDuration = 0.5f;
        public float tweenOutDelay = 0f;

        [Header("Params")]
        public bool enableLoop = false;
        public LoopType loopType = LoopType.Yoyo;
        public int loops = -1;

        public bool tweenOutOnTweenInCompleted;

        public bool disableOnTweenOutCompleted;
        public GameObject disableObject;

        protected Vector3 originVal;
        protected TweenParams tParams;

        public virtual void OnEnable()
        {
            if (onEnableTweenIn)
                TweenIn();
        }

        public virtual void OnDisable()
        {
            this.transform.DOKill();
        }

        public virtual void OnDestroy()
        {
            this.transform.DOKill();
        }

        public virtual void TweenIn()
        {
            tParams = GetTweenInParams();
        }

        public virtual void TweenOut()
        {
            tParams = GetTweenOutParams();
        }

        public virtual void ResetToOrigin()
        {

        }

        public TweenParams GetTweenInParams()
        {
            tParams = new TweenParams().SetDelay(tweenInDelay).SetEase(tweenInEaseType);

            if (enableLoop)
                tParams.SetLoops(loops, loopType);

            if(tweenOutOnTweenInCompleted)
                tParams.OnComplete(TweenOut);

            return tParams;
        }

        public TweenParams GetTweenOutParams()
        {
            tParams = new TweenParams().SetDelay(tweenOutDelay).SetEase(tweenOutEaseType);

            if (disableOnTweenOutCompleted)
                tParams.OnComplete(DisableObject);

            return tParams;
        }

        public virtual void DisableObject()
        {
            if (disableObject == null)
                this.gameObject.SetActive(false);
            else
                disableObject.SetActive(false);
        }
    }


}


