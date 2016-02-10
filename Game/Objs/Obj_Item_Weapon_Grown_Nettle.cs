// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grown_Nettle : Obj_Item_Weapon_Grown {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.plantname = "nettle";
			this.damtype = "fire";
			this.force = 15;
			this.flags = 0;
			this.w_class = 2;
			this.throw_speed = 1;
			this.throw_range = 3;
			this.origin_tech = "combat=1";
			this.icon_state = "nettle";
		}

		// Function from file: grown_inedible.dm
		public Obj_Item_Weapon_Grown_Nettle ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 5, (Task13.Closure)(() => {
				this.force = Num13.Round( this.potency / 5 + 5, 1 );
				return;
			}));
			return;
		}

		// Function from file: grown_inedible.dm
		public override void changePotency( dynamic newValue = null ) {
			this.potency = Convert.ToDouble( newValue );
			this.force = Num13.Round( this.potency / 5 + 5, 1 );
			return;
		}

		// Function from file: grown_inedible.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			
			if ( !( flag == true ) ) {
				return false;
			}
			((Mob)user).delayNextAttack( 8 );

			if ( Convert.ToDouble( this.force ) > 0 ) {
				this.force -= Rand13.Int( 1, Convert.ToInt32( this.force / 3 + 1 ) );
				GlobalFuncs.playsound( this.loc, "sound/weapons/bladeslice.ogg", 50, 1, -1 );
			} else {
				GlobalFuncs.to_chat( Task13.User, "All the leaves have fallen off the nettle from violent whacking." );
				new ByTable().Set( 1, this ).Set( "force_drop", 1 ).Apply( Lang13.BindFunc( user, "drop_item" ) );
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: grown_inedible.dm
		public override bool pickup( Mob user = null ) {
			string organ = null;
			dynamic affecting = null;

			
			if ( user is Mob_Living_Carbon_Human ) {
				
				if ( !Lang13.Bool( ((dynamic)user).gloves ) ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>The nettle burns your bare hand!</span>" );
					organ = ( user.hand == true ? "l_" : "r_" ) + "arm";
					affecting = ((dynamic)user).get_organ( organ );

					if ( Lang13.Bool( affecting.take_damage( 0, this.force ) ) ) {
						((dynamic)user).UpdateDamageIcon();
					}
				}
			} else {
				((dynamic)user).take_organ_damage( 0, this.force );
				GlobalFuncs.to_chat( user, "<span class='warning'>The nettle burns your bare hand!</span>" );
			}
			return false;
		}

	}

}