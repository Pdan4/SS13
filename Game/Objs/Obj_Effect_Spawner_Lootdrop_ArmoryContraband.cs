// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Spawner_Lootdrop_ArmoryContraband : Obj_Effect_Spawner_Lootdrop {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.lootdoubles = 0;
			this.loot = new ByTable()
				.Set( typeof(Obj_Item_Weapon_Gun_Projectile_Automatic_Pistol), 8 )
				.Set( typeof(Obj_Item_Weapon_Gun_Projectile_Shotgun_Automatic_Combat), 5 )
				.Set( 3, typeof(Obj_Item_Weapon_Gun_Projectile_Revolver_Mateba) )
				.Set( 4, typeof(Obj_Item_Weapon_Gun_Projectile_Automatic_Pistol_Deagle) )
			;
		}

		public Obj_Effect_Spawner_Lootdrop_ArmoryContraband ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}