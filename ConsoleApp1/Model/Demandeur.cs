using ConsoleApp1.Model;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class VmDemandeur
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public DateTime DateInscription { get; set; }


        public string Numero { get; set; }
        public string NomAr { get; set; }
        public string PrenomAr { get; set; }
        public string Telephone { get; set; }

        public string Email { get; set; }
        public string Adresse { get; set; }
        public string AdresseAr { get; set; }

        public bool Gendre { get; set; }

        public short SituationFamiliale { get; set; }
        public short NombreEnfants { get; set; }
        public string Nss { get; set; }
        public bool? Handicap { get; set; }
        public short Civilite { get; set; }
        public DateTime PieceIdentitieDelivreeLe { get; set; }
        public string PieceIdentitieDelivreePar { get; set; }
        public string NumeroActeNaissance { get; set; }
        public byte NombrePersonnesACharge { get; set; }
        public bool IsAnonyme { get; set; }

        public Guid SituationServiceMilitaireId { get; set; }
        public Guid? EnregistrementCadreAutreDispositifId { get; set; }
        public Guid QuartierId { get; set; }

        public Guid CommuneNaissanceId { get; set; }
        public Guid WilayaNaissanceId { get; set; }
        public Guid PaysNaissanceId { get; set; }

        public IEnumerable<Metier> Metiers { get; set; }


    }
}
