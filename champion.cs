public abstract class Personnage
{
    public string Nom{get;set;}
    public int force{get;set;}
    
    public ConsoleColor Color { get; set; }
    public abstract void CriDeGuerre();
    
    public Personnage(string nom, int force, int pointsDeVie,ConsoleColor Color = ConsoleColor.White)
    {
        this.Nom=nom;
        this.force=force;
        this.PointsDeVie=pointsDeVie;
        this.Color = Color;
    }
    public void Parler(string texete)
    {
        Console.ForegroundColor = this.Color;
        Console.WriteLine($"{this.Nom} dit : {texete}");
        Console.ResetColor();
    }

    protected int _pointsDeVie;

    public int PointsDeVie
    {
        get {return _pointsDeVie; }
        set
        {
            if ( value < 0) _pointsDeVie=0;
            else _pointsDeVie=value;  
        }
    }

    public bool EstMort
    {
        get
        {
            return this.PointsDeVie <= 0; 
        }
    }

    public  virtual void Attaquer(Personnage cible)
    {
        Parler($"{this.Nom} attaque {cible.Nom} !");
        cible.PointsDeVie-=this.force;
        Parler($"{cible.Nom} a maintenant {cible.PointsDeVie} points de vie.");
    }

    public void SeReposer()
    {
        Parler($"{this.Nom} se repose...");
        this.PointsDeVie+=5;
    
    }
}