using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Application.DTOs
{
    public class ChangeLibelleRequest
    {
        /// <summary> 
        /// Nouveau libelle du produit. 
        /// Doit être strictement remplis. 
        /// </summary> 
        [Required]
        public string NewLibelle { get; set; }
        //"reason": "augmentation fournisseur",
        //"effectiveDate": "2026-01-01"
    }
}
