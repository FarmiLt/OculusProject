﻿using UnityEngine;
using System.Collections;

public class AudioDataList {

	// BGMリストの列挙型
	// ※　必ずAudioManagerのbgmlistに追加した順に記述する
	public enum eBGMLIST{
		SAMPLE = 0,
	}


	// SEリストの列挙型
	// ※　必ずAudioManagerのselistに追加した順に記述する
	public enum eSELIST{
		APPEAR_BIOLOGICAL_WEAPON = 0,
		CHANGE_GUN_BURREL,
		EXPLOSION,
		HIT_BULLET,
		SHOT_BULLET
	}

}
