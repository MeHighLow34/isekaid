using UnityEngine;

namespace Isekai {
	public class WeaponBobCSS : WeaponBobBase {
		[Header("CSS Style Bob Settings")]
		[Range(0.1f, 0.3f)] public float bobbingSpeed = 0.1f;
		[Range(0.1f, 0.3f)] public float bobbingAmount = 0.1f;

		void Update () {
			float xMovement = 0.0f;
			float yMovement = 0.0f;
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");
			float aHorz = Mathf.Abs(horizontal);
			float aVert = Mathf.Abs(vertical);

			Vector3 calcPosition = transform.localPosition; 

			if (aHorz == 0 && aVert == 0) {
				timer = 0.0f;
			}
			else {
				xMovement = Mathf.Sin(timer) / 2;
				yMovement = -Mathf.Sin(timer);

				bool isRunning = Input.GetKey(KeyCode.LeftShift);

				if(isRunning) {
					timer += bobbingSpeed * 1.2f;
					xMovement *= 1.5f;
					yMovement *= 1.5f;
				}
				else {
					timer += bobbingSpeed;
				}
				
				if (timer > Mathf.PI * 2) {
					timer = timer - (Mathf.PI * 2);
				}
			}

			float totalMovement = Mathf.Clamp(aVert + aHorz, 0, 1);

			if (xMovement != 0) {
				calcPosition.x = initPos.x + xMovement * totalMovement * bobbingAmount;
			}
			else {
				calcPosition.x = initPos.x;
			}
			
			if (yMovement != 0) {
				calcPosition.y = initPos.y + yMovement * totalMovement * bobbingAmount;
			}
			else {
				calcPosition.y = initPos.y;
			}

			transform.localPosition = Vector3.Lerp(transform.localPosition, calcPosition, Time.deltaTime * INTERNAL_MULTIPLIER * bobMultiplier);
		}
	}
}