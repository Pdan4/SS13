// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Spellbook_Oneuse_Fireball : Obj_Item_Weapon_Spellbook_Oneuse {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.spell = typeof(Spell_Targeted_Projectile_Dumbfire_Fireball);
			this.spellname = "fireball";
			this.icon_state = "bookfireball";
		}

		public Obj_Item_Weapon_Spellbook_Oneuse_Fireball ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: spellbook.dm
		public override void recoil( dynamic user = null ) {
			base.recoil( (object)(user) );
			GlobalFuncs.explosion( user.loc, -1, 0, 2, 3, 0 );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}