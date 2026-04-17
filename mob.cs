public  class Monstres :  Personnage
{
    public Monstres(string nom, int force, int PointsDeVie, ConsoleColor couleur) : base(nom, force, PointsDeVie, couleur)
    {

    }
    public override void CriDeGuerre()
    {
        Parler($"{this.Nom} pousse un cri de guerre terrifiant !");
    }
    
}
 