public  class Gobelin : Monstres
{
    public Gobelin(string nom, int force, int pointsDeVie) : base(nom, force, pointsDeVie, ConsoleColor.Green)
    {
        
    }
     public override void CriDeGuerre()
    {
        Parler($"{this.Nom} pousse un cri de guerre terrifiant !");
    }
    
}