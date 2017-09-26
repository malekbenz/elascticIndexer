namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Demandeurs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Demandeurs()
        {
            Demandes = new HashSet<Demandes>();
        }

        [Key]
        public Guid DemandeurId { get; set; }

        [Required]
        [StringLength(15)]
        public string Numero { get; set; }

        [Required]
        [StringLength(50)]
        public string NomAr { get; set; }

        [Required]
        [StringLength(50)]
        public string NomFr { get; set; }

        [Required]
        [StringLength(50)]
        public string PrenomAr { get; set; }

        [Required]
        [StringLength(50)]
        public string PrenomFr { get; set; }

        public DateTime DateNaissance { get; set; }

        [StringLength(20)]
        public string Telephone { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string AdresseAr { get; set; }

        [Required]
        [StringLength(200)]
        public string AdresseFr { get; set; }

        public Guid TypePieceIdentiteId { get; set; }

        [Required]
        [StringLength(15)]
        public string NumeroPieceIdentite { get; set; }

        public bool Gendre { get; set; }

        public short SituationFamiliale { get; set; }

        public Guid SituationServiceMilitaireId { get; set; }

        public short NombreEnfants { get; set; }

        [StringLength(15)]
        public string Nss { get; set; }

        public bool? Handicap { get; set; }

        public DateTime DateInscription { get; set; }

        public Guid CommuneNaissanceId { get; set; }

        public Guid WilayaNaissanceId { get; set; }

        public Guid PaysNaissanceId { get; set; }

        public short Civilite { get; set; }

        public DateTime PieceIdentitieDelivreeLe { get; set; }

        [Required]
        [StringLength(100)]
        public string PieceIdentitieDelivreePar { get; set; }

        [Required]
        [StringLength(6)]
        public string NumeroActeNaissance { get; set; }

        [Required]
        [StringLength(50)]
        public string PrenomPere { get; set; }

        [Required]
        [StringLength(50)]
        public string NomMere { get; set; }

        public byte NombrePersonnesACharge { get; set; }

        public Guid? EnregistrementCadreAutreDispositifId { get; set; }

        public bool IsAnonyme { get; set; }

        [Required]
        [StringLength(50)]
        public string PrenomMere { get; set; }

        public Guid QuartierId { get; set; }

        public Guid Intervenant_UserId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Demandes> Demandes { get; set; }
    }
}
