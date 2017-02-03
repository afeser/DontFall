import bpy
import math

class MakeTorus(bpy.types.Operator):
    bl_idname="mesh.make_torus"
    bl_label="Turn to Torus"
    
    revolution_count=5 # How many revolutions will be held
    render_count=10 # Variable specifying reality !!!10000 locks the computer
    radius=2 # Torus radius
    screw_height=1.5 # How much it will be moved upward for each turn
    object_radius=1 # Default object radius. To ensure the script will work properlyi make sure that the value with the given object.
    
    current_angle=0
        
    def execute(self,context):
        move_value=2*math.pi*self.radius/self.render_count
        rotate_value=2*math.pi/self.render_count
        
        # Extrude
        bpy.ops.mesh.extrude_region_move(MESH_OT_extrude_region={"mirror":False}, TRANSFORM_OT_translate={"value":(0, 0, 0), "constraint_axis":(False, False, False), "constraint_orientation":'GLOBAL', "mirror":False, "proportional":'DISABLED', "proportional_edit_falloff":'SMOOTH', "proportional_size":1, "snap":False, "snap_target":'CLOSEST', "snap_point":(0, 0, 0), "snap_align":False, "snap_normal":(0, 0, 0), "gpencil_strokes":False, "texture_space":False, "remove_on_cancel":False, "release_confirm":False})
        # Move
        bpy.ops.mesh.extrude_region_move(MESH_OT_extrude_region={"mirror":False}, TRANSFORM_OT_translate={"value":(move_value*math.cos(self.current_angle), move_value*math.sin(self.current_angle), 0), "constraint_axis":(False, False, False), "constraint_orientation":'GLOBAL', "mirror":False, "proportional":'DISABLED', "proportional_edit_falloff":'SMOOTH', "proportional_size":1, "snap":False, "snap_target":'CLOSEST', "snap_point":(0, 0, 0), "snap_align":False, "snap_normal":(0, 0, 0), "gpencil_strokes":False, "texture_space":False, "remove_on_cancel":False, "release_confirm":False})
        # Move in Z direction
        bpy.ops.mesh.extrude_region_move(MESH_OT_extrude_region={"mirror":False}, TRANSFORM_OT_translate={"value":( 0, 0, self.screw_height/self.render_count), "constraint_axis":(False, False, False), "constraint_orientation":'GLOBAL', "mirror":False, "proportional":'DISABLED', "proportional_edit_falloff":'SMOOTH', "proportional_size":1, "snap":False, "snap_target":'CLOSEST', "snap_point":(0, 0, 0), "snap_align":False, "snap_normal":(0, 0, 0), "gpencil_strokes":False, "texture_space":False, "remove_on_cancel":False, "release_confirm":False})
        # Rotate
        bpy.ops.transform.rotate(value=rotate_value, axis=(0, 0, 1), constraint_axis=(False, False, True), constraint_orientation='GLOBAL', mirror=False, proportional='DISABLED', proportional_edit_falloff='SMOOTH', proportional_size=1)
        
        self.current_angle+=2*math.pi/self.render_count
        return {"FINISHED"}
        
    def invoke(self,context,execute):
        # Z-axis rotation
        bpy.ops.transform.rotate(value=-math.atan(self.screw_height/self.object_radius), axis=(0, 1, 0), constraint_axis=(False, True, False), constraint_orientation='GLOBAL', mirror=False, proportional='DISABLED', proportional_edit_falloff='SMOOTH', proportional_size=1)
        
        for x in range(self.render_count*self.revolution_count-1):
            self.execute(context)
        return self.execute(context)
        
        
        
bpy.utils.register_class(MakeTorus)