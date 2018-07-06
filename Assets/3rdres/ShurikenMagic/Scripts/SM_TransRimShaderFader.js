
var startStr:float=2;
var speed:float=3;
private var timeGoes:float=0;
private var currStr:float=0;
private var _renender:Renderer;

function Start()
{
    _renender = GetComponent("Renderer");
}
function Update () {

    timeGoes+=Time.deltaTime*speed*startStr;

    currStr=startStr-timeGoes;

    _renender.material.SetFloat( "_AllPower", currStr );


}

