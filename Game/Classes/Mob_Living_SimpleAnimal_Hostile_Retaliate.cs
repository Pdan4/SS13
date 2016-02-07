// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Retaliate : Mob_Living_SimpleAnimal_Hostile {

		public ByTable enemies = new ByTable();

		public Mob_Living_SimpleAnimal_Hostile_Retaliate ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: retaliate.dm
		public override bool adjustHealth( dynamic amount = null ) {
			base.adjustHealth( (object)(amount) );

			if ( this.stat == 0 ) {
				this.Retaliate();
			}
			return false;
		}

		// Function from file: retaliate.dm
		public virtual bool Retaliate(  ) {
			ByTable around = null;
			Ent_Dynamic A = null;
			Ent_Dynamic M = null;
			bool faction_check = false;
			dynamic F = null;
			Ent_Dynamic M2 = null;
			Mob_Living_SimpleAnimal_Hostile_Retaliate H = null;
			bool retaliate_faction_check = false;
			dynamic F2 = null;

			around = Map13.FetchInView( this.vision_range, this );

			foreach (dynamic _b in Lang13.Enumerate( around, typeof(Ent_Dynamic) )) {
				A = _b;
				

				if ( A == this ) {
					continue;
				}

				if ( A is Mob_Living ) {
					M = A;
					faction_check = false;

					foreach (dynamic _a in Lang13.Enumerate( this.faction )) {
						F = _a;
						

						if ( Lang13.Bool( ((dynamic)M).faction.Contains( F ) ) ) {
							faction_check = true;
							break;
						}
					}

					if ( faction_check && this.attack_same != 0 || !faction_check ) {
						this.enemies.Or( M );
					}
				} else if ( A is Obj_Mecha ) {
					M2 = A;

					if ( Lang13.Bool( ((dynamic)M2).occupant ) ) {
						this.enemies.Or( M2 );
						this.enemies.Or( ((dynamic)M2).occupant );
					}
				}
			}

			foreach (dynamic _d in Lang13.Enumerate( around, typeof(Mob_Living_SimpleAnimal_Hostile_Retaliate) )) {
				H = _d;
				
				retaliate_faction_check = false;

				foreach (dynamic _c in Lang13.Enumerate( this.faction )) {
					F2 = _c;
					

					if ( Lang13.Bool( H.faction.Contains( F2 ) ) ) {
						retaliate_faction_check = true;
						break;
					}
				}

				if ( retaliate_faction_check && !( this.attack_same != 0 ) && !( H.attack_same != 0 ) ) {
					H.enemies.Or( this.enemies );
				}
			}
			return false;
		}

		// Function from file: retaliate.dm
		public override ByTable ListTargets(  ) {
			ByTable see = null;

			
			if ( !( this.enemies.len != 0 ) ) {
				return new ByTable();
			}
			see = base.ListTargets();
			see.And( this.enemies );
			return see;
		}

		// Function from file: retaliate.dm
		public override dynamic Found( dynamic A = null ) {
			dynamic L = null;
			dynamic M = null;

			
			if ( A is Mob_Living ) {
				L = A;

				if ( !Lang13.Bool( L.stat ) ) {
					return L;
				} else {
					this.enemies.Remove( L );
				}
			} else if ( A is Obj_Mecha ) {
				M = A;

				if ( Lang13.Bool( M.occupant ) ) {
					return A;
				}
			}
			return null;
		}

	}

}