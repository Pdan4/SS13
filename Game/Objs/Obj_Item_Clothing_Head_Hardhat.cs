// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Hardhat : Obj_Item_Clothing_Head {

		public int brightness_on = 4;
		public bool on = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "hardhat0_yellow";
			this.light_power = 1.5;
			this._color = "yellow";
			this.armor = new ByTable().Set( "melee", 30 ).Set( "bullet", 5 ).Set( "laser", 20 ).Set( "energy", 10 ).Set( "bomb", 20 ).Set( "bio", 10 ).Set( "rad", 20 );
			this.action_button_name = "Toggle Helmet Light";
			this.siemens_coefficient = 081;
			this.icon_state = "hardhat0_yellow";
		}

		public Obj_Item_Clothing_Head_Hardhat ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: hardhat.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.on = !this.on;
			this.icon_state = "hardhat" + this.on + "_" + this._color;
			this.item_state = "hardhat" + this.on + "_" + this._color;

			if ( this.on ) {
				this.set_light( this.brightness_on );
			} else {
				this.set_light( 0 );
			}
			return null;
		}

	}

}