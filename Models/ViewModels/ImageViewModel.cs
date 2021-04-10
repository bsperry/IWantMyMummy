using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWantMyMummy.Models.ViewModels
{
    public class ImageViewModel
    {
        public List<Burial> BurialList { get; set; }
        public Image Image { get; set; }

        public int BurialId {get; set;}

        
    }
}
