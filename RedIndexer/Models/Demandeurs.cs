namespace RedIndexer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Demandeurs
    {
        [StringLength(15)]
        public string id { get; set; }

        [StringLength(15)]
        public string Numero { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }

        [StringLength(50)]
        public string Prenom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateNaissance { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(55)]
        public string CommNaiss { get; set; }

        [StringLength(202)]
        public string WilNaiss { get; set; }

        [StringLength(6)]
        public string NumeroActeNaissance { get; set; }

        [StringLength(202)]
        public string ComResidance { get; set; }

        [StringLength(202)]
        public string WilResidance { get; set; }

        [StringLength(210)]
        public string AgenceDemandeur { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateDebutContrat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFinContrat { get; set; }

        [StringLength(205)]
        public string PayNaiss { get; set; }
    }
}
