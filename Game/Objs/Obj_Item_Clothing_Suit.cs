// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit : Obj_Item_Clothing {

		public double fire_resist = 373.41;
		public string blood_overlay_type = "suit";
		public string togglename = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.v_allowed = new ByTable(new object [] { typeof(Obj_Item_Weapon_Tank_Internals_EmergencyOxygen) });
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.slot_flags = 1;
			this.icon = "icons/obj/clothing/suits.dmi";
		}

		public Obj_Item_Clothing_Suit ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: clothing.dm
		public override ByTable worn_overlays( int? isinhands = null ) {
			isinhands = isinhands ?? GlobalVars.FALSE;

			ByTable _default = null;

			_default = new ByTable();

			if ( !Lang13.Bool( isinhands ) ) {
				
				if ( this.blood_DNA != null ) {
					_default.Add( new Image( "icons/effects/blood.dmi", null, "" + this.blood_overlay_type + "blood" ) );
				}
			}
			return _default;
		}

	}

}