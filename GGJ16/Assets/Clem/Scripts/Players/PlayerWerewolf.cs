using System;

public class PlayerWerewolf : PlayerDefault {

	public override void Start() {
		PV = 3;
		base.Start();
		playerType = PlayerType.Werewolf;
		
	}
	public override void SpecialAction() {
		//charge
		throw new NotImplementedException();
	}
}
