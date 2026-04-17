using System.Threading.Channels;

public abstract class Sort
 {
 public string Nom { get; set; }
 public int ManaCost { get; set; }
 public Sort(string nom, int manaCost)
 {
     this.Nom = nom;
     this.ManaCost = manaCost;
 }
  public abstract void lancer(Sorcier lanceur, Personnage cible);
}