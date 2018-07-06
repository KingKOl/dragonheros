
var color1:Color=Color(0.6, 0.6, 0.6, 1);
var color2:Color=Color(0.4, 0.4, 0.4, 1);
var unifiedColor:boolean=true;
private var ColR:float;
private var ColG:float;
private var ColB:float;
private var ColA:float;
private var _renender:Renderer;
function Start () {
    if(unifiedColor==false)
    {
        ColR=Random.Range(color1.r, color2.r);
        ColG=Random.Range(color1.g, color2.g);
        ColB=Random.Range(color1.b, color2.b);
        ColA=Random.Range(color1.a, color2.a);
    }

    if (unifiedColor==true)
    {
        var rnd:float = Random.value;

        ColR=Mathf.Min(color1.r,color2.r)+(Mathf.Abs(color1.r-color2.r)*rnd);
        ColG=Mathf.Min(color1.g,color2.g)+(Mathf.Abs(color1.g-color2.g)*rnd);
        ColB=Mathf.Min(color1.b,color2.b)+(Mathf.Abs(color1.b-color2.b)*rnd);


    }
    _renender = GetComponent("Renderer");

    //renderer.material.SetColor("_TintColor", Color(ColR,ColG,ColB,ColA));
    _renender.material.color=Color(ColR,ColG,ColB,ColA);

}