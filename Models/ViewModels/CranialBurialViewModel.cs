using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWantMyMummy.Models.ViewModels
{
    public class CranialBurialViewModel
    {
        public List<Burial> BurialList { get; set; }
        public CranialSample CranialSample { get; set; }
        public int BurialId { get; set; }
    }
}
