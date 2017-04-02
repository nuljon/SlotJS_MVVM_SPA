using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SlotJS_MVVM_SPAS.Models
{
    // Models returned by MeController actions.
    public class GetViewModel
    {
        public int Credits { get; set; }
        public string PlayerName { get; set;  }
    }
}