// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Blob_ElectromagneticWeb : Reagent_Blob {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Electromagnetic Web";
			this.id = "electromagnetic_web";
			this.description = "will do low burn damage and EMP targets, but is somewhat fragile.";
			this.shortdesc = "will do low burn damage and EMP targets.";
			this.color = "#83ECEC";
			this.blobbernaut_message = "lashes";
			this.message = "The blob lashes you";
			this.message_living = ", and you hear a faint buzzing";
		}

		// Function from file: blob_reagents.dm
		public override void death_reaction( Obj_Effect_Blob B = null, dynamic cause = null ) {
			
			if ( !( cause == null ) ) {
				GlobalFuncs.empulse( B.loc, 2, 3 );
			}
			return;
		}

		// Function from file: blob_reagents.dm
		public override dynamic damage_reaction( Obj_Effect_Blob B = null, double original_health = 0, dynamic damage = null, dynamic damage_type = null, dynamic cause = null ) {
			return damage * 1.2;
		}

		// Function from file: blob_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			reac_volume = base.reaction_mob( (object)(M), method, reac_volume, show_message, (object)(touch_protection), O );
			((Ent_Static)M).emp_act( 2 );

			if ( Lang13.Bool( M ) ) {
				((Mob_Living)M).apply_damage( ( reac_volume ??0) * 0.6, "fire" );
			}
			return 0;
		}

	}

}