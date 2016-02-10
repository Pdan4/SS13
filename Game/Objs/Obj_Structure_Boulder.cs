// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Boulder : Obj_Structure {

		public bool busy = false;
		public double excavation_level = 0;
		public Geosample geological_data = null;
		public ArtifactFind artifact_find = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/mining.dmi";
			this.icon_state = "boulder1";
		}

		// Function from file: artifact.dm
		public Obj_Structure_Boulder ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.icon_state = "boulder" + Rand13.Int( 1, 4 );
			this.excavation_level = Rand13.Int( 5, 50 );
			return;
		}

		// Function from file: artifact.dm
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			bool _default = false;

			Ent_Static H = null;
			Ent_Static R = null;
			Ent_Static M = null;

			_default = base.Bumped( AM, (object)(yes) );

			if ( AM is Mob_Living_Carbon_Human ) {
				H = AM;

				if ( ((Mob)H).get_active_hand() is Obj_Item_Weapon_Pickaxe ) {
					this.attackby( ((Mob)H).get_active_hand(), H );
				} else if ( ((Mob)H).get_inactive_hand() is Obj_Item_Weapon_Pickaxe ) {
					this.attackby( ((Mob)H).get_inactive_hand(), H );
				}
			} else if ( AM is Mob_Living_Silicon_Robot ) {
				R = AM;

				if ( ((dynamic)R).module_active is Obj_Item_Weapon_Pickaxe ) {
					this.attackby( ((dynamic)R).module_active, R );
				}
			} else if ( AM is Obj_Mecha ) {
				M = AM;

				if ( ((dynamic)M).selected is Obj_Item_MechaParts_MechaEquipment_Tool_Drill ) {
					((dynamic)M).selected.action( this );
				}
			}
			return _default;
		}

		// Function from file: artifact.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic C = null;
			dynamic C2 = null;
			dynamic P = null;
			dynamic P2 = null;
			dynamic spawn_type = null;
			dynamic O = null;
			dynamic X = null;

			
			if ( a is Obj_Item_Device_CoreSampler ) {
				this.geological_data.artifact_distance = Rand13.Int( -100, 100 ) / 100;
				this.geological_data.artifact_id = this.artifact_find.artifact_id;
				C = a;
				((Obj_Item_Device_CoreSampler)C).sample_item( this, b );
				return null;
			}

			if ( a is Obj_Item_Device_DepthScanner ) {
				C2 = a;
				((Obj_Item_Device_DepthScanner)C2).scan_atom( b, this );
				return null;
			}

			if ( a is Obj_Item_Device_MeasuringTape ) {
				P = a;
				((Ent_Static)b).visible_message( "<span class='notice>" + b + " extends " + P + " towards " + this + ".", "<span class='notice'>You extend " + P + " towards " + this + ".</span></span>" );
				this.busy = true;

				if ( GlobalFuncs.do_after( b, this, 40 ) ) {
					this.busy = false;
					GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>" ).icon( P ).str( " " ).item( this ).str( " has been excavated to a depth of " ).item( this.excavation_level * 2 ).str( "cm.</span>" ).ToString() );
				} else {
					this.busy = false;
				}
				return null;
			}

			if ( a is Obj_Item_Weapon_Pickaxe ) {
				P2 = a;

				if ( !( ( P2.diggables & 1 ) != 0 ) ) {
					return null;
				}
				GlobalFuncs.to_chat( b, "<span class='rose'>You start " + P2.drill_verb + " " + this + ".</span>" );
				this.busy = true;

				if ( GlobalFuncs.do_after( b, this, P2.digspeed ) ) {
					this.busy = false;
					GlobalFuncs.to_chat( b, "<span class='notice'>You finish " + P2.drill_verb + " " + this + ".</span>" );
					this.excavation_level += Convert.ToDouble( P2.excavation_amount );

					if ( this.excavation_level > 100 ) {
						this.visible_message( new Txt( "<span class='danger'>" ).The( this ).item().str( " suddenly crumbles away.</span>" ).ToString() );
						GlobalFuncs.to_chat( b, new Txt( "<span class='rose'>" ).The( this ).item().str( " has disintegrated under your onslaught, any secrets it was holding are long gone.</span>" ).ToString() );
						GlobalFuncs.returnToPool( this );
						return null;
					}

					if ( Rand13.PercentChance( ((int)( this.excavation_level )) ) ) {
						this.visible_message( "<span class='danger'>" + this + " suddenly crumbles away.</span>" );

						if ( this.artifact_find != null ) {
							spawn_type = this.artifact_find.artifact_find_type;
							O = Lang13.Call( spawn_type, GlobalFuncs.get_turf( this ) );

							if ( O is Obj_Machinery_Artifact ) {
								X = O;

								if ( Lang13.Bool( X.my_effect ) ) {
									X.my_effect.artifact_id = this.artifact_find.artifact_id;
								}
							}
						} else {
							GlobalFuncs.to_chat( b, "<span class='notice'>" + this + " has been whittled away under your careful excavation, but there was nothing of interest inside.</span>" );
						}
						GlobalFuncs.returnToPool( this );
					}
				} else {
					this.busy = false;
				}
				return null;
			}
			return null;
		}

		// Function from file: artifact.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			this.geological_data = null;
			this.artifact_find = null;
			return null;
		}

	}

}