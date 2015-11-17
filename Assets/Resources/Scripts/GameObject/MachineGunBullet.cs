using UnityEngine;
using System.Collections;

public class MachineGunBullet : MonoBehaviour {

	public float m_BulletForce;
	public float m_LifeTime;

	// Use this for initialization
	void Start () {
		Rigidbody rig;
		rig = GetComponent<Rigidbody>();

		rig.AddForce(transform.TransformVector(new Vector3(0.0f,0.0f,m_BulletForce)));

		transform.parent = null;

		StartCoroutine("lifeTime");
	}

	public IEnumerator lifeTime()
	{
		yield return new WaitForSeconds(m_LifeTime);
		Debug.Log("DestroyBullet");
		Destroy(gameObject);
	}
}
