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
	
	[HideInInspector()]
	public bool IsGrounded;
	
	protected void _flipH(){
		facingRight = !facingRight;
		Vector2 temp = transform.localScale;
		transform.localScale = new Vector2(temp.x*-1,temp.y);
	}
	
	protected void _flipV(){
		Vector2 temp = transform.localScale;
		transform.localScale = new Vector2(temp.x,temp.y*-1);
	}
	
	protected void Update (){
		_width =  renderer.bounds.size.x;
		_height =  renderer.bounds.size.y;
		
		_resizeBoxCollider();
		IsGrounded = isOnGround();
	}
	
	#endregion 
	#region INTERNAL_PROCESS
	protected void _resizeBoxCollider(Vector2 colliderOffset,Vector2 colliderScale){
		switch (collider2D.GetType ().ToString ()) {
		case "UnityEngine.BoxCollider2D":
			BoxCollider2D box = GetComponent<BoxCollider2D>();
			Vector2 size = new Vector2(_width * colliderScale.x,_height * colliderScale.y);
			box.size = size;
			box.center = new Vector2(0 + colliderOffset.x,_height/2 + colliderOffset.y);
			break;
			
		case "UnityEngine.CircleCollider2D":
			CircleCollider2D circle = GetComponent<CircleCollider2D>();
			circle.radius = _width>=_height?_width : _height;
			break;
			
		default:
			break;
		}
		
	}
	
	protected bool isOnGround(){
		Collider2D[] hits = Physics2D.OverlapCircleAll (transform.position, _height * 0.2f, _groundLayer);
		foreach(Collider2D ground in hits) 
			if(ground != null) 
				return true;
		return false;
	}
	
	protected void _resizeBoxCollider(){
		switch (collider2D.GetType ().ToString ()) {
		case "UnityEngine.BoxCollider2D":
			BoxCollider2D box = GetComponent<BoxCollider2D>();
			Vector2 size = new Vector2(_width,_height);
			box.size = size;
			box.center = new Vector2(0,_height/2);
			break;
			
		case "UnityEngine.CircleCollider2D":
			CircleCollider2D circle = GetComponent<CircleCollider2D>();
			circle.radius = _width>=_height?_width : _height;
			break;
			
		default:
			break;
		}
		
	}
	#endregion
}