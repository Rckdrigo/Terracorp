using UnityEngine;
using System.Collections;

#region REQUIERED_COMPONENTS
#endregion
public abstract class Character2D : MonoBehaviour {
	
	#region INSIDE_INHERITED_MEMBERS
	protected float _width;
	protected float _height;
	protected bool isGrounded;
	protected Vector2 _midFrontVector;
	protected bool facingRight = true;
	public LayerMask _groundLayer;
	protected Vector2 initialPosition;
	protected SpriteRenderer sprite;
	
	[HideInInspector()]
	public bool IsGrounded;
	
	protected void Start(){
		initialPosition = transform.position;
		sprite = GetComponent<SpriteRenderer>();
	}
	
	protected void _flipH(){
		facingRight = !facingRight;
		Vector2 temp = transform.localScale;
		transform.localScale = new Vector2(temp.x * -1,temp.y);
	}
	
	protected void _flipV(){
		Vector2 temp = transform.localScale;
		transform.localScale = new Vector2(temp.x,temp.y * -1);
	}
	
	protected void Update (){		
		_resizeBoxCollider();
		IsGrounded = isOnGround();
	}
	
	#endregion 
	#region INTERNAL_PROCESS
	
	protected bool isOnGround(){
		Collider2D[] hits = Physics2D.OverlapCircleAll (transform.position, _height * 0.2f, _groundLayer);
		foreach(Collider2D ground in hits) 
			if(ground != null) 
				return true;
		return false;
	}
	
	protected void _resizeBoxCollider(){
		BoxCollider2D box = GetComponent<BoxCollider2D>();
		_width = sprite.sprite.bounds.size.x;
		_height =  sprite.sprite.bounds.size.y;
		
		Vector2 size = new Vector2(_width ,_height);
		box.size = size;
		box.offset = new Vector2(0,_height/2);		
	}
	#endregion
}