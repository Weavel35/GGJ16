using System;

public class PlayerWerewolf : PlayerDefault {

	public override void Start() {
		base.Start();
		playerType = PlayerType.Werewolf;
		PV = 3;
	}
	public override void SpecialAction() {
		//charge
		throw new NotImplementedException();
	}
}
