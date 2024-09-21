using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackArea : MonoBehaviour
{

    private int damage = 3;
    private GameObject slime;
    private Rigidbody2D slimeRigidbody2D;
    private CapsuleCollider2D slimeHitbox;
    private PolygonCollider2D area;
    private SpriteRenderer slimeSprite;
    
}
