using UnityEngine;
using System;
namespace Isekai {
	public abstract class WeaponBobBase : MonoBehaviour {
		[Header("Base Bob Settings")]
		[Range(0.1f, 10f)] public float bobMultiplier = 1.0f;	// Use this when you have another script to lerping weapon position.
		public Transform rig;
		public LocalRotator rotator;

		protected const float INTERNAL_MULTIPLIER = 1.0f;
		protected Vector3 initPos;
		protected Vector3 initRot;
		protected float timer = 0;

		protected virtual void Start() {
			initPos = transform.localPosition;

			if(rig != null) {
				initRot = rig.localRotation.eulerAngles;
			}

			if(rotator != null) {
				rotator.enabled = true;
			}
		}

		void OnEnable() {
			if(rotator != null) {
				rotator.enabled = true;
			}
		}

		void OnDisable() {
			if(rotator != null) {
				rotator.enabled = false;
			}
		}
	}	
}