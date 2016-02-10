// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_RobotModule_Medical : Obj_Item_Weapon_RobotModule {

		// Function from file: robot_modules.dm
		public Obj_Item_Weapon_RobotModule_Medical ( dynamic R = null ) : base( (object)(R) ) {
			Obj_Item_Stack_Medical_Advanced_BruisePack B = null;
			Obj_Item_Stack_Medical_Advanced_Ointment O = null;
			Obj_Item_Stack_Medical_Splint S = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.modules.Add( new Obj_Item_Device_Healthanalyzer( this ) );
			this.modules.Add( new Obj_Item_Weapon_ReagentContainers_Borghypo( this ) );
			this.modules.Add( new Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Large_Cyborg( this, this ) );
			this.modules.Add( new Obj_Item_Weapon_ReagentContainers_Dropper_Robodropper( this ) );
			this.modules.Add( new Obj_Item_Weapon_ReagentContainers_Syringe( this ) );
			this.modules.Add( new Obj_Item_Weapon_Storage_Bag_Chem( this ) );
			this.modules.Add( new Obj_Item_Weapon_Extinguisher_Mini( this ) );
			this.modules.Add( new Obj_Item_Weapon_Scalpel( this ) );
			this.modules.Add( new Obj_Item_Weapon_Hemostat( this ) );
			this.modules.Add( new Obj_Item_Weapon_Retractor( this ) );
			this.modules.Add( new Obj_Item_Weapon_CircularSaw( this ) );
			this.modules.Add( new Obj_Item_Weapon_Cautery( this ) );
			this.modules.Add( new Obj_Item_Weapon_Bonegel( this ) );
			this.modules.Add( new Obj_Item_Weapon_Bonesetter( this ) );
			this.modules.Add( new Obj_Item_Weapon_FixOVein( this ) );
			this.modules.Add( new Obj_Item_Weapon_Surgicaldrill( this ) );
			this.modules.Add( new Obj_Item_Weapon_Revivalprod( this ) );
			this.modules.Add( new Obj_Item_Weapon_Crowbar( this ) );
			this.emag = new Obj_Item_Weapon_ReagentContainers_Spray( this );
			this.sensor_augs = new ByTable(new object [] { "Medical", "Disable" });
			((Reagents)this.emag.reagents).add_reagent( "pacid", 250 );
			this.emag.name = "Polyacid spray";
			B = new Obj_Item_Stack_Medical_Advanced_BruisePack( this );
			B.max_amount = 10;
			B.amount = 10;
			this.modules.Add( B );
			O = new Obj_Item_Stack_Medical_Advanced_Ointment( this );
			O.max_amount = 10;
			O.amount = 10;
			this.modules.Add( O );
			S = new Obj_Item_Stack_Medical_Splint( this );
			S.max_amount = 10;
			S.amount = 10;
			this.modules.Add( S );
			return;
		}

		// Function from file: robot_modules.dm
		public override void respawn_consumable( Ent_Static R = null ) {
			ByTable what = null;
			dynamic T = null;
			dynamic O = null;

			what = new ByTable(new object [] { typeof(Obj_Item_Stack_Medical_Advanced_BruisePack), typeof(Obj_Item_Stack_Medical_Advanced_Ointment), typeof(Obj_Item_Stack_Medical_Splint) });

			foreach (dynamic _a in Lang13.Enumerate( what )) {
				T = _a;
				

				if ( !Lang13.Bool( Lang13.FindIn( T, this.modules ) ) ) {
					this.modules.Remove( null );
					O = Lang13.Call( T, this );

					if ( O is Obj_Item_Stack_Medical ) {
						O.max_amount = 15;
					}
					this.modules.Add( O );
					O.amount = 1;
				}
			}
			return;
		}

	}

}