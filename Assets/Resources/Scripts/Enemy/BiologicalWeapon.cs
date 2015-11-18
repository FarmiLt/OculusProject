using UnityEngine;
using System.Collections;

public class BiologicalWeapon : BaseEnemy {

	[SerializeField]
	private float arrivalTime_secs;

	private bool isKnockingBack = false;

	private GameObject target;
	private Vector3 startPos;
	private Vector3 endPos;
	private float movingTime = 0;

	private delegate void Execute ();
	Execute execute;

	// Use this for initialization
	void Start () {
		// 生成された時にプレイヤーの方向を向いておく
		target = GameObject.FindWithTag ("Player");
		transform.LookAt (target.transform);
		transform.rotation = Quaternion.Euler (new Vector3 (0, transform.rotation.eulerAngles.y, 0));
		startPos = transform.position;
		endPos = new Vector3 (target.transform.position.x, 0, target.transform.position.z);
		execute = Stop;
		Instantiate (Resources.Load ("Prefabs/Effect/Particle_SandSmoke"), transform.position, transform.rotation);
		AudioManager.Instance.PlaySE ((int)AudioDataList.eSELIST.APPEAR_BIOLOGICAL_WEAPON, GetComponent<AudioSource> ());
		StartCoroutine (Appear ());
	}
	
	// Update is called once per frame
	void Update () {
		// 実行用関数
		execute ();
	}

	private IEnumerator Appear () {
		// 出現アニメーションの終了を待機して歩行モーションに遷移
		yield return new WaitForSeconds (1.733f);
		GetComponent<Animator> ().SetBool ("isRunning", true);
		execute = Move;
	}

	private IEnumerator KnockBack () {
		// ノックバックアニメーションの終了を待機して歩行モーションに遷移
		yield return new WaitForSeconds (0.567f);
		GetComponent<Animator> ().SetBool ("isHitDamage", false);
		isKnockingBack = false;
		execute = Move;
	}

	private IEnumerator Die () {
		// 死亡アニメーションの終了を待機して自らを消す
		yield return new WaitForSeconds (0.7f);
		GameObject particle = Instantiate (Resources.Load ("Prefabs/Effect/Particle_Explosion"), transform.position, transform.rotation) as GameObject;
		AudioManager.Instance.PlaySE ((int)AudioDataList.eSELIST.EXPLOSION, particle.GetComponent<AudioSource> ());
		Destroy (this.gameObject);
	}

	private void Stop () {
	}

	private void Move () {
		// ターゲット方向へ移動
		transform.position = Vector3.Lerp (startPos, endPos, movingTime / arrivalTime_secs);
		movingTime += Time.deltaTime;

		// ターゲット方向へ移動を終了したら攻撃
		if (movingTime >= arrivalTime_secs) {
			GetComponent<Animator> ().SetBool ("isRunning", false);
			execute = Attack;
		}
	}

	private void Attack () {
	}

	void OnTriggerEnter (Collider col) {
		// 弾丸を撃ち込まれた場合
		if (col.tag == "Bullet") {
			// ノックバック中であっても弾丸を撃ちこまれている間はダメージを受ける
			hitPoint -= 1;

			GameObject particle = Instantiate (Resources.Load ("Prefabs/Effect/Particle_FlyingEnemyBlood"), col.transform.position, transform.rotation) as GameObject;
			particle.transform.rotation = Quaternion.AngleAxis (180, particle.transform.up);

			AudioManager.Instance.PlaySE ((int)AudioDataList.eSELIST.HIT_BULLET, GetComponent<AudioSource> ());

			// 死亡時の処理
			if (hitPoint <= 0) {
				// 死亡していた場合は衝突判定を行わない
				GetComponent<SphereCollider> ().enabled = false;
				StartCoroutine (Die ());
				GetComponent<Animator> ().SetBool ("isKilled", true);
				execute = Stop;
			}
			// ノックバック時の処理
			else if (!isKnockingBack) {
				isKnockingBack = true;
				StartCoroutine (KnockBack ());
				GetComponent<Animator> ().SetBool ("isHitDamage", true);
				execute = Stop;
			}
		}

		if (col.tag == "Player") {
			GameObject particle = Instantiate (Resources.Load ("Prefabs/Effect/Particle_Explosion"), transform.position, transform.rotation) as GameObject;
			AudioManager.Instance.PlaySE ((int)AudioDataList.eSELIST.EXPLOSION, particle.GetComponent<AudioSource> ());
			Destroy (this.gameObject);
		}
	}
}
