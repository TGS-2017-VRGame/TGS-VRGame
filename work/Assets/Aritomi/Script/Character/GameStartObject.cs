using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// わっかを当てるとゲームが開始するオブジェクト
/// </summary>
public class GameStartObject : MonoBehaviour
{
    [SerializeField]
    private Timer m_timer = null;
    [SerializeField]
    private Score m_score = null;

    private void Start()
    {
        m_score = GameObject.Find("Score").GetComponent<Score>();
    }

    private void OnTriggerEnter(Collider _col)
    {
        bool isHit = _col.transform.CompareTag("LassoObject");
        if (isHit)
        {
            GameManager.main.currentGameType = GAME_SCENE_TYPE.GAME_PLAY;
            m_timer.IsStop = false;
            m_score.Reset();
            Destroy(_col.gameObject);
        }
    }
}
