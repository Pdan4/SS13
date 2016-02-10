// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Spellbook_Oneuse_Forcewall : Obj_Item_Weapon_Spellbook_Oneuse {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.spell = typeof(Spell_AoeTurf_Conjure_Forcewall);
			this.spellname = "forcewall";
			this.icon_state = "bookforcewall";
		}

		public Obj_Item_Weapon_Spellbook_Oneuse_Forcewall ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: spellbook.dm
		public override void recoil( dynamic user = null ) {
			Obj_Structure_Closet_Statue S = null;

			base.recoil( (object)(user) );
			GlobalFuncs.to_chat( user, "<span class='warning'>You suddenly feel very solid!</span>" );
			S = new Obj_Structure_Closet_Statue( user.loc, user );
			S.timer = 30;
			user.drop_item();
			return;
		}

	}

}