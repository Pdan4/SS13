// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Bombcore : Obj_Item_Weapon {

		public string adminlog = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "eshield0";
			this.origin_tech = "syndicate=6;combat=5";
			this.burn_state = 0;
			this.icon = "icons/obj/assemblies.dmi";
			this.icon_state = "bombcore";
		}

		public Obj_Item_Weapon_Bombcore ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: syndicatebomb.dm
		public virtual void defuse(  ) {
			return;
		}

		// Function from file: syndicatebomb.dm
		public virtual void detonate(  ) {
			
			if ( Lang13.Bool( this.adminlog ) ) {
				GlobalFuncs.message_admins( this.adminlog );
				GlobalFuncs.log_game( this.adminlog );
			}
			GlobalFuncs.explosion( GlobalFuncs.get_turf( this ), 3, 9, 17, null, null, null, 17 );

			if ( this.loc != null && this.loc is Obj_Machinery_Syndicatebomb ) {
				GlobalFuncs.qdel( this.loc );
			}
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: syndicatebomb.dm
		public override void burn(  ) {
			this.detonate();
			base.burn();
			return;
		}

		// Function from file: syndicatebomb.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			this.detonate();
			return false;
		}

	}

}