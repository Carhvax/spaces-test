using DG.Tweening;
using System;
using UnityEngine;

public static class DOTweenHelper
{

    public static Sequence RemoveBlockFromList(RuleBlockItem block, Action complete)
    {
        return DOTween
            .Sequence()
            .Append(block.transform.DOPunchScale(Vector3.one * .25f, .1f))
            .Append(block.transform.DOScale(Vector3.one * .25f, .15f))
            .OnComplete(() => complete?.Invoke());
    }

    public static Sequence AddBlock(RuleBlockItem block, Action complete)
    {
        return DOTween
           .Sequence()
           .Append(block.transform.DOPunchScale(Vector3.one * .1f, .2f))
           .OnComplete(() => complete?.Invoke());
    }
}
