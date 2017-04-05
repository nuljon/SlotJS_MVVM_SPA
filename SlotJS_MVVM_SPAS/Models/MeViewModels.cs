using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SlotJS_MVVM_SPAS.Models
{
    // Models returned by MeController actions.
    public class GetViewModel
    {

        public string userid { get; set; }
        public int Credits { get; set; }
        public string PlayerName { get; set;  }
    }
    public class PutModel
    {
        public string id { get; set; }
        public int cred { get; set; }        
    }
}