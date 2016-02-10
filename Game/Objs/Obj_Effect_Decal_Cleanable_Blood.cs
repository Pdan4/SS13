// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Decal_Cleanable_Blood : Obj_Effect_Decal_Cleanable {

		public string base_icon = "icons/effects/blood.dmi";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.random_icon_states = new ByTable(new object [] { "mfloor1", "mfloor2", "mfloor3", "mfloor4", "mfloor5", "mfloor6", "mfloor7" });
			this.amount = 5;
			this.counts_as_blood = true;
			this.transfers_dna = true;
			this.absorbs_types = new ByTable(new object [] { typeof(Obj_Effect_Decal_Cleanable_Blood), typeof(Obj_Effect_Decal_Cleanable_Blood_Drip), typeof(Obj_Effect_Decal_Cleanable_Blood_Writing) });
			this.icon = "icons/effects/blood.dmi";
			this.icon_state = "mfloor1";
		}

		public Obj_Effect_Decal_Cleanable_Blood ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: humans.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			Icon blood = null;

			
			if ( this.basecolor == "rainbow" ) {
				this.basecolor = "#" + Rand13.PickFromTable( new ByTable(new object [] { "FF0000", "FF7F00", "FFFF00", "00FF00", "0000FF", "4B0082", "8F00FF" }) );
			}
			this.color = this.basecolor;
			blood = new Icon( this.base_icon, this.icon_state, this.dir );
			blood.Blend( this.basecolor, 2 );
			this.icon = blood;
			return null;
		}

		// Function from file: humans.dm
		public override dynamic cultify(  ) {
			return null;
		}

		// Function from file: humans.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			this.blood_DNA = null;
			this.virus2 = null;
			return null;
		}

	}

}