extends Node2D

@onready var character2 = $Char2
@onready var BaseChar = $CharacterBody2D
@onready var collision1 = $CharacterBody2D/CollisionShape2D
@onready var collision2 = $Char2/CollisionShape2D
@onready var camera1 = $CharacterBody2D/Camera2D
@onready var camera2 = $Char2/Camera2D

# Called when the node enters the scene tree for the first time.a
func _ready() -> void:
	character2.set_physics_process(false)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass
		
		

func changeCharacter1():
	BaseChar.show()
	BaseChar.set_physics_process(true)
	
	
	character2.set_physics_process(false)
	collision1.hide()

	camera1.make_current()
func changeCharacter2():
	character2.show()
	character2.set_physics_process(true)
	
	
	BaseChar.set_physics_process(false)
	collision2.hide()
	
	camera2.make_current()
