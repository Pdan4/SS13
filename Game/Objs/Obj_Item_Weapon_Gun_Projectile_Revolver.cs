// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Revolver : Obj_Item_Weapon_Gun_Projectile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mag_type = typeof(Obj_Item_AmmoBox_Magazine_Internal_Cylinder);
			this.icon_state = "revolver";
		}

		// Function from file: revolver.dm
		public Obj_Item_Weapon_Gun_Projectile_Revolver ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( !( this.magazine is Obj_Item_AmmoBox_Magazine_Internal_Cylinder ) ) {
				this.verbs.Remove( typeof(Obj_Item_Weapon_Gun_Projectile_Revolver).GetMethod( "spin" ) );
			}
			return;
		}

		// Function from file: revolver.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( "" + this.get_ammo( false, false ) + " of those are live rounds." );
			return 0;
		}

		// Function from file: revolver.dm
		public override double get_ammo( bool? countchambered = null, bool? countempties = null ) {
			countchambered = countchambered ?? false;
			countempties = countempties ?? true;

			double boolets = 0;

			boolets = 0;

			if ( Lang13.Bool( this.chambered ) && countchambered == true ) {
				boolets++;
			}

			if ( Lang13.Bool( this.magazine ) ) {
				boolets += ((Obj_Item_AmmoBox_Magazine)this.magazine).ammo_count( countempties );
			}
			return boolets;
		}

		// Function from file: revolver.dm
		public override dynamic can_shoot(  ) {
			return this.get_ammo( false, false );
		}

		// Function from file: revolver.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			int num_unloaded = 0;
			dynamic CB = null;

			num_unloaded = 0;
			this.chambered = null;

			while (this.get_ammo() > 0) {
				CB = null;
				CB = ((Obj_Item_AmmoBox)this.magazine).get_round( false );

				if ( Lang13.Bool( CB ) ) {
					CB.loc = GlobalFuncs.get_turf( this.loc );
					((Ent_Static)CB).SpinAnimation( 10, 1 );
					CB.update_icon();
					num_unloaded++;
				}
			}

			if ( num_unloaded != 0 ) {
				user.WriteMsg( new Txt( "<span class='notice'>You unload " ).item( num_unloaded ).str( " shell" ).s().str( " from " ).item( this ).str( ".</span>" ).ToString() );
			} else {
				user.WriteMsg( "<span class='warning'>" + this + " is empty!</span>" );
			}
			return null;
		}

		// Function from file: revolver.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic _default = null;

			dynamic num_loaded = null;

			_default = base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}
			num_loaded = ((Ent_Static)this.magazine).attackby( A, user, _params, true );

			if ( Lang13.Bool( num_loaded ) ) {
				user.WriteMsg( new Txt( "<span class='notice'>You load " ).item( num_loaded ).str( " shell" ).s().str( " into " ).the( this ).item().str( ".</span>" ).ToString() );
				A.update_icon();
				this.update_icon();
				this.chamber_round( false );
			}

			if ( this.unique_rename ) {
				
				if ( A is Obj_Item_Weapon_Pen ) {
					this.rename_gun( user );
				}
			}
			return _default;
		}

		// Function from file: revolver.dm
		public override bool process_chamber( bool? eject_casing = null, bool? empty_chamber = null ) {
			return base.process_chamber( false, true );
		}

		// Function from file: revolver.dm
		public override void shoot_with_empty_chamber( dynamic user = null ) {
			base.shoot_with_empty_chamber( (object)(user) );
			this.chamber_round( true );
			return;
		}

		// Function from file: revolver.dm
		public override void chamber_round( bool? spin = null ) {
			spin = spin ?? true;

			
			if ( spin == true ) {
				this.chambered = ((Obj_Item_AmmoBox)this.magazine).get_round( true );
			} else {
				this.chambered = this.magazine.stored_ammo[1];
			}
			return;
		}

		// Function from file: revolver.dm
		[Verb]
		[VerbInfo( name: "Spin Chamber", desc: "Click to spin your revolver's chamber.", group: "Object" )]
		public void spin(  ) {
			Mob M = null;
			dynamic C = null;

			M = Task13.User;

			if ( M.stat != 0 || !( Map13.GetDistance( M, this ) <= 1 ) ) {
				return;
			}

			if ( this.magazine is Obj_Item_AmmoBox_Magazine_Internal_Cylinder ) {
				C = this.magazine;
				((Obj_Item_AmmoBox_Magazine_Internal_Cylinder)C).spin();
				this.chamber_round( false );
				Task13.User.visible_message( "" + Task13.User + " spins " + this + "'s chamber.", "<span class='notice'>You spin " + this + "'s chamber.</span>" );
			} else {
				this.verbs.Remove( typeof(Obj_Item_Weapon_Gun_Projectile_Revolver).GetMethod( "spin" ) );
			}
			return;
		}

	}

}