var Gradient : Gradient;
var timeMultiplier:float=1;

private var curColor:Color;
private var time:float=0;
private var _renender:Renderer;


function Start ()
{
    _renender = GetComponent("Renderer");
    _renender.material.SetColor ("_TintColor", Color(0, 0, 0, 0));
}


function Update () {
    time+=Time.deltaTime*timeMultiplier;
    curColor=Gradient.Evaluate(time);


    _renender.material.SetColor ("_TintColor", curColor);
}

