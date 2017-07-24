using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SteamVR用のコントローラー
/// 有冨勇帆
/// </summary>
//public class ViveController : MyController {

	//[SerializeField]
	//private GameObject m_head = null;
	//[SerializeField]
	//private GameObject m_connectPoint = null;

	//private SteamVR_TrackedController m_trackedController = null;
    
 //   protected void UniqeAwake()
 //   {
 //       m_trackedController = gameObject.GetComponent<SteamVR_TrackedController>();

 //       if (m_trackedController == null)
 //       {
 //           Debug.Log("コントローラーを生成しました");
 //           m_trackedController = gameObject.AddComponent<SteamVR_TrackedController>();
 //       }

 //       Rigidbody rigidbody = GetComponent<Rigidbody>() ?? gameObject.AddComponent<Rigidbody>();
 //       rigidbody.isKinematic = true;
 //   }

	//public bool IsGrab()
	//{
	//	if (m_trackedController == null) {
	//		return false;
	//	}

	//	return m_trackedController.triggerPressed;
 //   }

 //   public bool IsSpawnPointResetButton() {
	//	if (m_trackedController == null) {
	//		return false;
	//	}

	//	return m_currentMenuPressed && !m_previouseMenuPressed;
	//}

	//public bool IsLassoSpawnButton()
	//{
	//	if (m_trackedController == null) {
	//		return false;
	//	}

	//	return m_currentPadPressed && !m_previousePadPressed;
	//}

	//public Transform GetTransform()
	//{
	//	return gameObject.transform;
	//}

	//public Vector3 Velocity()
	//{
	//	return (m_currentPos - m_previousePos);
	//}

 //   public float ThrowPower()
 //   {
 //       return Vector3.Distance(m_currentPos, m_previousePos)
 //   }
//}
