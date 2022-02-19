using UnityEngine;

namespace Isekai {
	public class WeaponBobModernator2 : WeaponBobBase {
		[Header("MD2 Style Bob Settings")]
		[Range(0.1f, 0.3f)] public float bobbingSpeed = 0.1f;
		[Range(0.02f, 0.5f)] public float bobbingAmount = 0.02f;
		[Range(1f, 5f)] public float bobbingRotationAmount = 3f;

		void Update() {
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");
			float aHorz = Mathf.Abs(horizontal);
			float aVert = Mathf.Abs(vertical);

			float xMovement = 0.0f;
			float yMovement = 0.0f;

			Vector3 calcPosition = transform.localPosition; 

			if (aHorz == 0 && aVert == 0) {
				timer = 0.0f;
			}
			else {
				xMovement = Mathf.Sin(timer);
				yMovement =-Mathf.Abs(Mathf.Abs(xMovement) - 1);

				timer += bobbingSpeed;
				
				if (timer > Mathf.PI * 2) {
					timer = timer - (Mathf.PI * 2);
				}
			}

			float totalMovement = Mathf.Clamp(aVert + aHorz, 0, 1) * 1.5f;

			if (xMovement != 0) {
				xMovement = xMovement * totalMovement;
				calcPosition.x = initPos.x + xMovement * bobbingAmount;
			}
			else {
				calcPosition.x = initPos.x;
			}

			if (yMovement != 0) {
				yMovement = yMovement * totalMovement;
				calcPosition.y = initPos.y + yMovement * bobbingAmount;
			}
			else {
				calcPosition.y = initPos.y;
			}

			transform.localPosition = Vector3.Lerp(transform.localPosition, calcPosition, Time.deltaTime * INTERNAL_MULTIPLIER * bobMultiplier);
		}
	}
}