// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Map_Spawner_Engi_Materials : Obj_Map_Spawner_Engi {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.amount = 2;
			this.chance = 75;
			this.toSpawn = new ByTable(new object [] { 
				new ObjectInitializer(typeof(Obj_Item_Stack_Sheet_Glass_Glass)).Set( "amount", 50 ), 
				new ObjectInitializer(typeof(Obj_Item_Stack_Sheet_Glass_Rglass)).Set( "amount", 50 ), 
				new ObjectInitializer(typeof(Obj_Item_Stack_Sheet_Glass_Plasmaglass)).Set( "amount", 50 ), 
				new ObjectInitializer(typeof(Obj_Item_Stack_LightW)).Set( "amount", 50 ), 
				new ObjectInitializer(typeof(Obj_Item_Stack_Sheet_Mineral_Plastic)).Set( "amount", 50 ), 
				new ObjectInitializer(typeof(Obj_Item_Stack_Sheet_Metal)).Set( "amount", 50 ), 
				new ObjectInitializer(typeof(Obj_Item_Stack_Sheet_Plasteel)).Set( "amount", 50 ), 
				new ObjectInitializer(typeof(Obj_Item_Stack_Sheet_Wood)).Set( "amount", 50 ), 
				new ObjectInitializer(typeof(Obj_Item_Stack_Rods)).Set( "amount", 50 ), 
				new ObjectInitializer(typeof(Obj_Item_Stack_Tile_Grass)).Set( "amount", 50 )
			 });
			this.icon_state = "engi_materials";
		}

		public Obj_Map_Spawner_Engi_Materials ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}