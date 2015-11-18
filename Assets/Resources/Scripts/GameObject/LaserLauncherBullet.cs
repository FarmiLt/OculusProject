using UnityEngine;
using System.Collections;

public class LaserLauncherBullet : MonoBehaviour {

	public float m_MoveSpeedParSec;
	public float m_LifeTime;

	private Vector3  m_MoveVec;

	// Use this for initialization
	void Start () {
		m_MoveVec = transform.TransformVector(new Vector3(0.0f,0.0f,m_MoveSpeedParSec));

		 StartCoroutine("lifeTime");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += m_MoveVec * Time.deltaTime;
	}

	private IEnumerator lifeTime()
	{
		yield return new WaitForSeconds(m_LifeTime);
		//Debug.Log("DestroyBullet");
		Destroy(gameObject);
	}
}
