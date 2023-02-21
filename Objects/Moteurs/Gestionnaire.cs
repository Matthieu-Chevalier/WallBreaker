using Objects.Objets;
using System.Collections.Generic;

namespace Objects.Moteur
{
    public class Gestionnaire
    {
        private const int VITESSE = 10; //Vitesse de déplacement de la raquette

        private List<Balle> Balles;
        private List<Raquette> Raquettes;
        private ZoneDeJeu ZoneDeJeu;
        private List<Brique> Briques;


        //private Bonus
        //Private Brique
        /// <summary>
        /// Le gestionnaire pilote la création / suppression des objets
        /// lors de l'initailisation du jeu il créée la zone de jeu, une première balle et une première raquette
        /// Il devra implémenter une méthode : Lvl configuration qui se chargera de créer le mur de brique
        /// 
        /// Evenements à mettre en place :
        ///     0 balles -> perdre une vie
        ///     0 briques -> Niveau suivant
        ///     0 vie -> GameOver
        /// </summary>
        private Gestionnaire()
        {
            //Création de la zone de jeu:
            ZoneDeJeu = new ZoneDeJeu(10, 1000, 10,1500);//Zone de jeu à revoir: Elle doit ajuster se position à la fenêtre et empêcher la fenêtre d'être plus petite
            //Raquette Initialraquette = new Raquette()
            //Raquettes= new List<Raquette>();
            //Raquettes.Add(Initialraquette);

        }

        public void AjouterBalle(Balle balle)
        {
            Balles.Add(balle);
        }
        public void SupprimerBalle(Balle balle)
        {
            Balles.Remove(balle);
            if (Balles.Count == 0)
            { //Notifier le moteur qu'il n'y a plus de balles
            }
        }
    }
}
