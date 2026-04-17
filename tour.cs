public  class Dragons : Monstres
{
    public int Puissancesouffle { get; set; }
    public Dragons(string nom) : base(nom, 50, 500,ConsoleColor.Red)
    {
        //specifique au dragon
        Puissancesouffle = 100;
    }
     public override void CriDeGuerre()
    {
        Parler($"{this.Nom} pousse un cri de guerre terrifiant !");
    }
    
}