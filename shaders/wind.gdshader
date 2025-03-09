shader_type spatial;
uniform vec3 wind_direction = vec3(0,0,1);
render_mode world_vertex_coords;

void vertex() {
	VERTEX += wind_direction * sin(TIME * 0.5) * (pow(VERTEX.y, 2) / 2.0) / 10.0;
}