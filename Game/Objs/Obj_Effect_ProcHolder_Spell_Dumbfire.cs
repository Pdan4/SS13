// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Dumbfire : Obj_Effect_ProcHolder_Spell {

		public string projectile_type = "";
		public bool activate_on_collision = true;
		public string proj_icon = "icons/obj/projectiles.dmi";
		public string proj_icon_state = "spell";
		public string proj_name = "a spell projectile";
		public bool proj_trail = false;
		public bool proj_trail_lifespan = false;
		public string proj_trail_icon = "icons/obj/wizard.dmi";
		public string proj_trail_icon_state = "trail";
		public string proj_type = "/obj/effect/proc_holder/spell";
		public bool proj_insubstantial = false;
		public bool proj_trigger_range = true;
		public int? proj_lifespan = 100;
		public int proj_step_delay = 1;

		public Obj_Effect_ProcHolder_Spell_Dumbfire ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: dumbfire.dm
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			thearea = thearea ?? Task13.User;

			dynamic target = null;
			dynamic projectile = null;
			Type projectile_type = null;
			Ent_Static current_loc = null;
			int? i = null;
			dynamic L = null;
			Obj_Effect_Overlay trail = null;

			this.playMagSound();

			foreach (dynamic _a in Lang13.Enumerate( targets )) {
				target = _a;
				
				Task13.Schedule( 0, (Task13.Closure)(() => {
					projectile = null;

					if ( this.proj_type is string ) {
						projectile_type = Lang13.FindClass( this.proj_type );
						projectile = Lang13.Call( projectile_type, thearea );
					}

					if ( this.proj_type is Obj_Effect_ProcHolder_Spell ) {
						projectile = new Obj_Effect_ProcHolder_Spell_Targeted_Trigger( thearea );
						projectile.linked_spells.Add( this.proj_type );
					}
					projectile.icon = this.proj_icon;
					projectile.icon_state = this.proj_icon_state;
					projectile.dir = Map13.GetDistance( projectile, target );
					projectile.name = this.proj_name;
					current_loc = thearea.loc;
					projectile.loc = current_loc;
					i = null;
					i = 0;

					while (( i ??0) < ( this.proj_lifespan ??0)) {
						
						if ( !Lang13.Bool( projectile ) ) {
							break;
						}

						if ( this.proj_insubstantial ) {
							projectile.loc = Map13.GetStep( projectile, Convert.ToInt32( projectile.dir ) );
						} else {
							Map13.Step( projectile, Convert.ToInt32( projectile.dir ) );
						}

						if ( projectile.loc == current_loc || i == this.proj_lifespan ) {
							((Obj_Effect_ProcHolder_Spell)projectile).cast( current_loc, null, thearea );
							break;
						}
						L = Lang13.FindIn( typeof(Mob_Living), Map13.FetchInRange( this.proj_trigger_range, projectile ) - thearea );

						if ( Lang13.Bool( L ) && Convert.ToInt32( L.stat ) != 2 ) {
							((Obj_Effect_ProcHolder_Spell)projectile).cast( L.loc, null, thearea );
							break;
						}

						if ( this.proj_trail && Lang13.Bool( projectile ) ) {
							Task13.Schedule( 0, (Task13.Closure)(() => {
								
								if ( Lang13.Bool( projectile ) ) {
									trail = new Obj_Effect_Overlay( projectile.loc );
									trail.icon = this.proj_trail_icon;
									trail.icon_state = this.proj_trail_icon_state;
									trail.density = false;
									Task13.Schedule( this.proj_trail_lifespan ?1:0, (Task13.Closure)(() => {
										GlobalFuncs.qdel( trail );
										return;
									}));
								}
								return;
							}));
						}
						current_loc = projectile.loc;
						Task13.Sleep( this.proj_step_delay );
						i++;
					}

					if ( Lang13.Bool( projectile ) ) {
						GlobalFuncs.qdel( projectile );
					}
					return;
				}));
			}
			return false;
		}

		// Function from file: dumbfire.dm
		public override void choose_targets( Mob user = null ) {
			user = user ?? Task13.User;

			dynamic T = null;
			int? i = null;
			Tile new_turf = null;

			T = GlobalFuncs.get_turf( user );
			i = null;
			i = 1;

			while (( i ??0) < ( this.range ??0)) {
				new_turf = Map13.GetStep( T, user.dir );

				if ( new_turf.density ) {
					break;
				}
				T = new_turf;
				i++;
			}
			this.perform( new ByTable(new object [] { T }), null, user );
			return;
		}

	}

}