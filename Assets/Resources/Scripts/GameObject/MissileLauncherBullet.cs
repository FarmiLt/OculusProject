using UnityEngine;
using System.Collections;

public class MissileLauncherBullet : MonoBehaviour {

	public float m_MoveSpeed;
	public float m_SwingSpeedRate;
	private GameObject m_Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetTarget(GameObject target)
	{
		m_Target = target;
		StartCoroutine("Track");
	}

	private IEnumerator Track()
	{
		while(true)
		{
//			Quaternion targetVec = transform.position - m_Target.transform.position;
//			Quaternion.Slerp(transform.rotation,targetVec,Time.deltaTime * m_SwingSpeedRate);
//			transform.Translate(new Vector3(0.0f,0.0f,m_MoveSpeed));
			transform.rotation = 
				Quaternion.Slerp(transform.rotation,
			                     Quaternion.LookRotation(m_Target.transform.position - transform.position),
			                     Time.deltaTime*m_SwingSpeedRate);

			transform.position += transform.forward * m_MoveSpeed;

			yield return null;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
}
