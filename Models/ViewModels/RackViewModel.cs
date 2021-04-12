using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWantMyMummy.Models.ViewModels
{
    public class RackViewModel
    {
        public List<Burial> BurialList { get; set; }
        public RackSample RackSample { get; set; }
        public int BurialId { get; set; }

    }
}
