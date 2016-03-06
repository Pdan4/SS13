// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Welding : Obj_Item_Clothing_Head {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags_cover = 20;
			this.item_state = "welding";
			this.materials = new ByTable().Set( "$metal", 1750 ).Set( "$glass", 400 );
			this.flash_protect = 2;
			this.tint = 2;
			this.armor = new ByTable().Set( "melee", 10 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.flags_inv = 15;
			this.action_button_name = "Toggle Welding Helmet";
			this.visor_flags_inv = 15;
			this.icon_state = "welding";
		}

		public Obj_Item_Clothing_Head_Welding ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: misc_special.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.toggle();
			return null;
		}

		// Function from file: misc_special.dm
		[Verb]
		[VerbInfo( name: "Adjust welding helmet", group: "Object", access: VerbAccess.InUserContents, range: 127 )]
		public void toggle(  ) {
			this.weldingvisortoggle();
			return;
		}

	}

}