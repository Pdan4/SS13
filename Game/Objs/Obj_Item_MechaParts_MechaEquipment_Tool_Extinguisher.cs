// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Tool_Extinguisher : Obj_Item_MechaParts_MechaEquipment_Tool {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=1;engineering=2";
			this.equip_cooldown = 15;
			this.range = 3;
			this.icon_state = "mecha_exting";
		}

		// Function from file: tools.dm
		public Obj_Item_MechaParts_MechaEquipment_Tool_Extinguisher ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.create_reagents( 200 );
			((Reagents)this.reagents).add_reagent( "water", 200 );
			return;
		}

		// Function from file: tools.dm
		public override bool can_attach( Obj_Mecha M = null ) {
			
			if ( base.can_attach( M ) ) {
				
				if ( M is Obj_Mecha_Working_Ripley_Firefighter ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: tools.dm
		public override void on_reagent_change(  ) {
			return;
		}

		// Function from file: tools.dm
		public override string get_equip_info(  ) {
			return "" + base.get_equip_info() + " [" + this.reagents.total_volume + "]";
		}

		// Function from file: tools.dm
		public override bool action( dynamic target = null ) {
			dynamic o = null;
			int direction = 0;
			dynamic T = null;
			Tile T1 = null;
			Tile T2 = null;
			ByTable the_targets = null;
			int? a = null;
			Reagents R = null;
			Obj_Effect_Effect_Foam_Fire W = null;
			dynamic my_target = null;
			int? b = null;
			dynamic oldturf = null;
			dynamic W_turf = null;
			Ent_Static atm = null;
			Ent_Static M = null;
			dynamic F = null;

			
			if ( !this.action_checks( target ) || Map13.GetDistance( this.chassis, target ) > 5 ) {
				return false;
			}
			this.set_ready_state( false );

			if ( this.do_after_cooldown( target ) ) {
				
				if ( target is Obj_Structure_ReagentDispensers_Watertank && Map13.GetDistance( this.chassis, target ) <= 1 ) {
					o = target;
					((Reagents)o.reagents).trans_to( this, 200 );
					this.occupant_message( "<span class='notice'>Extinguisher refilled.</span>" );
					GlobalFuncs.playsound( this.chassis, "sound/effects/refill.ogg", 50, 1, -6 );
				} else if ( ( this.reagents.total_volume ??0) > 0 ) {
					GlobalFuncs.playsound( this.chassis, "sound/effects/extinguish.ogg", 75, 1, -3 );
					direction = Map13.GetDistance( this.chassis, target );
					T = GlobalFuncs.get_turf( target );
					T1 = Map13.GetStep( T, Num13.Rotate( direction, 90 ) );
					T2 = Map13.GetStep( T, Num13.Rotate( direction, -90 ) );
					the_targets = new ByTable(new object [] { T, T1, T2 });
					a = null;
					a = 0;

					while (( a ??0) < 5) {
						Task13.Schedule( 0, (Task13.Closure)(() => {
							R = new Reagents( 5 );
							R.my_atom = this;
							((Reagents)this.reagents).trans_to_holder( R, 1 );
							W = new Obj_Effect_Effect_Foam_Fire( GlobalFuncs.get_turf( this.chassis ), R );

							if ( !( W != null ) || !( this != null ) ) {
								return;
							}
							my_target = Rand13.PickFromTable( the_targets );
							b = null;
							b = 0;

							while (( b ??0) < 4) {
								oldturf = GlobalFuncs.get_turf( W );
								Map13.StepTowardsSimple( W, my_target );

								if ( !( W != null ) || !Lang13.Bool( W.reagents ) ) {
									return;
								}
								W_turf = GlobalFuncs.get_turf( W );
								((Reagents)W.reagents).reaction( W_turf, GlobalVars.TOUCH );

								foreach (dynamic _a in Lang13.Enumerate( W_turf, typeof(Ent_Static) )) {
									atm = _a;
									

									if ( !( W != null ) || !Lang13.Bool( W.reagents ) ) {
										return;
									}
									((Reagents)W.reagents).reaction( atm, GlobalVars.TOUCH );

									if ( ((Reagents)W.reagents).has_reagent( "water" ) ) {
										
										if ( atm is Mob_Living ) {
											M = atm;
											((dynamic)M).ExtinguishMob();
										}

										if ( atm.on_fire ) {
											atm.extinguish();
										}

										if ( atm.molten ) {
											atm.molten = false;
											atm.solidify();
										}
									}
								}
								F = Lang13.FindIn( typeof(Obj_Effect_Effect_Foam_Fire), oldturf );

								if ( !( F is Obj_Effect_Effect_Foam_Fire ) && oldturf != GlobalFuncs.get_turf( this ) ) {
									F = new Obj_Effect_Effect_Foam_Fire( GlobalFuncs.get_turf( oldturf ), W.reagents );
								}

								if ( W.loc == my_target ) {
									break;
								}
								Task13.Sleep( 2 );
								b++;
							}
							return;
						}));
						a++;
					}
				}
			}
			return true;
		}

	}

}