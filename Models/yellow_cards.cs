namespace APIs_FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class yellow_cards
    {
        [Key]
        public int yellow_card_id { get; set; }

        public int? match_id { get; set; }

        public int? player_id { get; set; }

        public int? team_id { get; set; }

        public virtual match match { get; set; }

        public virtual player player { get; set; }

        public virtual team team { get; set; }
    }
}
