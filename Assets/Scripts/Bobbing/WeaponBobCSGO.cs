using UnityEngine;

namespace Isekai{
	// hehe
	public class WeaponBobCSGO : WeaponBobBase {
		new private const float INTERNAL_MULTIPLIER = 6.0f;
		private const float FRONT_BOB_MULTIPLIER = 100;
		private float frontBobMovementAmount = 0.0f;

		[Header("Custom Settings")]
		public bool stopped = false;


		[Header("CSGO Style Bob Settings")]
		[Range(0.05f, 0.1f)] public float maxFrontBobMovement = 0.05f;
		[HideInInspector] public float frontBobbingSpeed = 1.0f;
		[Range(0.05f, 0.3f)] public float sideBobbingSpeed = 0.15f;
		[Range(0.02f, 0.04f)] public float sideBobbingAmount = 0.02f;

		void Update() {
			if(stopped == true)
            {
				return;
            }
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");
			float aHorz = Mathf.Abs(horizontal);
			float aVert = Mathf.Abs(vertical);

			bool movingX = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);
			bool movingY = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

			if((movingX && aVert > 0) || (movingY && aHorz > 0)) {
				float moveSpeed = Mathf.Clamp(aVert + aHorz, 0, 1) * frontBobbingSpeed * FRONT_BOB_MULTIPLIER;

				frontBobMovementAmount += moveSpeed;
			}
			else {
				frontBobMovementAmount -= frontBobbingSpeed * FRONT_BOB_MULTIPLIER;

				if(frontBobMovementAmount < 0) {
					frontBobMovementAmount = 0;
				}
			}

			frontBobMovementAmount *= Time.deltaTime;

			float xMovement = 0.0f;
			float yMovement = 0.0f;

			Vector3 calcPosition = initPos;

			if (aHorz == 0 && aVert == 0) {
				timer = 0.0f;
			}
			else {
				xMovement = Mathf.Sin(timer);
				yMovement = -Mathf.Abs(Mathf.Abs(xMovement) - 1);

				timer += sideBobbingSpeed;
				
				if (timer > Mathf.PI * 2) {
					timer = timer - (Mathf.PI * 2);
				}
			}

			float totalMovement = Mathf.Clamp(aVert + aHorz, 0, 1);

			if (xMovement != 0) {
				xMovement = xMovement * totalMovement;
				calcPosition.x = initPos.x + xMovement * sideBobbingAmount;
			}
			else {
				calcPosition.x = initPos.x;
			}

			if (yMovement != 0) {
				yMovement = yMovement * totalMovement;
				calcPosition.y = initPos.y + yMovement * sideBobbingAmount * 2;
			}
			else {
				calcPosition.y = initPos.y;
			}

			float totalFrontX = Mathf.Clamp(frontBobMovementAmount, -maxFrontBobMovement, maxFrontBobMovement);
			float totalFrontY = Mathf.Clamp(frontBobMovementAmount, -maxFrontBobMovement, maxFrontBobMovement);
			float totalFrontZ = Mathf.Clamp(frontBobMovementAmount, -maxFrontBobMovement, maxFrontBobMovement);

			calcPosition.x += totalFrontX;
			calcPosition.y -= totalFrontY;
			calcPosition.z -= totalFrontZ;

			transform.localPosition = Vector3.Lerp(transform.localPosition, calcPosition, Time.deltaTime * INTERNAL_MULTIPLIER * bobMultiplier);
		}
	}
}