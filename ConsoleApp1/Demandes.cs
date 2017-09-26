namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Demandes
    {
        [Key]
        public Guid DemandeId { get; set; }

        public Guid DemandeurId { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(17)]
        public string Numero { get; set; }

        public Guid StructureId { get; set; }

        public short PorteeCompensation { get; set; }

        public DateTime? DateAnnulationPrevue { get; set; }

        public DateTime? DateCloture { get; set; }

        public bool ClotureeParSysteme { get; set; }

        public DateTime? DateCloturePrevue { get; set; }

        [StringLength(200)]
        public string CauseCloture { get; set; }

        public short Mobilite { get; set; }

        public Guid NatureDemandeId { get; set; }

        public Guid TypeContratId { get; set; }

        public Guid? DispositifId { get; set; }

        public Guid MetierPrincipalId { get; set; }

        public bool Actuelle { get; set; }

        public short Etat { get; set; }

        public int Anciennete { get; set; }

        public decimal? SalaireSouhaite { get; set; }

        public Guid UserId { get; set; }

        public DateTime? DateMiseEnInstancePrevue { get; set; }

        public Guid? FonctionActuelleId { get; set; }

        public bool IsSatisfaite { get; set; }

        public virtual Demandeurs Demandeurs { get; set; }
    }
}
