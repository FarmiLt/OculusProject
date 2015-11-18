using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileLauncher : Weapon {

	public GameObject m_RadarPrefab;
	public GameObject m_MissilePrefab;
	
	private GameObject m_Radar;
	private LinkedList<GameObject> m_TargetList;

	// Use this for initialization
	void Start () {
		m_TargetList = new LinkedList<GameObject>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void PullTrigger(){
		LaunchRadar();
	}

	public override void ReleaseTrigger(){
		DeleteRadar();
		LaunchMissile();
	}

	public void AddTarget(GameObject target){
		m_TargetList.AddLast(target);
	}

	private void LaunchRadar()
	{
		if(m_TargetList.Count != 0) m_TargetList.Clear();
		Debug.Log("Create Radar");
		m_Radar = (GameObject)Instantiate(m_RadarPrefab,transform.position,transform.rotation);
		m_Radar.transform.parent = transform;
	}

	private void DeleteRadar()
	{
		Destroy(m_Radar);
	}

	private void LaunchMissile()
	{
		foreach(GameObject x in m_TargetList)
		{
			GameObject missile = (GameObject)Instantiate(m_MissilePrefab,transform.position,transform.rotation);
			missile.GetComponent<MissileLauncherBullet>().SetTarget(x);
		}
	}
}
