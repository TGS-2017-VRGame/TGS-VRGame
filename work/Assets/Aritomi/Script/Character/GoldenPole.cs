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
        m_score.AddScore(m_addScore);

        if (HasGetScore(m_getScoreObject))
        {
            GetScore getScore =
                Instantiate(
                    m_getScoreObject,
                    transform.position,
                    transform.rotation * Quaternion.Euler(0, m_scoreRotOffset, 0)).GetComponent<GetScore>();

            getScore.SetScore(m_addScore);
        }

        Destroy(gameObject, 1);
    }
}
