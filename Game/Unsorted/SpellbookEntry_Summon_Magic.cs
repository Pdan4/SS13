// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpellbookEntry_Summon_Magic : SpellbookEntry_Summon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Summon Magic";
			this.category = "Challenges";
			this.desc = "Share the wonders of magic with the crew and show them why they aren't to be trusted with it at the same time.";
			this.cost = 0;
			this.log_name = "SU";
		}

		// Function from file: spellbook.dm
		public override bool Buy( Mob user = null, Obj_Item_Weapon_Spellbook book = null ) {
			GlobalFuncs.feedback_add_details( "wizard_spell_learned", this.log_name );
			GlobalFuncs.rightandwrong( true, user, 0 );
			book.uses += 1;
			this.active = true;
			GlobalFuncs.playsound( GlobalFuncs.get_turf( user ), "sound/magic/CastSummon.ogg", 50, 1 );
			user.WriteMsg( "<span class='notice'>You have cast summon magic and gained an extra charge for your spellbook.</span>" );
			return true;
		}

		// Function from file: spellbook.dm
		public override bool IsAvailible(  ) {
			
			if ( !Lang13.Bool( GlobalVars.ticker.mode ) ) {
				return false;
			}
			return GlobalVars.ticker.mode.name != "ragin' mages" && !GlobalVars.config.no_summon_magic;
		}

	}

}