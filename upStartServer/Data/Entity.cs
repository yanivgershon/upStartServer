using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace upStartServer.Data
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public long Date { get; set; }
        public bool IsPrivate { get; set; }

        internal void update(Entity entity)
        {
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.Amount = entity.Amount;
            this.Date = entity.Date;
            this.IsPrivate = entity.IsPrivate;
        }
    }
}