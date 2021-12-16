using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface ISliderRepository:IDisposable
    {
        IEnumerable<Slider> GetAllSlider();
        Slider GetSliderById(int sliderId);
        bool InsertSlider(Slider Slider);
        bool UpdateSlider(Slider Slider);
        bool DeleteById(int sliderId);
        void Save();
    }
}
