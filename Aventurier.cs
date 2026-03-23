public  class Aventurier :Personnage
{
    
       public Arme ArmeEquipee;
    //public hero EstMort;
   // public int  PointsDeVie
    public Aventurier(string nom, int force, int pointsDeVie, ConsoleColor couleur=ConsoleColor.Blue) : base(nom, force, pointsDeVie, couleur)
    {
        this.ArmeEquipee = null ;
    }
     public override void CriDeGuerre()
    {
        Parler($"{this.Nom} pousse un cri de guerre terrifiant !");
    }

    public override void Attaquer(Personnage cible)
    {
        int degats;
        if(this.ArmeEquipee == null)
        {
            Parler(
                $"{this.Nom} attaque {cible.Nom} à mains nues."
            );
            degats = this.force;
        }
       else
        {
            Parler(
                $"{this.Nom} attaque {cible.Nom} avec {this.ArmeEquipee.Nom}"
            );
            degats = this.ArmeEquipee.Puissance;
        }
        cible.PointsDeVie=cible.PointsDeVie-degats;
        Parler(
            $"il reste à {cible.Nom} {cible.PointsDeVie} points de vie."
            );
        
    }
    public void EquiperArme(Arme arme)
    {
        this.ArmeEquipee = arme;
        Parler($"{this.Nom} équipe {arme.Nom}.");
    }
    public void Soigner(int points)
    {
        this.PointsDeVie += points;
        Parler($"{this.Nom} se soigne et gagne {points} points de vie. Il a maintenant {this.PointsDeVie} points de vie.");
    }

    
}

