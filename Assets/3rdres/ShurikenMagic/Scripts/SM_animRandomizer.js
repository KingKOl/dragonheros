var animList : AnimationClip[];
var actualAnim:AnimationClip;

var minSpeed:float=0.7;
var maxSpeed:float=1.5;

function Start () {
    var _animation : Animation;
    _animation = GetComponent("Animation");
    var rnd=Mathf.Round(Random.Range(0,animList.length));
    //actualAnim = animList[rnd];
    //_animation.Play(actualAnim.name);
    //_animation[actualAnim.name].speed = Random.Range(minSpeed, maxSpeed);

}