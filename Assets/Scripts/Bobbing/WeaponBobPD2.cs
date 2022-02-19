using UnityEngine;
using System;
namespace Isekai {
	public class WeaponBobPD2 : WeaponBobBase {
		new private const float INTERNAL_MULTIPLIER = 6.0f;

		[Header("PD2 Style Bob Settings")]
		[Range(0.1f, 0.3f)] public float bobbingSpeed = 0.1f;
		[Range(0.05f, 0.3f)] public float bobbingAmount = 0.05f;
		[Range(0.1f, 1f)] public float bobbingRotationAmount = 0.75f;
		[Range(0.1f, 2f)] public float vertBobbingAmount = 1.0f;

		void Update() {
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");
			float aHorz = Mathf.Abs(horizontal);
			float aVert = Mathf.Abs(vertical);

			float xMovement = 0.0f;
			float yMovement = 0.0f;
			float yRotation = 0.0f;

			Vector3 calcPosition = transform.localPosition; 
			float rot = transform.localRotation.eulerAngles.y;

			if (aHorz == 0 && aVert == 0) {
				timer = 0.0f;
			}
			else {
				xMovement = Mathf.Sin(timer);
				yMovement = -Mathf.Abs(Mathf.Abs(xMovement) - 1);
				yRotation = Mathf.Sin(timer);

				timer += bobbingSpeed;
				
				if (timer > Mathf.PI * 2) {
					timer = timer - (Mathf.PI * 2);
				}
			}

			float totalMovement = Mathf.Clamp(aVert + aHorz, 0, 1);

			if (yMovement != 0) {
				yMovement = yMovement * totalMovement;
				calcPosition.y = initPos.y + yMovement * bobbingAmount * vertBobbingAmount;
			}
			else {
				calcPosition.y = initPos.y;
			}

			if(yRotation != 0) {
				rot = initRot.y + yRotation * totalMovement * bobbingRotationAmount;
			}
			else {
				rot = initRot.y;
			}

			rotator.angleChanges = rot;
			transform.localPosition = Vector3.Lerp(transform.localPosition, calcPosition, Time.deltaTime * INTERNAL_MULTIPLIER);
		}
	}

}