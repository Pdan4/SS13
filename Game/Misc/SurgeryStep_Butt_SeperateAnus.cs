// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_Butt_SeperateAnus : SurgeryStep_Butt {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.allowed_tools = new ByTable().Set( typeof(Obj_Item_Weapon_Scalpel), 100 ).Set( typeof(Obj_Item_Weapon_Kitchen_Utensil_Knife_Large), 75 ).Set( typeof(Obj_Item_Weapon_Shard), 50 );
			this.min_duration = 80;
			this.max_duration = 100;
		}

		// Function from file: butt.dm
		public override bool? fail_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).item( user ).str( "'s hand slips, cutting a vein in " ).item( target ).str( "'s anus with " ).the( tool ).item().str( "!</span>" ).ToString(), new Txt( "<span class='warning'>Your hand slips, cutting a vein in " ).item( target ).str( "'s anus with " ).the( tool ).item().str( "!</span>" ).ToString() );
			((Mob_Living)target).apply_damage( 50, "brute", "groin", 1 );
			return null;
		}

		// Function from file: butt.dm
		public override bool end_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			((Ent_Static)user).visible_message( new Txt( "<span class='notice'>" ).item( user ).str( " shortens the end of " ).item( target ).str( "'s anus with " ).the( tool ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You shorten " ).item( target ).str( "'s anus with " ).the( tool ).item().str( ".</span>" ).ToString() );
			target.op_stage.butt = 2;
			return false;
		}

		// Function from file: butt.dm
		public override bool begin_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			((Ent_Static)user).visible_message( new Txt().item( user ).str( " starts shortening the end of " ).item( target ).str( "'s anus with " ).the( tool ).item().str( "." ).ToString(), new Txt( "You start shortening the end of " ).item( target ).str( "'s anus with " ).the( tool ).item().str( "." ).ToString() );
			((Mob_Living_Carbon_Human)target).custom_pain( "It feels like that hamster is chewing its way out!", true );
			base.begin_step( (object)(user), (object)(target), target_zone, tool, (object)(surgery) );
			return false;
		}

		// Function from file: butt.dm
		public override int can_use( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null ) {
			return base.can_use( (object)(user), (object)(target), target_zone, tool ) != 0 && target.op_stage.butt == 1 ?1:0;
		}

		// Function from file: butt.dm
		public override bool tool_quality( Obj_Item tool = null ) {
			bool _default = false;

			_default = base.tool_quality( tool );

			if ( !Lang13.Bool( tool.is_sharp() ) ) {
				return false;
			}
			return _default;
		}

	}

}