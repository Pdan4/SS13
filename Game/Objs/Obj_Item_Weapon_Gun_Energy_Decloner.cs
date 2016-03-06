// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Decloner : Obj_Item_Weapon_Gun_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "combat=5;materials=4;powerstorage=3";
			this.ammo_type = new ByTable(new object [] { typeof(Obj_Item_AmmoCasing_Energy_Declone) });
			this.ammo_x_offset = 1;
			this.icon_state = "decloner";
		}

		public Obj_Item_Weapon_Gun_Energy_Decloner ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: special.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			Obj_Item_AmmoCasing_Energy shot = null;

			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );
			shot = this.ammo_type[this.select];

			if ( Convert.ToDouble( this.power_supply.charge ) > ( shot.e_cost ??0) ) {
				this.overlays.Add( "decloner_spin" );
			}
			return false;
		}

	}

}