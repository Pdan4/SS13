// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Codebreaker : Obj_Item_Device {

		public bool operation = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "electronic";
			this.force = 5;
			this.w_class = 2;
			this.throwforce = 5;
			this.throw_range = 15;
			this.throw_speed = 3;
			this.starting_materials = new ByTable().Set( "$iron", 50 ).Set( "$glass", 20 );
			this.w_type = 5;
			this.melt_temperature = 1687;
			this.origin_tech = "magnets=3;programming=6;syndicate=7";
			this.slot_flags = 512;
			this.icon_state = "codebreaker";
		}

		public Obj_Item_Device_Codebreaker ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: codebreaker.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			dynamic loc_user = null;
			dynamic loc_nuke = null;
			int crackduration = 0;
			int delayfraction = 0;
			int? i = null;

			
			if ( A is Obj_Machinery_Nuclearbomb && !this.operation ) {
				this.operation = true;
				this.icon_state = "codebreaker-working";
				GlobalFuncs.to_chat( user, "<span class='notice'>Stand still and keep the " + this + " in your hands while it cracks the " + A + "'s activation code.</span>" );
				loc_user = GlobalFuncs.get_turf( user );
				loc_nuke = GlobalFuncs.get_turf( A );
				crackduration = Rand13.Int( 100, 300 );
				delayfraction = Num13.Floor( crackduration / 6 );
				i = null;
				i = 0;

				while (( i ??0) < 6) {
					Task13.Sleep( delayfraction );

					if ( !Lang13.Bool( user ) || Lang13.Bool( user.stat ) || user.weakened != 0 || Lang13.Bool( user.stunned ) || !( user.loc == loc_user ) || !( A.loc == loc_nuke ) || !( user.l_hand == this ) && !( user.r_hand == this ) ) {
						GlobalFuncs.to_chat( user, "<span class='warning'>You need to stand still for the whole duration of the code breaking for the device to work, and keep it in one of your hands.</span>" );
						this.icon_state = "codebreaker";
						this.operation = false;
						return false;
					}
					i++;
				}
				this.icon_state = "codebreaker-found";
				GlobalFuncs.playsound( this, "sound/machines/info.ogg", 50, 1 );
				GlobalFuncs.to_chat( user, "It worked! The code is \"" + A.r_code + "\"." );
				Task13.Sleep( 20 );
				this.icon_state = "codebreaker";
				this.operation = false;
			} else {
				return base.afterattack( (object)(A), (object)(user), flag, (object)(_params), struggle );
			}
			return false;
		}

	}

}