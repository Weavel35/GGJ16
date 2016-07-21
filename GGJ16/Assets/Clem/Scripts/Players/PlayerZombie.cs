using System;

public class PlayerZombie : PlayerDefault {

	public override void Start() {
		PV = 5;

		base.Start();
		playerType = PlayerType.Zombie;
		
		speed = 0.80f;
		atk_dist = 2;
		atk_pow = 2;

	}

	public override void SpecialAction() {
		//explosion
		throw new NotImplementedException();
	}
}
