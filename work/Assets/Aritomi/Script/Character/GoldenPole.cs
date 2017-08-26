using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenPole : Pole
{
    /// <summary>
    /// 輪っかに当たった時の処理
    /// </summary>
    protected override void UniqeHitLasso()
    {
        SEManager.main.PlayOneShot("goldenGet");
        GameManager.main.currentRingType = RING_TYPE.BIG;
        int point = m_score.Add(m_addScore);

        CreateGetScoreObject(point);

        Destroy(gameObject, 1);
    }
}
