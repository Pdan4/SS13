// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ArtifactEffect_Robohurt : ArtifactEffect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.effecttype = "robohurt";
		}

		// Function from file: unknown_effect_robohurt.dm
		public ArtifactEffect_Robohurt ( dynamic location = null ) : base( (object)(location) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.effect_type = Convert.ToInt32( Rand13.Pick(new object [] { 3, 4 }) );
			return;
		}

		// Function from file: unknown_effect_robohurt.dm
		public override bool DoEffectPulse( dynamic holder = null ) {
			Mob_Living_Silicon_Robot M = null;

			
			if ( this.holder != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( this.holder, this.effectrange ), typeof(Mob_Living_Silicon_Robot) )) {
					M = _a;
					
					GlobalFuncs.to_chat( M, "<span class='warning'>SYSTEM ALERT: Structural damage inflicted by energy pulse!</span>" );
					M.adjustBruteLoss( 10 );
					M.adjustFireLoss( 10 );
					M.updatehealth();
				}
				return true;
			}
			return false;
		}

		// Function from file: unknown_effect_robohurt.dm
		public override bool DoEffectAura( dynamic holder = null ) {
			Mob_Living_Silicon_Robot M = null;

			
			if ( this.holder != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( this.holder, this.effectrange ), typeof(Mob_Living_Silicon_Robot) )) {
					M = _a;
					

					if ( Rand13.PercentChance( 10 ) ) {
						GlobalFuncs.to_chat( M, "<span class='warning'>SYSTEM ALERT: Harmful energy field detected!</span>" );
					}
					M.adjustBruteLoss( 1 );
					M.adjustFireLoss( 1 );
					M.updatehealth();
				}
				return true;
			}
			return false;
		}

		// Function from file: unknown_effect_robohurt.dm
		public override bool DoEffectTouch( dynamic user = null ) {
			dynamic R = null;

			
			if ( Lang13.Bool( user ) ) {
				
				if ( user is Mob_Living_Silicon_Robot ) {
					R = user;
					GlobalFuncs.to_chat( R, "<span class='warning'>Your systems report severe damage has been inflicted!</span>" );
					((Mob_Living)R).adjustBruteLoss( Rand13.Int( 10, 50 ) );
					((Mob_Living)R).adjustFireLoss( Rand13.Int( 10, 50 ) );
					return true;
				}
			}
			return false;
		}

	}

}