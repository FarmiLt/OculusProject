using UnityEngine;
using System.Collections;

public class PlanaRadar : MonoBehaviour {

	public float m_DeploymentSpeed;
	public float m_MoveSpeedParSec;
	public float m_LifeTime;
	
	private Vector3  m_MoveVec;

	private BoxCollider m_Collider;
	// Use this for initialization
	void Start () {
		Debug.Log("Launch Radar");
		m_Collider = transform.GetComponent<BoxCollider>();

		m_MoveVec = transform.TransformVector(new Vector3(0.0f,0.0f,m_MoveSpeedParSec));

		StartCoroutine("lifeTime");
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_Collider.size += new Vector3(Time.deltaTime * m_DeploymentSpeed,Time.deltaTime * m_DeploymentSpeed,0.0f);
		transform.position += m_MoveVec * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Collision! other tag:" + other.gameObject.tag);
		if(other.gameObject.tag == "Enemy")
		{
			GameObject target = other.gameObject;
			transform.parent.GetComponent<MissileLauncher>().AddTarget(target);
		}
	}

	private IEnumerator lifeTime()
	{
		yield return new WaitForSeconds(m_LifeTime);
		//Debug.Log("DestroyBullet");
		Destroy(gameObject);
	}
}
