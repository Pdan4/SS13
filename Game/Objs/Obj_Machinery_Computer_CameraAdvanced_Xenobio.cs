// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_CameraAdvanced_Xenobio : Obj_Machinery_Computer_CameraAdvanced {

		public Action_Innate_SlimePlace slime_place_action = new Action_Innate_SlimePlace();
		public Action_Innate_SlimePickUp slime_up_action = new Action_Innate_SlimePickUp();
		public Action_Innate_FeedSlime feed_slime_action = new Action_Innate_FeedSlime();
		public Action_Innate_MonkeyRecycle monkey_recycle_action = new Action_Innate_MonkeyRecycle();
		public ByTable stored_slimes = new ByTable();
		public int max_slimes = 5;
		public double monkeys = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.networks = new ByTable(new object [] { "SS13" });
			this.off_action = new Action_Innate_CameraOff_Xenobio();
			this.icon_screen = "slime_comp";
			this.icon_keyboard = "rd_key";
		}

		public Obj_Machinery_Computer_CameraAdvanced_Xenobio ( dynamic location = null, dynamic C = null ) : base( (object)(location), (object)(C) ) {
			
		}

		// Function from file: xenobio_camera.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( !( a is Mob_Living_Carbon_Human ) ) {
				return null;
			}
			return base.attack_hand( (object)(a), b, c );
		}

		// Function from file: xenobio_camera.dm
		public override void GrantActions( dynamic user = null ) {
			this.off_action.target = user;
			this.off_action.Grant( user );
			this.jump_action.target = user;
			this.jump_action.Grant( user );
			this.slime_up_action.target = this;
			this.slime_up_action.Grant( user );
			this.slime_place_action.target = this;
			this.slime_place_action.Grant( user );
			this.feed_slime_action.target = this;
			this.feed_slime_action.Grant( user );
			this.monkey_recycle_action.target = this;
			this.monkey_recycle_action.Grant( user );
			return;
		}

		// Function from file: xenobio_camera.dm
		public override void CreateEye(  ) {
			this.eyeobj = new Mob_Camera_AiEye_Remote_Xenobio();
			this.eyeobj.loc = GlobalFuncs.get_turf( this );
			this.eyeobj.origin = this;
			this.eyeobj.visible_icon = true;
			this.eyeobj.icon = "icons/obj/abductor.dmi";
			this.eyeobj.icon_state = "camera_target";
			return;
		}

	}

}